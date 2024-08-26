using Infrastructure.Repositories;
using Web.Services;

var dbSettings = new DatabaseSettings
{
    Host = "localhost",
    Port = 8989,
    DatabaseName = "vladzakharo",
    Username = "vladzakharo",
    Password = "4690",
    TrustCertificate = true
};

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
DatabaseService.Instance.AddDbContext(builder.Services, dbSettings);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

app.Run();