﻿// <auto-generated />
using System;
using HotelBooking.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HotelBooking.Domain.Migrations
{
    [DbContext(typeof(HotelBookingDbContext))]
    partial class HotelBookingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HotelBooking.Domain.Entity.BookedRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("integer")
                        .HasColumnName("ClientId");

                    b.Property<DateOnly>("DateArrival")
                        .HasColumnType("date")
                        .HasColumnName("DateArrival");

                    b.Property<DateOnly>("DateEvection")
                        .HasColumnType("date")
                        .HasColumnName("DateEvection");

                    b.Property<int>("PeriodInDays")
                        .HasColumnType("integer")
                        .HasColumnName("PeriodInDays");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer")
                        .HasColumnName("RoomId");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("RoomId");

                    b.ToTable("BookedRoom");
                });

            modelBuilder.Entity("HotelBooking.Domain.Entity.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("BirthOfDay")
                        .HasColumnType("date")
                        .HasColumnName("BirthOfDay");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("FullName");

                    b.Property<int>("PassportId")
                        .HasColumnType("integer")
                        .HasColumnName("PassportId");

                    b.HasKey("Id");

                    b.HasIndex("PassportId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("HotelBooking.Domain.Entity.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("City");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("HotelBooking.Domain.Entity.Passport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Number")
                        .HasColumnType("integer")
                        .HasColumnName("Number");

                    b.Property<int>("Series")
                        .HasColumnType("integer")
                        .HasColumnName("Series");

                    b.HasKey("Id");

                    b.ToTable("Passport");
                });

            modelBuilder.Entity("HotelBooking.Domain.Entity.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("integer")
                        .HasColumnName("Capacity");

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric")
                        .HasColumnName("Cost");

                    b.Property<int>("HotelId")
                        .HasColumnType("integer")
                        .HasColumnName("HotelId");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer")
                        .HasColumnName("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("TypeId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("HotelBooking.Domain.Entity.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("TypeName");

                    b.HasKey("Id");

                    b.ToTable("RoomType");
                });

            modelBuilder.Entity("HotelBooking.Domain.Entity.BookedRoom", b =>
                {
                    b.HasOne("HotelBooking.Domain.Entity.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelBooking.Domain.Entity.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HotelBooking.Domain.Entity.Client", b =>
                {
                    b.HasOne("HotelBooking.Domain.Entity.Passport", "PassportData")
                        .WithMany()
                        .HasForeignKey("PassportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PassportData");
                });

            modelBuilder.Entity("HotelBooking.Domain.Entity.Room", b =>
                {
                    b.HasOne("HotelBooking.Domain.Entity.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelBooking.Domain.Entity.RoomType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Type");
                });
#pragma warning restore 612, 618
        }
    }
}
