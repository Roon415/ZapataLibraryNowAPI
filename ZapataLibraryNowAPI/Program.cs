var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
//zapp.Urls.Add($"http://+:{port}");

// Configure the HTTP request pipeline.
 

app.UseSwagger();
app.UseSwaggerUI();


app.MapControllers();
app.Run();

