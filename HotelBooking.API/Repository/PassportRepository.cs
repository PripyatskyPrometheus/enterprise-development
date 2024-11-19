using HotelBooking.Domain.Entity;

namespace HotelBooking.API.Repository;

public class PassportRepository : IRepository<Passport>
{
    private readonly List<Passport> _passports = [];
    private int _passportId = 0;

    public IEnumerable<Passport> GetAll() => _passports;

    public Passport? GetById(int id) => _passports.Find(x => x.Id == id);

    public Passport Post(Passport entity)
    {
       entity.Id = ++_passportId;
       _passports.Add(entity);
        return entity;  
    }

    public Passport? Put(Passport entity, int id)
    {
        var oldValue = GetById(id);
        if (oldValue == null)
            return oldValue;
        oldValue.Series = entity.Series;
        oldValue.Number = entity.Number;
        return oldValue;
    }

    public bool Delete(int id)
    {
        var passport = GetById(id);
        if (passport == null)
            return false;
        _passports.Remove(passport);
        return true;
    }
}