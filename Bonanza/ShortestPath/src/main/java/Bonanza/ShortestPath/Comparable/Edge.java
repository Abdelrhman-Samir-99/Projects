package Bonanza.ShortestPath.Comparable;

public class Edge implements Comparable<Edge> {

    private String to;

    public String getTo() {
        return to;
    }

    public double getDistance() {
        return distance;
    }

    private double distance;

    public Edge(String to, double distance) {
        this.to = to;
        this.distance = distance;
    }

    public int compareTo(Edge rhs) {
        if(this.distance < rhs.distance)
            return -1;
        else if(rhs.distance < this.distance)
            return 1;
        return 0;
    }
}
