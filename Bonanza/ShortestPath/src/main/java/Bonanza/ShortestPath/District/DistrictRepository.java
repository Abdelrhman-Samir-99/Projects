package Bonanza.ShortestPath.District;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;

@Repository
public interface DistrictRepository extends JpaRepository <District, Integer> {
    Optional <District> findDistrictByName(String name);
    List<District> findDistrictsByCity_Id(int id);
}
