using HotelBooking.API;
using HotelBooking.API.Repository;
using HotelBooking.API.Service;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddSingleton<HotelBookingDbContext>();

builder.Services.AddSingleton<HotelRepository>();
builder.Services.AddSingleton<RoomRepository>();
builder.Services.AddSingleton<RoomTypeRepository>();
builder.Services.AddSingleton<PassportRepository>();
builder.Services.AddSingleton<ClientRepository>();
builder.Services.AddSingleton<BookedRoomRepository>();

builder.Services.AddSingleton<HotelService>();
builder.Services.AddSingleton<RoomService>();
builder.Services.AddSingleton<RoomTypeService>();
builder.Services.AddSingleton<PassportService>();
builder.Services.AddSingleton<ClientService>();
builder.Services.AddSingleton<BookedRoomService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
