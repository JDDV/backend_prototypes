package nl.saxion.roomreservationsystem.reservation;

import nl.saxion.roomreservationsystem.Authentication.user.UserRepository;
import nl.saxion.roomreservationsystem.room.Room;
import nl.saxion.roomreservationsystem.room.RoomRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class ReservationService {

    private final ReservationRepository reservationRepository;
    private final RoomRepository roomRepository;
    private final UserRepository userRepository;

    @Autowired
    public ReservationService(ReservationRepository reservationRepository, RoomRepository roomRepository, UserRepository userRepository) {
        this.reservationRepository = reservationRepository;
        this.roomRepository = roomRepository;
        this.userRepository = userRepository;
    }

    public List<Reservation> getReservations() {
        return reservationRepository.findAll();
    }

    public Reservation getReservationById(Long id) {
        return reservationRepository.findById(id).get();
    }

    public ResponseEntity<Reservation> addReservation(Reservation reservation) throws Exception {

        if (reservation.getStartDate().isAfter(reservation.getEndDate())) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }

        if (!userRepository.existsByUsername(reservation.getUsername())){
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }

        Room room = roomRepository.getById(reservation.getRoomId());
        room.addRoomReservations(reservation);
        return ResponseEntity.ok(reservationRepository.save(reservation));
    }

    public ResponseEntity<Object> deleteReservation(Long id) {
        List<Reservation> reservations = getReservations();

        for(Reservation r : reservations){
            if (r.getId() == id){
                reservationRepository.delete(r);
                return new ResponseEntity<>(HttpStatus.OK);
            }
        }
        return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
    }

    public Reservation updateReservation(Reservation reservationFromBody, Long id) {
        Reservation reservation = getReservationById(id);

        reservation.setStartDate(reservationFromBody.getStartDate() != null ? reservationFromBody.getStartDate() : reservation.getStartDate());
        reservation.setEndDate(reservationFromBody.getEndDate() != null ? reservationFromBody.getEndDate() : reservation.getEndDate());
        reservation.setUsername(reservationFromBody.getUsername() != null ? reservationFromBody.getUsername() : reservation.getUsername());
        reservation.setRoomId(reservationFromBody.getRoomId() != null ? reservationFromBody.getRoomId() : reservation.getRoomId());


       return reservationRepository.save(reservation);
    }
}
