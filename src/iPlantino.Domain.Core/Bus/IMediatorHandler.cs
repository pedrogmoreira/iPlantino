using iPlantino.Domain.Core.Commands;
using iPlantino.Domain.Core.Events;
using MediatR;
using System.Threading.Tasks;

namespace iPlantino.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task PublishCommand<T>(T command) where T : Command;

        Task PublishMessage<T>(T message) where T : Message;

        Task<TResponse> SendCommand<TResponse>(IRequest<TResponse> command);

        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
