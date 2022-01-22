package nl.saxion.roomreservationsystem.reservation;

import javax.persistence.*;
import java.time.LocalDate;

@Entity
@Table
public class Reservation {

    public Reservation() {

    }

    public Reservation(Long roomId, LocalDate startDate, LocalDate endDate, String username) {
        this.roomId = roomId;
        this.startDate = startDate;
        this.endDate = endDate;
        this.username = username;
    }

    @Id
    @SequenceGenerator(name = "reservation_sequence",
            sequenceName = "reservation_sequence",
            allocationSize = 1)
    @GeneratedValue(strategy = GenerationType.SEQUENCE,
            generator = "reservation_sequence")
    private Long id;

    private Long roomId;

    private LocalDate startDate;
    private LocalDate endDate;

    private String username;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public Long getRoomId() {
        return roomId;
    }

    public void setRoomId(Long roomId) {
        this.roomId = roomId;
    }

    public LocalDate getStartDate() {
        return startDate;
    }

    public void setStartDate(LocalDate startDate) {
        this.startDate = startDate;
    }

    public LocalDate getEndDate() {
        return endDate;
    }

    public void setEndDate(LocalDate endDate) {
        this.endDate = endDate;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }
}
