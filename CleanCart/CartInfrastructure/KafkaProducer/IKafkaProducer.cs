using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartInfrastructure.KafkaProducer
{
    public interface IKafkaProducer
    {
        Task ProduceMessage(Guid userId, object message);
    }
}
