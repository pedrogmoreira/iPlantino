using iPlantino.Domain.Core.Bus;
using iPlantino.Domain.Core.Commands;
using iPlantino.Domain.Core.Events;
using MediatR;
using System.Threading.Tasks;

namespace iPlantino.Infra.CrossCutting.Bus
{
    public class InMemoryBus : Bus, IMediatorHandler
    {
        public InMemoryBus(IMediator mediator) : base(mediator)
        {
        }

        public async Task PublishCommand<T>(T command) where T : Command
        {
            await Publish(command);
        }

        public Task PublishMessage<T>(T command) where T : Message
        {
            return Publish(command);
        }

        public async Task RaiseEvent<T>(T @event) where T : Event
        {
            await Publish(@event);
        }

        public async Task<TResponse> SendCommand<TResponse>(IRequest<TResponse> request)
        {
            return await Send(request);
        }
    }
}
