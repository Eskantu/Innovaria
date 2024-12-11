using RabbitMQ.Client.Events;
using RabbitMQ.Client;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovaria.SW.Services
{
    public class ReadMessage : IReadMessage
    {
        public void Read()
        {
            // definition of Connection 
            var _rabbitMQServer = new ConnectionFactory() { HostName = "localhost", Password = "DistribtPass", UserName = "DistribtAdmin" };

            // create connection
             var connection = _rabbitMQServer.CreateConnectionAsync().Result;

            // create channel
            var channel = connection.CreateChannelAsync().Result;

            StartReading(channel, "TestWorkService");
        }

        private void StartReading(IChannel channel, string queueName)
        {

            // Consumer definition
            var consumer = new AsyncEventingBasicConsumer(channel);

            // Definition of event when the Consumer gets a message
            consumer.ReceivedAsync += (sender, e) =>
            {
                ManageMessage(e);
                //channel.BasicAckAsync(e.DeliveryTag, true);
                return Task.CompletedTask;
            };

            // Start pushing messages to our consumer
            channel.BasicConsumeAsync(queueName, true, consumer);
            Console.WriteLine("Consumer is running");
            Console.ReadLine();
        }

        private void ManageMessage(BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine(message);

            using StreamWriter file = new("MessagesRead.txt", append: true);
            file.WriteLine(message);
        }
    }
}
