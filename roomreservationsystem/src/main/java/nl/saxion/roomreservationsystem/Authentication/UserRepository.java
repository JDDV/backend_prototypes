package nl.saxion.roomreservationsystem.Authentication;

import nl.saxion.roomreservationsystem.Authentication.interfaces.UserRepository;
import org.springframework.stereotype.Repository;

@Repository
public class UserRepositoryImpl implements UserRepository {
    @Override
    public Long create(String userName, String password, String email) throws EtAuthException {
        return null;
    }

    @Override
    public User findUserByEmailAndPassword(String userName, String password) throws EtAuthException {
        return null;
    }

    @Override
    public Integer getCountByEmail(String email) {
        return null;
    }

    @Override
    public User findById(Long userId) {
        return null;
    }
}
