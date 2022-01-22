using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoomReservation.Authentication;
using RoomReservation.Models;

namespace RoomReservation.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt)
        {
         
        }
        public DbSet<RoomReservations> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<RoomReservations>().HasOne(r => r.User).WithMany()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}