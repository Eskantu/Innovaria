using RabbitMQ.Client;

using System.Text;
using System.Threading.Channels;

var factory = new ConnectionFactory { HostName = "localhost", UserName = "DistribtAdmin", Password = "DistribtPass" };

using var connection = await factory.CreateConnectionAsync();
using var channel = await connection.CreateChannelAsync();

//await channel.QueueDeclareAsync(queue: "TestWorkService", durable: true, exclusive: false, autoDelete: false);
while (true)
{
    Console.Write("Ingresa el mensaje: ");

    string message = Console.ReadLine();
    var body = Encoding.UTF8.GetBytes(message);

    await channel.BasicPublishAsync(exchange: "TestWorkService-exchange", routingKey: "TestWorkService", body: body,mandatory:true, basicProperties: new BasicProperties { });
    
    Console.WriteLine($" [x] Sent {message}");
}
