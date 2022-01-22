package nl.saxion.roomreservationsystem.room;

import nl.saxion.roomreservationsystem.reservation.Reservation;

import javax.persistence.*;
import java.util.ArrayList;
import java.util.List;

@Entity
@Table
public class Room {

    @Id
    @SequenceGenerator(name = "room_sequence",
    sequenceName = "room_sequence",
    allocationSize = 1)
    @GeneratedValue(strategy = GenerationType.SEQUENCE,
    generator = "room_sequence")
    private Long id;

    private String name;

    @Transient
    private List<Reservation> roomReservations = new ArrayList<>();

    public Room(long id, String name) {
        this.id = id;
        this.name = name;
    }

    public Room(String name) {
        this.name = name;
    }

    public Room() {

    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
    public List<Reservation> getRoomReservations() {
        return roomReservations;
    }

    public void addRoomReservations(Reservation reservation) {
        roomReservations.add(reservation);
    }
}
