using MinhaEscolaDigital.Domain.DomainObjects;

namespace MinhaEscolaDigital.Domain.Entities
{
    public class Observacao : BaseEntity
    {
        public string Texto { get; private set; }

        public Observacao(string texto)
        {
            Texto = texto;
        }
        public void Atualizar(string texto)
        {
            Texto = texto;
        }
    }

}
