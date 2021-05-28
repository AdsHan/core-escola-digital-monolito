using MinhaEscolaDigital.Domain.Enums;
using System;

namespace MinhaEscolaDigital.Domain.DomainObjects
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DataInclusao { get; private set; }
        public EntityStatusEnum Status { get; set; }

        protected BaseEntity()
        {
            DataInclusao = DateTime.Now;
            Status = EntityStatusEnum.Ativa;
        }

        public void Excluir()
        {
            if (Status == EntityStatusEnum.Ativa)
            {
                Status = EntityStatusEnum.Inativa;
            }
        }
    }
}