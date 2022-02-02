# Multiple Traveling Salespersons With Drones #
Simple console application which gives us an approximated path which we can use our (vehicles & drones) to deliver packages and save resources.

## The problem statement: ##
We have a number of customers that we would like to deliver products for them, we should find the minimum total time to do that using a specific number of vehicles and drones. <br/>
We have 3 entities, which are (Customer - Vehicle - Drone).

## Problem Constraints ##
+ Constraints on the Customers:
    + There is any number of customers.
    + Not allowed to visit the same customer twice.
+ Constraints on the vehicles:
    + We have exactly N vehicles.
    + Each vehicle has at most one drone.
    + Each vehicle can hold any amount of products.
+ Constraints on the drones:
    + The drone can lift at most one item.
    + The drone can lift any kind of product.
    + The drone will always return/leave the vehicle at a customer.
    + There are battery limits on the drone.
+ Neglecting the weather.

## Suggested Solution ##
Divided the problem into smaller sub-problems, then we can merge these solutions. 
+ Clustering the customers into **N** clusters where:
    + **N** is the number of vehicles.
    + Every customer exists in one and only one cluster.
+ Considering using only the vehicles (like the famous TSP problem)
    + Implemented 2-Approximation heuristic for a large number of customers.
    + Used genetic algorithms to optimize the solution of the heuristic.
+ Using the drone on the approximated path of the previous step
    + Followed a constructive manner
        + For every 3 consecutive customers, we will try to send the drone to the middle customer and meet us at the third customer.
        + [1, 2, 3] then we check if it is efficient to send the drone to customer **2** and meet us at customer 3.
            + if it is, then we send it.
            + otherwise, we go by the vehicle to customer 2.
## More Details ##
### Clustering ###
+ There were many options like (Hierarchical clustering - KNN - K-Means) but decided to choose K-Means.
### 2-Approximation ###
+ Build any Minimum Spanning Tree (MST) for every cluster.
    + Using Kruskal algorithm + Disjoint And Union set (DSU).
+ Build Euler tour of that MST:
    + Depth First Search.
    + Remove all cycles except the last one.
### Genetic Algorithm ###
+ Implemented a basic Genetic Algorithm to modify the current route.
+ Genetic Algorithm **Sometimes** improves the answer.
    + ![Screenshot from 2021-09-04 19-55-42](https://user-images.githubusercontent.com/77211992/132104064-990b0e37-3046-44cd-835c-3d74e988c8d1.png)
    + ![Screenshot from 2021-09-04 19-55-27](https://user-images.githubusercontent.com/77211992/132104040-352dc78e-92a8-4976-a970-281d542c11d9.png)
    + Initial distance is the result of the 2-Approximation.
