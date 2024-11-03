﻿namespace HotelBooking.API.Dto;

/// <summary>
/// Класс DTO для метода POST для паспорта
/// </summary>
public class PassportPostDto
{
    /// <summary>
    /// Идентификатор паспорта
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Серия
    /// </summary>
    public required int Series { get; set; }

    /// <summary>
    /// Номер
    /// </summary>
    public required int Number { get; set; }
}