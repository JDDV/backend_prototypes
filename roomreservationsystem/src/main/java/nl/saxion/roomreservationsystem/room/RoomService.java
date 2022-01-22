package nl.saxion.roomreservationsystem.room;

import nl.saxion.roomreservationsystem.reservation.Reservation;
import nl.saxion.roomreservationsystem.reservation.ReservationService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.time.LocalDate;
import java.util.*;

@Service
public class RoomService {

    private final RoomRepository roomRepository;
    private final ReservationService reservationService;

    @Autowired
    public RoomService(RoomRepository roomRepository, ReservationService reservationService) {
        this.roomRepository = roomRepository;
        this.reservationService = reservationService;
    }

    public Room getRoomById(Long roomId) {
        return roomRepository.findById(roomId).get();
    }

    public List<Room> getRoomsAndStatuses() { return roomRepository.findAll(); }

    public List<Room> getRoomsByAvailability(LocalDate date) {
        List<Reservation> reservations = reservationService.getReservations();
        List<Room> availableRooms = new ArrayList<>();

        for (Reservation r : reservations) {
            if (!((r.getStartDate().isBefore(date) || r.getStartDate().isEqual(date)) &&
                (r.getEndDate().isAfter(date) || r.getEndDate().isEqual(date)))) {
                availableRooms.add(getRoomById(r.getRoomId()));
            }
        }

        return availableRooms;
    }
}
