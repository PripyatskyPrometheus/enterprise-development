using HotelBooking.Domain.Entity;

/// <summary>
/// Класс DTO для метода POST для клиента
/// </summary>
namespace HotelBooking.API.Dto
{
    public class ClientPostDto
    {
        /// <summary>
        /// Идентификатор клиента
        /// </summary>
        public required int Id { get; set; }

        /// <summary>
        /// ФИО 
        /// </summary>
        public required string FullName { get; set; }

        /// <summary>
        /// Паспорт
        /// </summary>
        public required PassportPostDto PassportData { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public required DateOnly BirthOfDay { get; set; }
    }
}
