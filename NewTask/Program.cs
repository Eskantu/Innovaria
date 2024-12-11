using RabbitMQ.Client;

using System.Text;

var factory = new ConnectionFactory { HostName = "localhost", UserName = "DistribtAdmin", Password = "DistribtPass" };

using var connection = await factory.CreateConnectionAsync();
using var channel = await connection.CreateChannelAsync();

await channel.QueueDeclareAsync(queue: "task_queue", durable: true, exclusive: false, autoDelete: false);
while (true)
{
    Console.Write("Ingresesa un mensaje:");
    string message = Console.ReadLine();
    if (!string.IsNullOrEmpty(message))
    {
        var body = Encoding.UTF8.GetBytes(message);

        await channel.BasicPublishAsync(exchange: string.Empty, routingKey: "task_queue", body: body, basicProperties: new BasicProperties { Persistent=true }, mandatory:true);
        Console.WriteLine($" [x] Sent {message}");
    }

}