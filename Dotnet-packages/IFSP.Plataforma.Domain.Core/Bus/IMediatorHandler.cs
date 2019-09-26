using IFSP.Plataforma.Domain.Core.Commands;
using IFSP.Plataforma.Domain.Core.Events;
using System.Threading.Tasks;

namespace IFSP.Plataforma.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
