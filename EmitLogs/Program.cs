using RabbitMQ.Client;

using System.Text;
using System.Threading.Channels;

var factory = new ConnectionFactory { HostName = "localhost", UserName = "DistribtAdmin", Password = "DistribtPass" };

using var connection = await factory.CreateConnectionAsync();
using var channel = await connection.CreateChannelAsync();

await channel.QueueDeclareAsync(queue: "TestWorkService", durable: true, exclusive: false, autoDelete: false);
while (true)
{
    Console.Write("Ingresesa un mensaje:");
    string message = Console.ReadLine();
    if (!string.IsNullOrEmpty(message))
    {
        var body = Encoding.UTF8.GetBytes(message);
        await channel.BasicPublishAsync(exchange: string.Empty, routingKey: "TestWorkService", body: body);
        Console.WriteLine($" [x] Sent {message}");
        message = string.Empty;
    }

}