using HotelBooking.API;
using HotelBooking.API.Repository;
using HotelBooking.Domain.Entity;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddSingleton<IRepository<Hotel>, HotelRepository>();
builder.Services.AddSingleton<IRepository<Room>, RoomRepository>();
builder.Services.AddSingleton<IRepository<RoomType>, RoomTypeRepository>();
builder.Services.AddSingleton<IRepository<Passport>, PassportRepository>();
builder.Services.AddSingleton<IRepository<Client>, ClientRepository>();
builder.Services.AddSingleton<IRepository<BookedRoom>, BookedRoomRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();