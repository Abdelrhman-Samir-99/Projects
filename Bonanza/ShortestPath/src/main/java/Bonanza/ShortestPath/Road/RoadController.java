package Bonanza.ShortestPath.Road;

import Bonanza.ShortestPath.Comparable.Edge;
import Bonanza.ShortestPath.Dijkstra.Dijkstra;
import Bonanza.ShortestPath.Graph.Structure;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.LinkedList;
import java.util.List;
import java.util.Map;

@RestController
@RequestMapping(path = "bonanza/road")
public class RoadController {

    private final RoadService roadService;

    @Autowired
    public RoadController(RoadService roadService) {
        this.roadService = roadService;
    }

    @GetMapping
    public List<Road> fetchAllRoads() {
        return roadService.fetchAllRoads();
    }

    @GetMapping(path = "{cityId}/{from_district_name}/{to_district_name}")
    public List <String> generateShortestPath(@PathVariable("from_district_name") String source,
                                             @PathVariable("to_district_name") String destination,
                                             @PathVariable("cityId") int cityId) throws Exception {

        List <Road> cityRoads = roadService.fetchRoadsByCityId(cityId);
        Map<String, LinkedList<Edge>> Graph = Structure.toAdjacencyList(cityRoads);
        return Dijkstra.startDijkstra(Graph, source, destination);
    }

    @PostMapping(path = "{cityId}/{from_district_id}/{to_district_id}")
    public boolean addRoad(@PathVariable("from_district_id") int from_district_id,
                           @PathVariable("to_district_id") int to_district_id,
                           @PathVariable("cityId") int cityId) {

        return roadService.addRoad(from_district_id, to_district_id, cityId);
    }
}
