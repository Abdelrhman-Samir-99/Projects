#!/usr/bin/python
# -*- coding: latin-1 -*-

from gene import *
from clustering import *
import pandas as pd
from last import *
import math

# helper function
def get_dis(x, y, x1, y1):
	return math.sqrt((x - x1)**2 + (y - y1)**2)


# Euclidean distance
def distance(city1, city2):
     xDis = abs(city1.x - city2.x)
     yDis = abs(city1.y - city2.y)
     distance = np.sqrt((xDis ** 2) + (yDis ** 2))
     return distance

# Reading the cities from the csv file
df = pd.read_csv("city_locations.csv")[:30]
x = np.array(df[['Longitude', 'Latitude']])

# These constraints should be taken as input.
starting_pos = 1
group_count = 1
drone_limit = 10
n = 30
y = kmeans(x, group_count) # Culustered list.



# Building the complete graph between cities
Graph = []
for i in range(0, n):
	ls = [0] * n
	Graph.append(ls)

for i in range(0, n):
	for j in range(0, n):
		Graph[i][j] = get_dis(df['Longitude'][i], df['Latitude'][i], df['Longitude'][j], df['Latitude'][j]) 

		
# Getting the clusters for the graph
Model = solve(starting_pos, y, Graph, n)

# starting the second phase, which is finding approximated path
sol_per_group = Model.get_sol(group_count)

# starting the third phase, which is using genetic algorithm to optimize the previous path
sol_per_group_genetic = Solve(sol_per_group, starting_pos, df[['Longitude', 'Latitude']])


# the fourth step, which is just doing the constructive idea.

# cnt_groups = 0
# for each_group_in_genetic in sol_per_group_genetic:
	# drone_for_this_group = []
	# cnt = len(each_group_in_genetic)
	# for index in range(0, cnt - 2):
		# current_city = each_group_in_genetic[index]
		# drone_city = each_group_in_genetic[index + 1]
		# next_city = each_group_in_genetic[index + 2]
		# if(distance(current_city, drone_city) + distance(drone_city, next_city) < drone_limit):
			# drone_for_this_group.append(drone_city)
			# index = index + 1
	# print("for group " + str(cnt_groups) + " the drone went for: ");
	# print("")
	# for drone in drone_for_this_group:
		# print(drone)
	# cnt_groups = cnt_groups + 1
