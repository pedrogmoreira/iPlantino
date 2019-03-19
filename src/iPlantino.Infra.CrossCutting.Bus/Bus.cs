using iPlantino.Domain.Core.Events;
using MediatR;
using System.Threading.Tasks;

namespace iPlantino.Infra.CrossCutting.Bus
{
    public abstract class Bus
    {
        private readonly IMediator _mediator;

        protected Bus(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected Task Publish<Tevent>(Tevent message) where Tevent : Message
        {
            return _mediator.Publish(message);
        }

        protected Task<TResponse> Send<TResponse>(IRequest<TResponse> command)
        {
            return _mediator.Send(command);
        }
    }
}
