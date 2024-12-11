using Innovaria.SW;
using Innovaria.SW.Services;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<IReadMessage,ReadMessage>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();

