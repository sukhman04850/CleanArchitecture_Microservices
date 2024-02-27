using CartInfrastructure.KafkaConfiguration;
using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartInfrastructure.KafkaProducer
{
    public class KafkaProducer : IKafkaProducer
    {
        private readonly IProducer<Null, string> _producer;
        private readonly string _topic;
        public KafkaProducer(IOptions<KafkaSettings> kafkaConfig)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = kafkaConfig.Value.BootstrapServers,

                SaslMechanism = SaslMechanism.Plain,
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslUsername = kafkaConfig.Value.SaslUsername,
                SaslPassword = kafkaConfig.Value.SaslPassword
            };
            Console.WriteLine(kafkaConfig.Value.SaslPassword);
            Console.WriteLine(kafkaConfig.Value.SaslUsername);

            _producer = new ProducerBuilder<Null, string>(config).Build();
            _topic = kafkaConfig.Value.TopicName ?? throw new Exception("Error: Topic Is Null");
        }

        public async Task ProduceMessage(Guid userId, object message)
        {
            try
            {
                var messageWithUserId = new Dictionary<string, object>
            {
              { "userId", userId },
              { "orderDetails", message }
            };
                var serializedMessage = JsonConvert.SerializeObject(messageWithUserId);
                var response = await _producer.ProduceAsync(_topic, new Message<Null, string> { Value = serializedMessage });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }
    }
}
