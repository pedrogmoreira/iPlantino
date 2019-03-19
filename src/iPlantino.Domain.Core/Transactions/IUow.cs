using iPlantino.Domain.Core.Commands;
using System.Threading.Tasks;

namespace iPlantino.Domain.Core.Transactions
{
    public interface IUow
    {
        Task<CommandResponse> Commit();
    }
}
