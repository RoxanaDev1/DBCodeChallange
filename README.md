# DB Coding Challenge

## Introduction

The solution is built in 2 projects:

1. Solution - Where the code for solving the problem is.
2. Solution.Tests - This project contains the tests for the code written in Solution.

The program contains of 3 main components:

1. Program.cs - The main file which runs the alg.
2. Graph - The folder contains the definition for a graph and nodes defined in this problem.
3. Utils - Contains some static utility functions. Those functions help with some basic operations like processing input and processing the results.

## How to run

This project is built/run with vscode.

Run the following command:

`dotnet restore` //This will build both of the projects

`dotnet run --project Solution <FilePath>` //Run the project with a given path to a file

or

`dotnet run --project Solution` //If file is added to input folder, and the path in the code is updated to your file.

Running the tests:

`dotnet test`

## Solution components

In order to solve this I have implemented 2 main classes:

1. Node - The node describes each number in the triangle.
   The node contains information about:

- The number itself - I called this weight, as this is the number which we calculate the sum with.
- Is the number even - This will help build the neighbor nodes to a given node base on the rule where after even number comes an odd number and vice versa.
- A unique identifier for the node - This will help identify the node itself and its neighbors.
- Is last - One of the rule states that a full path contains a number from the last line of the triangle. In order to "easily" identify those, I added this boolean to each node. It is not possible to identify as a node without neighbors, as an even number with 2 even children in the triangle will not contain neighbors as well.

2. Graph - The graph describes the collection of nodes created from the triangle. The graph also contains a search function which is using the depth first search. I chose depth first as we would like to find the longest path.
   Note - The graph is directed, as from each node there is one direction.
   The graph contains the following information:

- Nodes - A list of all the nodes which are part of the graph.
- Max length - The amount of lines in the triangle, which is the path length which we would like to find.

## Solution explained

The overall solution contains the following steps:

1. Process input - Create the nodes.

The triangle input is translated into a 2D matrix of nodes. The reason for creating the nodes at this point is due to the fact that when building the graph, neighbor nodes should be added, if those are created while building the graph the reference might be lost - building the node before processing it.

Note - Processing of the input will throw exceptions on: empty input, file not found ot none number input.
Note - I assumed that all numbers given would be integers, but with few changes those can be decimals as well.

2. Create the graph.

Once such a matrix is in place, it is very easy to scan it and build for every node the list of neighbors using the rule where one parent has 2 children, as described in page 2.
During the build of the graph invalid neighbors will not be added.

3. Search the graph and find paths.

The search is using depth first search, as we would like to reach deep to the last line given. The search would contain a path, which is the current path we are discovering. Each time a node is discovered it is added, and each time we reach a dead end of the recursive function returns - a node is removed. The happy path is when reaching a node which has the attribute "isLast". This path will be then added to the list of discovered paths.
The algorithm usually uses a list of visited nodes, in our case if this list is added some of the paths might be dropped, as nodes can have more then one parent which can cause that the node was already visited by a previous parent.

4. Process the paths and get the one with maximum sum.

Using some util functions for list manipulation for finding the sum and path of the returned found paths.

## Possible Improvements

1. I assumed that numbers would be integers, the program can be changed to handle also decimals.
2. As described in the problem example a node can have up 2 children, this can also be changed to have a const which describes the amount of neighbors. For example it can be 3.
3. I covered the majority of things in the code with the tests, I think there can be still some extra added.
4. I could also use a list of list of nodes and not a list of array of nodes - this way I could write more for each rather then using the good old for loop.
