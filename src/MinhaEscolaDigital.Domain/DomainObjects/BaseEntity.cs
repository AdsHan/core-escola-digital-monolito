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
            Id = Guid.NewGuid();
            DataInclusao = DateTime.Now;
            Status = EntityStatusEnum.Created;
        }

    }
}