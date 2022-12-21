using System;
using System.Threading.Tasks;
using MassTransit;

namespace GettingStarted
{
    public class DelaySendFilter<T> : IFilter<SendContext<T>> where T : class
    {
        public async Task Send(SendContext<T> context, IPipe<SendContext<T>> next)
        {
            // simulating long running task
            await Task.Delay(TimeSpan.FromSeconds(20));
            await next.Send(context).ConfigureAwait(false);
        }

        public void Probe(ProbeContext context)
        {
            context.CreateFilterScope("DelaySendFilter");
        }
    }
}