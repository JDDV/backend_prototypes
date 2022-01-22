package nl.saxion.roomreservationsystem.Authentication;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

@ResponseStatus(HttpStatus.UNAUTHORIZED)
public class EtAutchException extends RuntimeException{

    public EtAutchException(String message) {
        super(message);
    }
}
