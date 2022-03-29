package Bonanza.ShortestPath.Road;

import Bonanza.ShortestPath.District.District;
import Bonanza.ShortestPath.District.DistrictService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class RoadService {

    private final RoadRepository roadRepository;
    private final DistrictService districtService;

    @Autowired
    public RoadService(RoadRepository roadRepository, DistrictService districtService) {
        this.roadRepository = roadRepository;
        this.districtService = districtService;
    }

    public List<Road> fetchAllRoads() {
        return roadRepository.findAll();
    }

    public List<Road> fetchRoadsByCityId(int id) {return roadRepository.findRoadsByCityId(id);}

    public boolean addRoad(int from_district_id, int to_district_it, int cityId) {
        District from = districtService.fetchById(from_district_id);
        District to = districtService.fetchById(to_district_it);
        if(from == null || to == null) {
            return false;
        }
        Road newRoad = new Road(from, to, cityId);
        roadRepository.save(newRoad);
        return true;
    }
}
