package nl.saxion.roomreservationsystem.room;

import org.springframework.boot.CommandLineRunner;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import java.util.List;

@Configuration
public class RoomConfig {

    @Bean
    CommandLineRunner roomCommandLineRunner(RoomRepository roomRepository){
        return args -> {
            Room roomOne = new Room("Room One");
            Room roomTwo = new Room("Room Two");
            Room roomThree = new Room("Room Three");
            Room roomFour = new Room("Room Four");
            Room roomFive = new Room("Room Five");

            roomRepository.saveAll(List.of(roomOne,roomTwo,roomThree,roomFour,roomFive));
        };
    }
}
