# Coding Problems

[![Build status](https://ci.appveyor.com/api/projects/status/jbjxwn8cgssnvxro?svg=true)](https://ci.appveyor.com/project/LevYas/codingproblems)

Here are my tested solutions to some coding problems.

They couldn't advertise my architecture design skills but good enough to show my approach to write clean, testable, and effective code.

## The solution structure
1. **CodingProblems:** different coding problems solved using C# and .NET Core. Inside the project, you will find solved problems on different topics: graphs, array indices, lists, math, numerical systems, sorting, heap, and others. All the algorithms are good in performance, usually, they're faster than 80-90% of submissions according to LeetCode metrics.

2. **CodingProblemsTests:** unit tests for the previous project written using xUnit. Project folders are the same as in project-under-tests.

3. **CppCodingProblems:** the most interesting part here is an efficient interval map implementation written in C++. There are the lowest possible amount of logarithmic operations, I used manual manipulations with iterators to achieve that.

4. **CppCodingProblemsTests:** here are the tests for the previous project written using GoogleTest. I used Property-based testing concept instead of Example-based testing to write clear and concise tests for the IntervalMap.

5. **QuadraticEquationSolver:** a small C++ program that divides the console input of numbers into triplets and solves the quadratic equation for each of them. I wrote the program in a functional style and used the special structure to return function result called `Result`, which inspired by concepts of sum data types and Alexandrescu's `Expected<T>` with adaptation to the program.

6. **QuadraticEquationSolverTests:** the tests for the solver, also written using GoogleTest.


## Building and running test on Windows

### Prerequisites
1. Visual Studio 2019 or later (Community Edition is enough) with the following components:  
  1.1. .NET Core 3.1 SDK  
  1.2. C++ development workload  
  1.3. Windows 10 SDK  

### Building
1. Open the solution file and execute the "Build solution" command.

### Running tests
1. Open the "Test Explorer" (Menu: Test -> Test Explorer).
2. Press the "Run All Tests" button.

### Troubleshooting
1. Check that all the prerequisites are in place.
2. Read the error messages in the "Output" window from the beginning. Some not mentioned here component could be missing.
3. Feel free to create an issue if you have any trouble.