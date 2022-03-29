package Bonanza.ShortestPath.District;

import Bonanza.ShortestPath.City.City;
import Bonanza.ShortestPath.City.CityService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class DistrictService {

    private final DistrictRepository districtRepository;
    private final CityService cityService;

    @Autowired
    public DistrictService(DistrictRepository districtRepository, CityService cityService) {
        this.districtRepository = districtRepository;
        this.cityService = cityService;
    }

    public List<District> fetchAllDistricts() {
        return districtRepository.findAll();
    }

    public List <District> fetchByCityId(int cityId) {
        return districtRepository.findDistrictsByCity_Id(cityId);
    }

    public District fetchById(int id) {
        return districtRepository.getById(id);
    }

    public boolean addDistrict(int cityId, String name, double longitude, double latitude) {
        Optional<District> District = districtRepository.findDistrictByName(name);
        Optional<City> city = cityService.findById(cityId);
        if(District.isPresent() || city.isEmpty()) {
            return false;
        }
        City currentCity = cityService.getById(cityId);
        District newDistrict = new District(name, longitude, latitude, currentCity);
        districtRepository.save(newDistrict);
        return true;
    }
}