using HotelBooking.API.Dto;

namespace HotelBooking.API.Repository;

public class PassportRepository(HotelBookingDbContext context) : IRepository<PassportGetDto>
{
    /// <inheritdoc />
    public IEnumerable<PassportGetDto> GetAll() => context.Passports;

    /// <inheritdoc />
    public PassportGetDto? GetById(int id) => context.Passports.Find(x => x.Id == id);

    /// <inheritdoc />
    public int Post(PassportGetDto passport)
    {
        int newId = context.Passports.Count > 0 ? context.Passports.Max(h => h.Id) + 1 : 1;
        passport.Id = newId;
        context.Passports.Add(passport);
        return newId;
    }

    /// <inheritdoc />
    public bool Put(PassportGetDto passport)
    {
        var oldValue = GetById(passport.Id);

        if (oldValue == null)
            return false;

        oldValue.Series = passport.Series;
        oldValue.Number = passport.Number;

        return true;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        var passport = GetById(id);
        if (passport == null)
            return false;
        _ = context.Passports.Remove(passport);
        return true;
    }
}