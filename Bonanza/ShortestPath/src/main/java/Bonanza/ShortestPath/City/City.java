package Bonanza.ShortestPath.City;

import Bonanza.ShortestPath.District.District;

import javax.persistence.*;
import java.util.List;
import java.util.Set;

@Entity
@Table
public class City {
    @Id
    @SequenceGenerator(
            name = "City_Generator",
            sequenceName = "City_Generator",
            allocationSize = 1
    )
    @GeneratedValue(
            strategy = GenerationType.SEQUENCE,
            generator = "City_Generator"
    )

    private int id;
    private String name;
    @OneToMany(mappedBy = "city")
    private List <District> districts;
    public City(String name) {
        this.name = name;
    }

    public City() {}

    public City(int id, String name) {
        this.id = id;
        this.name = name;
    }

    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public List <District> getDistricts() {
        return districts;
    }

    @Override
    public String toString() {
        return "City{" +
                "id=" + id +
                ", name='" + name + '\'' +
                ", districts=" + districts +
                '}';
    }
}