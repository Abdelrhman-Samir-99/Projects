package Bonanza.ShortestPath.District;

import Bonanza.ShortestPath.City.City;
import Bonanza.ShortestPath.Road.Road;

import javax.persistence.*;

@Entity
@Table
public class District {
    @Id
    @SequenceGenerator(
            name = "District_Generator",
            sequenceName = "District_Generator",
            allocationSize = 1
    )
    @GeneratedValue(
            strategy = GenerationType.SEQUENCE,
            generator = "District_Generator"
    )
    private int id;
    private String name;
    private double latitude;
    private double longitude;

    @ManyToOne
    @JoinColumn(name = "city_id", nullable = false)
    private City city;

   /*
    @OneToMany(mappedBy = "to")
    private List <Road> roads;
   */

    public District() {}

    public District(String name, double longitude, double latitude, City city) {
        this.name = name;
        this.latitude = latitude;
        this.longitude = longitude;
        this.city = city;
    }

    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public double getLatitude() {
        return latitude;
    }

    public double getLongitude() {
        return longitude;
    }

    public City getCity() {
        return city;
    }

    @Override
    public String toString() {
        return "District{" +
                "id=" + id +
                ", name='" + name + '\'' +
                ", latitude=" + latitude +
                ", longitude=" + longitude +
                ", city=" + city +
                '}';
    }
}