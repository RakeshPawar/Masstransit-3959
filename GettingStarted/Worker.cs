using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Hosting;

namespace GettingStarted
{
    public class Worker : BackgroundService
    {
        readonly IBus _bus;

        public Worker(IBus bus)
        {
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var timeoutCancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
                    var composedCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(stoppingToken,
                        timeoutCancellationTokenSource.Token);
                
                    await _bus.Send(new Message { Text = $"The time is {DateTimeOffset.Now}" },
                        composedCancellationTokenSource.Token);

                    await Task.Delay(1000, stoppingToken);
                }
                catch (OperationCanceledException e)
                {
                    Console.WriteLine(e);
                }
              
            }
        }
    }
}