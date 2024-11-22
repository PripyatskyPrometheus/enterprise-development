﻿using HotelBooking.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Domain;

public class HotelBookingContext(DbContextOptions<HotelBookingContext> options) : DbContext(options)
{
    /// <summary>
    /// Таблица отелей
    /// </summary>
    public DbSet<Hotel> Hotels { get; set; }

    /// <summary>
    /// Таблица
    /// </summary>
    public DbSet<RoomType> RoomsType { get; set; }

    /// <summary>
    /// Таблица номеров
    /// </summary>
    public DbSet<Room> Rooms { get; set; }

    /// <summary>
    /// Таблица номеров
    /// </summary>
    public DbSet<Passport> Passports { get; set; }

    /// <summary>
    /// HotelClient table
    /// </summary>
    public DbSet<Client> Clients { get; set; }

    /// <summary>
    /// BookedRoom table
    /// </summary>
    public DbSet<BookedRoom> BookedRooms { get; set; }

    /// <summary>
    /// Overriding the method for establishing relationships between tables
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Связь между Room и Hotel
        modelBuilder.Entity<Room>()
            .HasOne(r => r.Hotel)
            .WithMany()
            .HasForeignKey(r => r.HotelId);

        // Связь между BookedRoom и Client
        modelBuilder.Entity<BookedRoom>()
            .HasOne(br => br.Client)
            .WithMany()
            .HasForeignKey(br => br.ClientId);

        // Связь между BookedRoom и Room
        modelBuilder.Entity<BookedRoom>()
            .HasOne(br => br.Room)
            .WithMany()
            .HasForeignKey(br => br.RoomId);

        // Связь между Client и Passport
        modelBuilder.Entity<Client>()
            .HasOne(c => c.PassportData)
            .WithMany()
            .HasForeignKey(c => c.PassportId);

        // Связь между Room и RoomType
        modelBuilder.Entity<Room>()
            .HasOne(r => r.Type)
            .WithMany()
            .HasForeignKey(r => r.TypeId);
    }
}