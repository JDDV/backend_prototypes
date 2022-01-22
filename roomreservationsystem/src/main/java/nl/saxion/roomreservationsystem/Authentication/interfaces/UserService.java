package nl.saxion.roomreservationsystem.Authentication;

import org.springframework.stereotype.Service;

import javax.security.auth.message.AuthException;

@Service
public interface UserService {

    User validateUser(String userName, String password, String email) throws EtAuthException;

    User registerUser(String userName, String password) throws EtAuthException;
}
