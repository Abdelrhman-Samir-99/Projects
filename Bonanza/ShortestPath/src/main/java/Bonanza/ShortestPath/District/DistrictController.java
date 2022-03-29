package Bonanza.ShortestPath.District;


import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping(path = "bonanza/district")
public class DistrictController {

    private final DistrictService districtService;

    @Autowired
    public DistrictController(DistrictService districtService) {
        this.districtService = districtService;
    }


    @GetMapping
    public List<District> fetchAllDistricts() {
        return districtService.fetchAllDistricts();
    }


    @GetMapping(path = "{cityId}")
    public List <District> fetchByCityId(@PathVariable("cityId") int cityId) {
        return districtService.fetchByCityId(cityId);
    }

    @PostMapping(path = "{cityId}/{districtName}/{longitude}/{latitude}")
    public boolean addDistrict(@PathVariable("cityId") int cityId,
                               @PathVariable("districtName") String name,
                               @PathVariable("longitude") double longitude,
                               @PathVariable("latitude") double latitude) {
        return districtService.addDistrict(cityId, name, longitude, latitude);
    }
}
