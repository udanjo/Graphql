using Graphql.WebApi.DependencyInjection;
using Graphql.WebApi.Types;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// GraphQlServer Config
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configura��o de Depend�ncias
IoC.ConfigureContainer(builder.Services, configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL();

app.Run();