package Bonanza.ShortestPath.Graph;

import Bonanza.ShortestPath.Comparable.Edge;
import Bonanza.ShortestPath.Road.Road;
import org.jetbrains.annotations.NotNull;

import java.util.HashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;

public class Structure {
    public static @NotNull Map<String, LinkedList <Edge>> toAdjacencyList(@NotNull List <Road> roads) {
        Map <String, LinkedList <Edge>> graph = new HashMap<>();
        for(Road road : roads) {
            String From = road.getFrom_district_name();
            String To = road.getTo_district_name();
            double distance = road.getDistance();

            if(!graph.containsKey(From)) {
                graph.put(From, new LinkedList<>());
            }
            graph.get(From).add(new Edge(To, distance));
        }
        return graph;
    }
}
