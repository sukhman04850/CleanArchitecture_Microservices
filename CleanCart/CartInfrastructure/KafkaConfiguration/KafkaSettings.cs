using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartInfrastructure.KafkaConfiguration
{
    public class KafkaSettings
    {
        public required string BootstrapServers { get; set; }
        public required string TopicName { get; set; }
        public required string SaslUsername { get; set; }
        public required string SaslPassword { get; set; }
    }
}
