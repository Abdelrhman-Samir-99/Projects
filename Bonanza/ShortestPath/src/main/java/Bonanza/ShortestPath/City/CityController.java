package Bonanza.ShortestPath.City;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping(path = "bonanza/city")
public class CityController {
    private final CityService cityService;

    @Autowired
    public CityController(CityService cityService) {
        this.cityService = cityService;
    }

    @GetMapping
    public List <City> fetchAllCities() {
        return cityService.fetchAllCities();
    }

    @PostMapping(path = "{cityName}")
    public boolean addCity(@PathVariable("cityName") String name) {
        return cityService.addCity(name);
    }

    @DeleteMapping(path = "{cityId}")
    public boolean removeCity(@PathVariable("cityId") int id) {
        return cityService.removeCity(id);
    }
}