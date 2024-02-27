using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OrderApplication.Interfaces;
using OrderDomain.Entities;
using OrderInfrastructure.KafkaConfiguration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderInfrastructure.KafkaConsumers
{

    public class KafkaConsumer
    {
        private readonly IConsumer<string, string> _consumer;
        private readonly IServiceScopeFactory _serviceScope;
        private readonly string _topic;
        public KafkaConsumer(IOptions<KafkaSettings> kafkaConfig, IServiceScopeFactory serviceScope)
        {
            var config = new ConsumerConfig
            {
                GroupId = "order-group-newest",
                BootstrapServers = kafkaConfig.Value.BootstrapServers,
                SaslUsername = kafkaConfig.Value.SaslUsername,
                SaslPassword = kafkaConfig.Value.SaslPassword,
                SaslMechanism = SaslMechanism.Plain,
                SecurityProtocol = SecurityProtocol.SaslSsl,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = false
            };
            _consumer = new ConsumerBuilder<string, string>(config).Build();
            _topic = kafkaConfig.Value.TopicName ?? throw new Exception("Error: Kafka is null");
            _serviceScope = serviceScope;
            _consumer.Subscribe(_topic);
        }
        public async Task ExecuteAsync(CancellationToken tok)
        {
            Log.Information("Entered the ExecuteAsync function");

            try
            {
                while (!tok.IsCancellationRequested)
                {
                    Log.Information("Entered the while loop of ExecuteAsync function");
                    await Task.Yield();
                    using (var scope = _serviceScope.CreateScope())
                    {
                        var orderService = scope.ServiceProvider.GetRequiredService<IOrderRepository>();

                        try
                        {
                            var consumeResult = await Task.Run(() => _consumer.Consume(tok), tok);

                            if (consumeResult != null && consumeResult.Message != null)
                            {
                                Log.Information("Received message: {Message}", consumeResult.Message.Value);

                                dynamic? consumerMessage = JsonConvert.DeserializeObject(consumeResult.Message.Value);

                                if (consumerMessage != null)
                                {
                                    List<Products> productsList = consumerMessage.orderDetails.ToObject<List<Products>>();
                                    Orders _order = new Orders
                                    {
                                        UserId = consumerMessage.userId,
                                        Products = productsList,
                                    };

                                    Log.Information("Deserialized order: {Order}", _order);

                                    orderService.AddOrder(_order);
                                    Log.Information("Order added");
                                    _consumer.Commit();
                                }
                            }
                        }
                        catch (ConsumeException e)
                        {
                            Log.Error("Error consuming message: {ErrorMessage}", e.Error.Reason);
                        }
                    }
                }
            }
            finally
            {
                Log.Information("Closing the consumer");
                _consumer.Close();
            }
        }


    }
}
