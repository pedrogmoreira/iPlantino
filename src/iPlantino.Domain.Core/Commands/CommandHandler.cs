using iPlantino.Domain.Core.Bus;
using iPlantino.Domain.Core.Notifications;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace iPlantino.Domain.Core.Commands
{
    public abstract class CommandHandler : Notifiable
    {
        private readonly Microsoft.EntityFrameworkCore.IUnitOfWork _uow;

        protected CommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(bus, notifications)
        {
            _uow = uow;
        }

        protected virtual async Task<CommandResponse> Commit()
        {
            if (!IsValid())
            {
                return CommandResponse.Fail;
            }

            var commandResponse = (await _uow.SaveChangesAsync()) > 0;

            if (!commandResponse)
            {
                await Notify("Commit", "Tivemos um problema ao salvar");
            }

            return new CommandResponse(commandResponse);
        }
    }
}
