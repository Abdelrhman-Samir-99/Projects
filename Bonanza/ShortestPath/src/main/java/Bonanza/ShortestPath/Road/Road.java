package Bonanza.ShortestPath.Road;

import Bonanza.ShortestPath.District.District;
import org.jetbrains.annotations.NotNull;

import javax.persistence.*;

@Entity
@Table
public class Road {
    @Id
    @SequenceGenerator(
            name = "Road_Generator",
            sequenceName = "Road_Generator",
            allocationSize = 1
    )
    @GeneratedValue(
            strategy = GenerationType.SEQUENCE,
            generator = "Road_Generator"
    )
    private int id;

    // Should be a FK.
    private int cityId;

    // @ManyToOne
    // @JoinColumn(name = "from_district_id", nullable = false)
    private String from_district_name;

    // @ManyToOne
    // @JoinColumn(name = "to_district_id", nullable = false)
    private String to_district_name;

    // @Transient
    private double distance; // can be deducted.

    public Road() {}

    public Road(@NotNull District from, @NotNull District to, int cityId) {
        this.from_district_name = from.getName();
        this.to_district_name = to.getName();
        this.distance = euclideanDistance(from, to);
        this.cityId = cityId;
    }

    public int getId() {
        return id;
    }

    public String getFrom_district_name() {
        return from_district_name;
    }

    public String getTo_district_name() {
        return to_district_name;
    }

    public double getDistance() {
        return distance;
    }

    public int getCityId() {
        return cityId;
    }

    @Override
    public String toString() {
        return "Road{" +
                "id=" + id +
                ", from_district_id=" + from_district_name +
                ", to_district_id=" + to_district_name +
                ", distance=" + distance +
                '}';
    }

    double euclideanDistance(@NotNull District from, @NotNull District to) {
        double abs = Math.abs((from.getLatitude() - to.getLatitude()) * (from.getLatitude() - to.getLatitude())
                + (from.getLongitude() - to.getLongitude()) * (from.getLongitude() - to.getLongitude())
        );
        return Math.sqrt(abs);
    }
}
