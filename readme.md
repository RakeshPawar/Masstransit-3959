- Used Sample getting started from masstranist to reproduce issue.
- Please agjust rabbitmq settings in program as per the local setup
- Following exception received and yet message was processed.

```
fail: MassTransit[0]
      S-FAULT rabbitmq://localhost/message?bind=true 205d0000-6280-60f2-a266-08dae2f863cf GettingStarted.Message
      System.OperationCanceledException: The operation was canceled.
         at MassTransit.Internals.TaskExtensions.<>c__DisplayClass1_0.<<OrCanceled>g__WaitAsync|0>d.MoveNext() in /_/src/MassTransit.Abstractions/Internals/Extensions/TaskExtensions.cs:line 28
      --- End of stack trace from previous location ---
         at MassTransit.RabbitMqTransport.RabbitMqSendTransport.SendPipe`1.Send(ModelContext modelContext) in /_/src/Transports/MassTransit.RabbitMqTransport/RabbitMqTransport/RabbitMqSendTransport.cs:line 153
System.OperationCanceledException: The operation was canceled.
   at MassTransit.Internals.TaskExtensions.<>c__DisplayClass1_0.<<OrCanceled>g__WaitAsync|0>d.MoveNext() in /_/src/MassTransit.Abstractions/Internals/Extensions/TaskExtensions.cs:line 28
--- End of stack trace from previous location ---
   at MassTransit.RabbitMqTransport.RabbitMqSendTransport.SendPipe`1.Send(ModelContext modelContext) in /_/src/Transports/MassTransit.RabbitMqTransport/RabbitMqTransport/RabbitMqSendTransport.cs:line 153
   at MassTransit.RabbitMqTransport.RabbitMqSendTransport.SendPipe`1.Send(ModelContext modelContext) in /_/src/Transports/MassTransit.RabbitMqTransport/RabbitMqTransport/RabbitMqSendTransport.cs:line 168
   at MassTransit.Agents.PipeContextSupervisor`1.MassTransit.IPipeContextSource<TContext>.Send(IPipe`1 pipe, CancellationToken cancellationToken) in /_/src/MassTransit/Agents/PipeContextSupervisor.cs:line 57
   at MassTransit.Agents.PipeContextSupervisor`1.MassTransit.IPipeContextSource<TContext>.Send(IPipe`1 pipe, CancellationToken cancellationToken) in /_/src/MassTransit/Agents/PipeContextSupervisor.cs:line 63
   at MassTransit.Agents.PipeContextSupervisor`1.MassTransit.IPipeContextSource<TContext>.Send(IPipe`1 pipe, CancellationToken cancellationToken) in /_/src/MassTransit/Agents/PipeContextSupervisor.cs:line 69
   at MassTransit.Transports.HostConfigurationRetryExtensions.Retry(IHostConfiguration hostConfiguration, Func`1 factory, ISupervisor supervisor, CancellationToken cancellationToken) in /_/src/MassTransit/Transports/HostConfiguratio
nRetryExtensions.cs:line 37
   at MassTransit.EndpointConventionExtensions.Send[T](ISendEndpointProvider provider, T message, CancellationToken cancellationToken) in /_/src/MassTransit/EndpointConventionExtensions.cs:line 27
   at GettingStarted.Worker.ExecuteAsync(CancellationToken stoppingToken) in C:\Rakesh\Repo\MassTransit\Sample-GettingStarted\GettingStarted\Worker.cs:line 28

```