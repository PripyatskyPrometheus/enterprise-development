namespace HotelBooking.API.Service;

/// <summary>
/// Интерфейс сервера
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="DTO"></typeparam>
public interface IService<T, DTO>
{
    /// <summary>
    /// Возвращение объекта
    /// </summary>
    /// <returns></returns>
    public IEnumerable<T> GetAll();

    /// <summary>
    /// Возвращение объекта по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public T? GetById(int id);

    /// <summary>
    /// Создание объекта
    /// </summary>
    /// <param name="postDto"></param>
    /// <returns></returns>
    public int Post(DTO postDto);

    /// <summary>
    /// Изменение существующего объекта
    /// </summary>
    /// <param name="putEntity"></param>
    /// <returns></returns>
    public T? Put(T putEntity);

    /// <summary>
    /// Удаление объекта
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id);
}
