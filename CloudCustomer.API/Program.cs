using CloudCustomer.API.Data;
using CloudCustomer.API.Services;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Building a .NET 6 API Using TDD https://www.youtube.com/watch?v=ULJ3UEezisw&t=1556s

//YH Add local services for injection
ConfigureServices(builder.Services);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<yhApiContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("yhApiContext");
    Console.WriteLine($"AddDbContext() connectionString={connectionString}");
    if (connectionString != null)
    {
        options.UseMySQL(connectionString);
    }
    //  options.UseMy(builder.Configuration.GetConnectionString("yhApiContext")));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Create the tables in the database if not already existings
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<yhApiContext>();
    context.Database.EnsureCreated();

    //Seed the database
    //DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<IUsersService, UsersService>();
    services.AddHttpClient<IUsersService, UsersService>();  //User service should get an injection of http client
}
