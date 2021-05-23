using FluentValidation.Results;
using MediatR;
using MinhaEscolaDigital.Domain.Entities;
using MinhaEscolaDigital.Domain.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MinhaEscolaDigital.API.Application.Messages.Commands.AlunoCommand
{
    public class AlunoCommandHandler : CommandHandler,
        IRequestHandler<AdicionarAlunoCommand, ValidationResult>,
        IRequestHandler<AlterarEnderecoAlunoCommand, ValidationResult>
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoCommandHandler(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<ValidationResult> Handle(AdicionarAlunoCommand command, CancellationToken cancellationToken)
        {
            if (!command.Validar()) return command.ValidationResult;

            var alunoExistente = await _alunoRepository.ObterPorCpfAsync(command.Cpf);

            if (alunoExistente != null)
            {
                AdicionarErro("Este CPF já está em uso por outro aluno!");
                return ValidationResult;
            }

            var endereco = new Endereco(command.Endereco.Logradouro, command.Endereco.Numero, command.Endereco.Complemento, command.Endereco.Bairro, command.Endereco.Cep, command.Endereco.Cidade, command.Endereco.Estado);

            var responsaveis = command.Responsaveis.Select(r => new Responsavel(r.Nome, r.DataNascimento, r.Rg, r.Cpf, r.Telefone, r.Celular, r.Email, r.Observacao)).ToList();

            var aluno = new Aluno(command.Nome, command.DataNascimento, command.Rg, command.Cpf, command.Observacao, command.TurmaId, responsaveis);

            aluno.AtribuirEndereco(endereco);

            _alunoRepository.Adicionar(aluno);

            await _alunoRepository.SalvarAsync();

            return ValidationResult;
        }

        public async Task<ValidationResult> Handle(AlterarEnderecoAlunoCommand command, CancellationToken cancellationToken)
        {
            if (!command.Validar()) return command.ValidationResult;

            var endereco = new Endereco(command.Logradouro, command.Numero, command.Complemento, command.Bairro, command.Cep, command.Cidade, command.Estado);

            var alunoExistente = await _alunoRepository.ObterPorIdAsync(command.AlunoId);

            if (alunoExistente == null)
            {
                AdicionarErro("Não foi possível localizar o aluno!");
                return ValidationResult;
            }

            alunoExistente.AtribuirEndereco(endereco);

            _alunoRepository.Alterar(alunoExistente);

            await _alunoRepository.SalvarAsync();

            return ValidationResult;

        }
    }
}