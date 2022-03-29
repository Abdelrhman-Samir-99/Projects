package Bonanza.ShortestPath.Dijkstra;

import Bonanza.ShortestPath.Comparable.Edge;
import Bonanza.ShortestPath.Graph.HelperMethods;
import org.jetbrains.annotations.NotNull;

import java.util.*;


public class Dijkstra {


    public static @NotNull List<String> startDijkstra(Map<String, LinkedList<Edge>> Graph,
                                                      String Source, String Destination) throws Exception {

        final Double MAX_DISTANCE = 1_000_000.0;
        HashSet<String> nodes = HelperMethods.getNodes(Graph);
        List <Integer> parent = new ArrayList<>(nodes.size() + 1);
        List <Double> Cost = new ArrayList<>(nodes.size() + 1);
        for(int i = 0; i <= nodes.size(); ++i) {
            parent.add(-1);
            Cost.add(MAX_DISTANCE);
        }


        Map <String, Integer> hashed_nodes = HelperMethods.hashNodes(nodes);

        if(!hashed_nodes.containsKey(Source) || !hashed_nodes.containsKey(Destination)) {
            throw new Exception("There is no path.");
        }

        PriorityQueue<Edge> minHeap = new PriorityQueue<>();
        minHeap.add(new Edge(Source, 0));


        while(!minHeap.isEmpty() && Cost.get(hashed_nodes.get(Destination)).equals(MAX_DISTANCE)) {
            Edge current = minHeap.poll();
            Double cost = Cost.get(hashed_nodes.get(current.getTo()));
            if(cost == MAX_DISTANCE) {
                Cost.set(hashed_nodes.get(current.getTo()), current.getDistance());
                for (Edge edge : Graph.get(current.getTo())) {
                    Double newDistance = Cost.get(hashed_nodes.get(current.getTo())) + edge.getDistance();
                    Double currentDistance = Cost.get(hashed_nodes.get(edge.getTo()));
                    if (newDistance < currentDistance) {
                        minHeap.add(new Edge(edge.getTo(), newDistance));
                        Cost.set(hashed_nodes.get(edge.getTo()), newDistance);
                        parent.set(hashed_nodes.get(edge.getTo()), hashed_nodes.get(current.getTo()));
                    }
                }
            }
        }
        return HelperMethods.generatePath(parent, hashed_nodes, Destination, Source);
    }
}
