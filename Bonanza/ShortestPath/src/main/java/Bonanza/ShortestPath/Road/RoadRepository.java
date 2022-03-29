package Bonanza.ShortestPath.Road;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface RoadRepository extends JpaRepository<Road, Integer> {
    List <Road> findRoadsByCityId(int id);
}
