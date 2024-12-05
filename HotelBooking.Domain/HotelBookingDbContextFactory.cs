using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Domain;
public class HotelBookingDbContextFactory : IDesignTimeDbContextFactory<HotelBookingDbContext>
{
    public HotelBookingDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<HotelBookingDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=hotel_booking;Username=postgres;Password=password");
        return new HotelBookingDbContext(optionsBuilder.Options);
    }
}