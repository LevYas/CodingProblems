using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingProblems
{
    // There are n servers numbered from 0 to n-1 connected by undirected server-to-server connections
    // forming a network where connections[i] = [a, b] represents a connection between servers a and b.
    // Any server can reach any other server directly or indirectly through the network.
    // A critical connection is a connection that, if removed, will make some server unable to reach some other server.
    // Return all critical connections in the network in any order.
    // https://leetcode.com/problems/critical-connections-in-a-network/
    public class CriticalConnectionFinder
    {
        private List<int>[] _connectionsToOthers;

        private int _currentStep;
        private int[] _nodesVisitingStep;
        private int[] _lowestAccessibleNodeStep;

        private List<IList<int>> _criticalConnections;

        public IList<IList<int>> FindByDfs(int n, IList<IList<int>> connections)
        {
            _criticalConnections = new List<IList<int>>();

            if (!connections.Any())
                return _criticalConnections;

            _connectionsToOthers = new List<int>[n];

            for (int i = 0; i < n; i++)
                _connectionsToOthers[i] = new List<int>();

            foreach (IList<int> item in connections)
            {
                _connectionsToOthers[item[0]].Add(item[1]);
                _connectionsToOthers[item[1]].Add(item[0]);
            }

            _nodesVisitingStep = new int[n];
            _lowestAccessibleNodeStep = new int[n];

            findBridgesByDfs(-1, 0);

            return _criticalConnections;
        }

        private void findBridgesByDfs(int prev, int cur)
        {
            ++_currentStep;

            _nodesVisitingStep[cur] = _currentStep;
            _lowestAccessibleNodeStep[cur] = _currentStep;

            foreach (int next in _connectionsToOthers[cur].Where(node => node != prev))
            {
                if (_nodesVisitingStep[next] > 0) // that means next node is already visited
                {
                    _lowestAccessibleNodeStep[cur] = Math.Min(_lowestAccessibleNodeStep[cur], _nodesVisitingStep[next]);
                }
                else
                {
                    findBridgesByDfs(cur, next);
                    _lowestAccessibleNodeStep[cur] = Math.Min(_lowestAccessibleNodeStep[cur], _lowestAccessibleNodeStep[next]);

                    if (_lowestAccessibleNodeStep[next] > _nodesVisitingStep[cur])
                        _criticalConnections.Add(new List<int> { cur, next });
                }
            }
        }

        private static void addOrAppend(Dictionary<int, List<int>> dictionary, int key, int val)
        {
            if (dictionary.ContainsKey(key))
                dictionary[key].Add(val);
            else
                dictionary.Add(key, new List<int> { val });
        }

        public static IList<IList<int>> FindByBruteForce(int n, IList<IList<int>> connections)
        {
            var criticalConnections = new List<IList<int>>();

            var connectionsToOthers = new Dictionary<int, List<int>>(n);

            foreach (IList<int> item in connections)
            {
                addOrAppend(connectionsToOthers, item[0], item[1]);
                addOrAppend(connectionsToOthers, item[1], item[0]);
            }

            foreach (IList<int> connection in connections)
            {
                connectionsToOthers[connection[0]].Remove(connection[1]);
                connectionsToOthers[connection[1]].Remove(connection[0]);

                if (!IsGraphConnected(n, connectionsToOthers))
                    criticalConnections.Add(connection);

                connectionsToOthers[connection[0]].Add(connection[1]);
                connectionsToOthers[connection[1]].Add(connection[0]);
            }

            return criticalConnections;
        }

        public static bool IsGraphConnected(int n, Dictionary<int, List<int>> connectionsToOthers)
        {
            bool[] visitedNodes = new bool[n];
            HashSet<int> nodesToVisit = new HashSet<int>() { 0 };

            while (nodesToVisit.Any())
            {
                int nodeIdx = nodesToVisit.First();
                nodesToVisit.Remove(nodeIdx);
                visitedNodes[nodeIdx] = true;

                if (connectionsToOthers.ContainsKey(nodeIdx))
                {
                    foreach (int connectedNode in connectionsToOthers[nodeIdx].Where(cn => !visitedNodes[cn]))
                        nodesToVisit.Add(connectedNode);
                }
            }

            return visitedNodes.All(isVisited => isVisited);
        }
    }
}
