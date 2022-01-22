package nl.saxion.roomreservationsystem.Authentication.role;
import java.util.Optional;

import nl.saxion.roomreservationsystem.Authentication.Role;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface RoleRepository extends JpaRepository<Role, Long> {
    Optional<Role> findByName(ERole name);
}