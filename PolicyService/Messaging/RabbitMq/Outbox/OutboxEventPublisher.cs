using NHibernate;
using System.Threading.Tasks;

namespace PolicyService.Messaging.RabbitMq.Outbox
{
    public class OutboxEventPublisher : IEventPublisher
    {
        private readonly NHibernate.ISession session;

        public OutboxEventPublisher(NHibernate.ISession session)
        {
            this.session = session;
        }

        public async Task PublishMessage<T>(T msg)
        {
            await session.SaveAsync(new Message(msg));
        }
    }
}
