using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaEscolaDigital.Domain.Repositories
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        Task<T> ObterPorIdAsync(Guid id);
        Task<List<T>> ObterTodosAsync();
        void AdicionarAsync(T obj);
        Task SalvarAsync();
    }
}