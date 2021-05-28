using MinhaEscolaDigital.API.Application.ApplicationObjects;
using MinhaEscolaDigital.API.Application.Messages.Commands;
using System.Threading.Tasks;

namespace MinhaEscolaDigital.API.Application.Messages.Mediator
{
    public interface IMediatorHandler
    {
        Task<BaseResult> EnviarComando<T>(T comando) where T : Command;
        Task<object> EnviarQuery<T>(T query);
    }
}