using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using System.Text;

string routing = "";

while (routing == "")
{
    Console.WriteLine("Ingrese severity separados por espacios (info, warning, error):");
    routing = Console.ReadLine();
}

var factory = new ConnectionFactory { HostName = "localhost", UserName = "DistribtAdmin", Password = "DistribtPass" };

using var connection = await factory.CreateConnectionAsync();
using var channel = await connection.CreateChannelAsync();

await channel.ExchangeDeclareAsync(exchange: "direct_logs", type: ExchangeType.Direct);

QueueDeclareOk queueDeclareResult = await channel.QueueDeclareAsync();
string queueName = queueDeclareResult.QueueName;

foreach (var item in routing.Split(' '))
{
    await channel.QueueBindAsync(queue: queueName, exchange: "direct_logs", routingKey: item);

}

Console.WriteLine(" [*] Waiting for logs.");

var consumer = new AsyncEventingBasicConsumer(channel);
consumer.ReceivedAsync += (model, ea) =>
{
    byte[] body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    var routingKey = ea.RoutingKey;
    Console.WriteLine($" [x] Received '{routingKey}':'{message}'");
    return Task.CompletedTask;
};

await channel.BasicConsumeAsync(queueName, autoAck: true, consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();