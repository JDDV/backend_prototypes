package nl.saxion.roomreservationsystem.room;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.format.annotation.DateTimeFormat;
import org.springframework.web.bind.annotation.*;

import java.time.LocalDate;
import java.util.List;

@RestController
@RequestMapping(path = "/api/room")
public class RoomController {

    private final RoomService roomService;

    @Autowired
    public RoomController(RoomService roomService) {
        this.roomService = roomService;
    }

    @GetMapping
    public List<Room> getRooms() {
        return roomService.getRoomsAndStatuses();
    }

    @GetMapping("/availability/{date}")
    public List<Room> getAvailableRooms(@PathVariable @DateTimeFormat(pattern = "yyyy-MM-dd") LocalDate date) { return roomService.getRoomsByAvailability(date); }
}
