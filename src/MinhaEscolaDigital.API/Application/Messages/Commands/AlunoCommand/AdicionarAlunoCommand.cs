﻿using FluentValidation;
using MinhaEscolaDigital.API.Application.DTO;
using System;
using System.Collections.Generic;

namespace MinhaEscolaDigital.API.Application.Messages.Commands.AlunoCommand
{

    public class AdicionarAlunoCommand : Command
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Observacao { get; set; }
        public Guid TurmaId { get; set; }
        public List<ResponsavelDTO> Responsaveis { get; set; }
        public EnderecoDTO Endereco { get; set; }
        public override bool Validar()
        {
            BaseResult.ValidationResult = new AdicionarAlunoValidation().Validate(this);
            return BaseResult.ValidationResult.IsValid;
        }

        public class AdicionarAlunoValidation : AbstractValidator<AdicionarAlunoCommand>
        {
            public AdicionarAlunoValidation()
            {
                RuleFor(c => c.Nome)
                    .NotEmpty()
                    .WithMessage("O nome do aluno não foi informado");

                RuleFor(c => c.Nome)
                    .MaximumLength(200)
                    .WithMessage("Tamanho máximo do nome é de 200 caracteres.");

                RuleFor(c => c.Observacao)
                    .MaximumLength(8000)
                    .WithMessage("Tamanho máximo da observação é de 8000 caracteres.");

                RuleFor(c => c.Cpf)
                    .Must(TerCpfValido)
                    .WithMessage("O CPF informado não é válido.");

                RuleFor(c => c.Rg)
                    .Must(TerRgValido)
                    .WithMessage("O RG informado não é válido.");

            }

            protected static bool TerCpfValido(string cpf)
            {
                return Domain.DomainObjects.Cpf.Validar(cpf);
            }

            protected static bool TerRgValido(string Rg)
            {
                return Domain.DomainObjects.Rg.Validar(Rg);
            }
        }
    }
}