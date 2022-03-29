package Bonanza.ShortestPath.Graph;

import Bonanza.ShortestPath.Comparable.Edge;
import org.jetbrains.annotations.NotNull;

import java.util.*;

public class HelperMethods {

    public static @NotNull HashSet <String> getNodes(@NotNull Map<String, LinkedList<Edge>> Graph) {
        HashSet <String> nodes = new HashSet<>();

        for (String key : Graph.keySet()) {
            nodes.add(key);
            for (Edge to : Graph.get(key)) {
                nodes.add(to.getTo());
            }
        }
        return nodes;
    }

    public static @NotNull List<String> generatePath(List<Integer> parent, @NotNull Map <String, Integer> hashed_nodes,
                                                     String Destination, String Source) throws Exception {
        Map<Integer, String> ids_to_nodes = new HashMap<>();
        for(Map.Entry<String, Integer> entry : hashed_nodes.entrySet()){
            ids_to_nodes.put(entry.getValue(), entry.getKey());
        }

        List<String> path = new ArrayList<>();
        int current = hashed_nodes.get(Destination);
        boolean found = false;
        while(current != -1) {
            String node = ids_to_nodes.get(current);
            path.add(node);
            if (node.equals(Source)) {
                found = true;
                break;
            }
            current = parent.get(current);
        }


        if(found == false) {
            throw new Exception("Path not found");
        }
        return reversePath(path);
    }

    private static @NotNull List<String> reversePath(@NotNull List<String> path) {
        ArrayList<String> revPath = new ArrayList<>();
        for(int i = path.size() - 1; i > -1; --i) {
            revPath.add(path.get(i));
        }
        return revPath;
    }

    public static @NotNull Map<String, Integer> hashNodes(@NotNull HashSet<String> nodes) {
        Map <String, Integer> hashed_nodes = new HashMap<>();
        Integer id = 0;
        for(String node : nodes) {
            hashed_nodes.put(node, ++id);
        }
        return hashed_nodes;
    }
}
