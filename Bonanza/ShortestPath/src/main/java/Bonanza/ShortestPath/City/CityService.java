package Bonanza.ShortestPath.City;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.util.List;
import java.util.Optional;

@Component
public class CityService {

    private final CityRepository cityRepository;

    @Autowired
    public CityService(CityRepository cityRepository) {
        this.cityRepository = cityRepository;
    }

    // returns all cities.
    public List<City> fetchAllCities() {
        return cityRepository.findAll();
    }

    public Optional<City> findById(int id) {
        return cityRepository.findById(id);
    }

    public City getById(int id) {
        return cityRepository.getById(id);
    }

    // adding a new city.
    public boolean addCity(String name) {
        Optional<City> City = cityRepository.findCityByName(name);
        if(City.isPresent()) {
            return false;
        }
        City newCity = new City(name);
        cityRepository.save(newCity);
        return true;
    }

    // removing a city.
    public boolean removeCity(int id) {
        boolean exist = cityRepository.existsById(id);
        if(!exist) {
            return false;
        }
        cityRepository.deleteById(id);
        return true;
    }
}