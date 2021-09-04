# Multiple Traveling Salespersons With Drones #
##### Simple console application which gives us an approximated route which we can use our (vehicles & drones) to deliver packages and saving resources. #####

### The problem statement: ###
##### We have a number of customers that we would like to deliver products for them, you should find the minimum total time to do that using specific number of vehicles and drones. #####
### The problem constraints: ###
+ There is any number of customers.
+ We have exactly N vehicles.
+ Each vehicle has just one drone.
+ The vehicle can not visit the same customer that is already visited by drone or another vehicle.
+ Each vehicle can hold any amount of products.
+ The drone can lift any kind of product.
+ The drone must meet the car in a customer node (not at the middle of an edge).
+ Neglecting the weather.
+ The drone can visit at most one customer then he must back to the car.
+ The drone has a specific power / Energy.

### The approach: ###
##### Divided the problem into smaller pieces so I can figure out a solution for each part. #####
+ If we have N vehicles, then we should have N groups, and each group have a different subset of customers.
+ Considering using only the vehicles, what is the best result we can get?
    + For that I implemented an approximation heuristic called 2-Approximation to give us a result which lay between [optimal_answer, 2 * optimal_answer].
    + Then implemented a genetic algorithm to see if we can get a better approximation route.
+ Now what if we can use the drone to minimize the current cost we have by using the drone?
    + I can't say that this is a greedy step (because we can't guarantee that each decision I do is optimal), but I consider every 3 consecutive customers like [1, 2, 3] and decide:
        + If we are standing at customer [1], can the drone go to customer 2 and meet us at customer 3?
            + If yes, we decide that the drone should go to customer 2.
            + If not, the vehicle travel to customer 2 by itself.

### More Details about each step: ###
+ Clustering: This step mainly to know who are the customers in each group.
    + There was many options like (Hierarchical clustering - KNN - K-Means) but decided to choose K-Means.
+ Finding a good route considering only the car:
    + Implemented 2-Approximation heuristic which consist of the following:
        + Build any Minimum Spanning Tree (MST) for the current group.
            + Using Kruskal algorithm + Disjoint And Union set (DSU).
        + Build Euler tour of that MST.
        + Remove all cycles except of the last one.
    + Implemented a basic Genetic Algorithm to modify the current route.
    + Genetic Algorithm "Sometimes improve the answer".
        ![Screenshot from 2021-09-04 19-55-42](https://user-images.githubusercontent.com/77211992/132104064-990b0e37-3046-44cd-835c-3d74e988c8d1.png)
        ![Screenshot from 2021-09-04 19-55-27](https://user-images.githubusercontent.com/77211992/132104040-352dc78e-92a8-4976-a970-281d542c11d9.png)

+ Deciding if the drone should go to customer X or not:
    + For example [1, 2, 3] and we are at customer 1, can the drone go to customer 2 and meet us at customer 3 or not.


