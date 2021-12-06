#pragma once
#include <vector>
#include <algorithm>
#include <cassert>
#include <queue>
#include <iostream>

// N Puzzle is a sliding blocks game that takes place on a k * k grid with ((k * k) - 1) tiles each numbered from 1 to N.
// Your task is to reposition the tiles to their proper order.
// https://www.hackerrank.com/challenges/n-puzzle/problem
// Solved using A* algorithm with priority queue

enum class Turn { Initial, Left, Right, Up, Down };
using Board = std::vector<std::vector<int>>;

inline int calcManhattanDistance(const Board& grid)
{
    int distance = 0;
    const int side = static_cast<int>(grid.size());
    
    for (int y = 0; y < side; y++)
    {
        for (int x = 0; x < side; x++)
        {
            const int value = grid[y][x];

            distance += std::abs(value % side - x); // diff by X
            distance += std::abs(value / side - y); // diff by Y
        }
    }

    return distance;
}

inline Board copyBoard(const Board& b)
{
    Board newBoard(b.size());

    for (size_t y = 0; y < b.size(); y++)
        newBoard[y] = b[y];

    return newBoard;
}

struct coordinate
{
    size_t x;
    size_t y;
};

inline coordinate getPositionOfZero(const Board& b)
{
    for (size_t y = 0; y < b.size(); y++)
    {
        for (size_t x = 0; x < b[y].size(); x++)
        {
            if (b[y][x] == 0)
                return coordinate{x, y};
        }
    }

    throw std::runtime_error("WTF");
}

struct next_turn
{
    Turn turn;
    Board board;
};

inline std::vector<next_turn> getPossibleNextTurns(const Board& grid, Turn prevTurn)
{
    std::vector<next_turn> nextTurns;

    auto [x, y] = getPositionOfZero(grid);

    if (x > 0 && prevTurn != Turn::Right)
    {
        Board nextTurn = copyBoard(grid);
        std::swap(nextTurn[y][x], nextTurn[y][x - 1]);
        nextTurns.emplace_back(Turn::Left, nextTurn);
    }

    if (x < grid.size() - 1 && prevTurn != Turn::Left)
    {
        Board nextTurn = copyBoard(grid);
        std::swap(nextTurn[y][x], nextTurn[y][x + 1]);
        nextTurns.emplace_back(Turn::Right, nextTurn);
    }

    if (y > 0 && prevTurn != Turn::Down)
    {
        Board nextTurn = copyBoard(grid);
        std::swap(nextTurn[y][x], nextTurn[y - 1][x]);
        nextTurns.emplace_back(Turn::Up, nextTurn);
    }

    if (y < grid.size() - 1 && prevTurn != Turn::Up)
    {
        Board nextTurn = copyBoard(grid);
        std::swap(nextTurn[y][x], nextTurn[y + 1][x]);
        nextTurns.emplace_back(Turn::Down, nextTurn);
    }

    return nextTurns;
}

struct boardState
{
    Board board;
    int distance;
    int moves;
    Turn turn;
    boardState* previousState;

    bool operator<(const boardState& b) const
    {
        return distance + moves > b.distance + b.moves;
    }
};

struct dereferenceCompareBoardState
{
    bool operator()(const boardState* lhs, const boardState* rhs) const
    {
        return *lhs < *rhs;
    }
};

using board_pq = std::priority_queue<boardState*, std::vector<boardState*>, dereferenceCompareBoardState>;

inline void makeTurn(board_pq& pq, std::vector<boardState*>& toDelete)
{
    boardState* node = pq.top();
    pq.pop();

    for (const auto& next_turn : getPossibleNextTurns(node->board, node->turn))
    {
        auto newState = new boardState{next_turn.board, calcManhattanDistance(next_turn.board), node->moves + 1, next_turn.turn, node};
        pq.push(newState);
        toDelete.push_back(newState);
    }
}

inline Board makeAlternativeBoard(const Board& grid)
{
    auto altBoard = copyBoard(grid);
    const size_t idx1 = altBoard[0][0] == 0 ? 1 : 0;
    const size_t idx2 = altBoard[0][idx1 + 1] == 0 ? idx1 + 2 : idx1 + 1;
    std::swap(altBoard[0][idx1], altBoard[0][idx2]);
    return altBoard;
}

inline void deleteBoards(std::vector<boardState*>& boards)
{
    for (const boardState* boardPtr : boards)
        delete boardPtr;

    boards.clear();
}

struct solution
{
    bool isSolvable;
    std::vector<Turn> turns;
};

inline solution solve(const Board& grid)
{
    const int distance = calcManhattanDistance(grid);

    if (distance == 0)
        return solution{true, std::vector<Turn>()};

    std::vector<boardState*> toDelete;

    board_pq pq;
    const auto initialState = new boardState{grid, distance, 0, Turn::Initial, nullptr};
    pq.push(initialState);
    toDelete.push_back(initialState);

    // To detect unsolvable boards, use the fact that boards are divided into two equivalence classes with respect to reachability:
    // - Those that can lead to the goal board
    // - Those that can lead to the goal board if we modify the initial board by swapping any pair of tiles
    //      (the blank square is not a tile).
    // To apply the fact, run the A* algorithm on two puzzle instances—one with the initial board and
    // one with the initial board modified by swapping a pair of tiles—in lockstep
    // (alternating back and forth between exploring search nodes in each of the two game trees).
    // Exactly one of the two will lead to the goal board.
    board_pq altPq;
    const auto altBoard = makeAlternativeBoard(grid);
    const auto altInitialState = new boardState{altBoard, calcManhattanDistance(altBoard), 0, Turn::Initial, nullptr};
    altPq.push(altInitialState);
    toDelete.push_back(altInitialState);

    do
    {
        makeTurn(pq, toDelete);
        makeTurn(altPq, toDelete);
    }
    while (pq.top()->distance != 0 && altPq.top()->distance != 0);

    if (altPq.top()->distance == 0)
    {
        deleteBoards(toDelete);
        return solution{false, std::vector<Turn>()};
    }

    assert(pq.top()->distance == 0);

    const boardState* node = pq.top();

    std::vector<Turn> turns;
    while (node != nullptr && node->turn != Turn::Initial)
    {
        turns.insert(turns.begin(), node->turn);
        node = node->previousState;
    }

    deleteBoards(toDelete);
    return solution{true, turns};

}

inline int mainForHackerRank() {

    int side;
    std::cin >> side;

    Board initialBoard;

    for (int i = 0; i < side; i++)
    {
        initialBoard.push_back(std::vector<int>());

        for (int j = 0; j < side; j++)
        {
            int value;
            std::cin >> value;
            initialBoard[i].push_back(value);
        }
    }

    const solution solution = solve(initialBoard);

    std::cout << solution.turns.size() << std::endl;

    for (const auto& turn : solution.turns)
    {
        switch (turn)
        {
        case Turn::Left:
            std::cout << "LEFT" << std::endl;
            break;

        case Turn::Right:
            std::cout << "RIGHT" << std::endl;
            break;

        case Turn::Up:
            std::cout << "UP" << std::endl;
            break;

        case Turn::Down:
            std::cout << "DOWN" << std::endl;
            break;

        default: ;
        }

    }

    return 0;
}
