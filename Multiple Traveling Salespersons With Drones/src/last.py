class Graph:
    def __init__(self, vertices):
        self.V = vertices
        self.graph = []

    def add_edge(self, u, v, w):
        self.graph.append([u, v, w])
	
    def clear(self):
	self.graph.clear()
	
    # Finding the component_Id of a node.
    def find(self, parent, i):
        if parent[i] == i:
            return i
        parent[i] = self.find(parent, parent[i])
        return parent[i]

   # Merging two component based on size.
    def apply_union(self, parent, rank, x, y):
        xroot = self.find(parent, x)
        yroot = self.find(parent, y)
        if rank[xroot] < rank[yroot]:
            parent[xroot] = yroot
        elif rank[xroot] > rank[yroot]:
            parent[yroot] = xroot
        else:
            parent[yroot] = xroot
            rank[xroot] += 1

    #  Applying Kruskal algorithm
    def kruskal_algo(self, cnt):
        result = []
        i, e = 0, 0
        self.graph = sorted(self.graph, key = lambda item: item[2])
        parent = []
        rank = []

        for node in range(self.V):
            parent.append(node)
            rank.append(0)

	# Constructing a tree with (n - 1) edges.
        while e < cnt - 1:
			u, v, w = self.graph[i]
			i = i + 1
			x = self.find(parent, u)
			y = self.find(parent, v)
			if x != y:
				e = e + 1
				result.append([u, v, w])
				self.apply_union(parent, rank, x, y)
        return result


class solve:
	# @starting_position is the root
	# @Clustered_list is the group of each node, i.e, clustered_list[0] = 1, node 0 belongs to group 1.
	# @Graph all connections between cities.
	# @n is the size of the graph
	def __init__(self, starting_pos, Culustered_list, Graph, n):
		self.Culustered_List = Culustered_list
		self.root = starting_pos
		self.Graph = Graph
		self.n = n

	# printing the approximated path for each group.
	def printing(self, sol_per_group):
		for x in sol_per_group:
			print(x)
	
	# Building Euler Tour
	def DFS(self, u, parent, Euler, new_graph, V):
		if(u == parent):
			return
		if(V[u] == True):
			return
		V[u] = True
			
		Euler.append(u)
		
		for v in new_graph[u]:
			self.DFS(v, u, Euler, new_graph, V)
			Euler.append(u)
		return
		
	# Finding solution for all clusters
	def get_sol(self, group_count):
		sol_per_group = []
		# iterating over all possible count of groups.
		# grouping the nodes by each group.
		# solving for each group
		
		for current_group in range(0, group_count):
			# building the graph for 0 .. group_count
			current_nodes = []
			for i in range(0, len(self.Culustered_List)):
				if(i == self.root):
					continue
				if(self.Culustered_List[i] == current_group):
					current_nodes.append(i)
			current_nodes.append(self.root)
			
			# Making the graph per cluster, may be optimized
			G = Graph(self.n)
			for u in current_nodes:
				for v in current_nodes:
					if(u == v):
						continue
					G.add_edge(u, v, self.Graph[u][v])
			
			# Building the MST for single cluster
			MST = G.kruskal_algo(len(current_nodes))

			new_graph = []
			for i in range(0, self.n):
				ls = []
				new_graph.append(ls)
			
			# Converting the MST into graph.
			for u, v, w in MST:
				new_graph[u].append(v)
				new_graph[v].append(u)
			
			# Building Euler Tour for the MST
			Euler = []
			V = [0] * self.n 
			self.DFS(self.root, -1, Euler, new_graph, V)

			# Removing all smaller cycles
			visited = [0] * self.n
			visited[self.root] = True
			cnt = 0
			
			# Marking visited nodes 
			for i in range(1, len(Euler) - 1):
				if(visited[Euler[i]]):
					Euler[i] = -1
					cnt = cnt + 1
					continue
				visited[Euler[i]] = True
			
			# Removing visited nodes
			while cnt != 0:
				Euler.remove(-1)
				cnt = cnt - 1
				
			# appending the solution of the current cluster
			sol_per_group.append(Euler)
		
		# self.printing(sol_per_group)
		return sol_per_group
