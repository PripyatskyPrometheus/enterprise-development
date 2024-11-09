namespace HotelBooking.API.Repository;

/// <summary>
/// Интерфейс базовых методов доступа к данным
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T>
{
    /// <summary>
    /// Получение всех объектов
    /// </summary>
    /// <returns></returns>
    public IEnumerable<T> GetAll();

    /// <summary>
    /// Получение объекта по идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public T? GetById(int id);

    /// <summary>
    /// Создание объекта
    /// </summary>
    /// <param name="entity"></param>
    public void Post(T entity);

    /// <summary>
    /// Изменение объекта
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Put(T entity, int id);

    /// <summary>
    /// Удаление объекта
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id);
}
