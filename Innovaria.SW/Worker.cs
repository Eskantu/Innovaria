
using Innovaria.SW.Services;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Channels;

namespace Innovaria.SW
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        IReadMessage _consumerService;
        public Worker(ILogger<Worker> logger, IReadMessage message)
        {
            _logger = logger;

            _consumerService = message;


        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Run(() =>
                {
                    _consumerService.Read();
                });
            }
        }
    }
}
