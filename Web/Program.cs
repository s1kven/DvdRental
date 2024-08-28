using Carter;
using Infrastructure.Helpers;
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
builder.Services.AddCarter();
DatabaseService.Instance.AddDbContext(builder.Services, dbSettings);

var app = builder.Build();

app.UseExceptionHandler(exceptionHandlerApp 
    => exceptionHandlerApp.Run(async context 
        => await Results.Problem()
            .ExecuteAsync(context)));

app.UseExceptionHandleMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapCarter();

app.Run();