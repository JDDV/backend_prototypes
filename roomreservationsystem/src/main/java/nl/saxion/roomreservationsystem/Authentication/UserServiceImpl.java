package nl.saxion.roomreservationsystem.Authentication.interfaces;

import nl.saxion.roomreservationsystem.Authentication.EtAuthException;
import nl.saxion.roomreservationsystem.Authentication.User;

public class UserServiceImpl implements UserService {


    @Override
    public User validateUser(String userName, String password, String email) throws EtAuthException {
        return null;
    }

    @Override
    public User registerUser(String userName, String password) throws EtAuthException {
        return null;
    }
}
