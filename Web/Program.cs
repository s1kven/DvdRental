using Carter;
using Persistence.Config;
using Web.Extensions;
using Web.Middlewares;
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
builder.Services.AddDbContext(dbSettings);

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