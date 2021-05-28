﻿using MediatR;
using MinhaEscolaDigital.API.Application.ApplicationObjects;
using MinhaEscolaDigital.Domain.Entities;
using MinhaEscolaDigital.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MinhaEscolaDigital.API.Application.Messages.Commands.AlunoCommand
{
    public class AlunoCommandHandler : CommandHandler,
        IRequestHandler<AdicionarAlunoCommand, BaseResult>,
        IRequestHandler<AlterarAlunoCommand, BaseResult>,
        IRequestHandler<ExcluirAlunoCommand, BaseResult>,
        IRequestHandler<AlterarEnderecoAlunoCommand, BaseResult>
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoCommandHandler(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<BaseResult> Handle(AdicionarAlunoCommand command, CancellationToken cancellationToken)
        {
            if (!command.Validar()) return command.BaseResult;

            var alunoExistente = await _alunoRepository.ObterPorCpfAsync(command.Cpf);

            if (alunoExistente != null)
            {
                AdicionarErro("Este CPF já está em uso por outro aluno!");
                return BaseResult;
            }

            var aluno = new Aluno(command.Nome, command.DataNascimento, command.Rg, command.Cpf, command.Observacao, command.TurmaId);

            var endereco = new Endereco(command.Endereco.Logradouro, command.Endereco.Numero, command.Endereco.Complemento, command.Endereco.Bairro, command.Endereco.Cep, command.Endereco.Cidade, command.Endereco.Estado);

            var responsaveis = command.Responsaveis.Select(r => new Responsavel(r.Nome, r.DataNascimento, r.Rg, r.Cpf, r.Telefone, r.Celular, r.Email, r.Observacao)).ToList();

            var alunoResponsavel = new List<AlunoResponsavel>();

            foreach (var item in responsaveis)
            {
                alunoResponsavel.Add(new AlunoResponsavel(aluno, item));
            }

            aluno.AtribuirEndereco(endereco);
            aluno.AtribuirResponsaveis(alunoResponsavel);

            _alunoRepository.Adicionar(aluno);

            await _alunoRepository.SalvarAsync();

            BaseResult.id = aluno.Id;

            return BaseResult;
        }

        public async Task<BaseResult> Handle(AlterarAlunoCommand command, CancellationToken cancellationToken)
        {
            if (!command.Validar()) return command.BaseResult;

            var aluno = await _alunoRepository.ObterPorIdAsync(command.AlunoId);

            if (aluno == null)
            {
                AdicionarErro("Não foi possível localizar o aluno!");
                return BaseResult;
            }

            // Atualiza o endereço
            var endereco = aluno.Endereco;
            endereco.Atualizar(command.Endereco.Logradouro, command.Endereco.Numero, command.Endereco.Complemento, command.Endereco.Bairro, command.Endereco.Cep, command.Endereco.Cidade, command.Endereco.Estado);

            // Atualiza os responsáveis
            List<AlunoResponsavel> ResponsaveisParaRemover = new List<AlunoResponsavel>();
            List<AlunoResponsavel> ResponsaveisParAdcionar = new List<AlunoResponsavel>();
            List<AlunoResponsavel> novosAlunoResponsavels = new List<AlunoResponsavel>();

            foreach (var item in command.Responsaveis)
            {
                var responsavel = await _alunoRepository.ObterResponsavelPorIdAsync(item.id);

                responsavel.Atualizar(item.Nome, item.DataNascimento, item.Rg, item.Cpf, item.Telefone, item.Celular, item.Email, item.Observacao);

                novosAlunoResponsavels.Add(new AlunoResponsavel(aluno, responsavel));
            }

            // Se um responsavel está gravado mas não está na lista de nova (indica que foi retirado)            
            foreach (AlunoResponsavel responsavel in aluno.AlunosResponsaveis)
            {
                if (novosAlunoResponsavels.Any(e => e.AlunoId == responsavel.AlunoId
                && e.ResponsavelId == responsavel.ResponsavelId) == false)
                {
                    ResponsaveisParaRemover.Add(responsavel);
                }
            }

            // Se um responsavel está na lista nova mas está na gravada (indica que foi incluso)            
            foreach (AlunoResponsavel responsavel in novosAlunoResponsavels)
            {
                AlunoResponsavel isIncluso = aluno.AlunosResponsaveis.
                    Where(m => m.ResponsavelId == responsavel.ResponsavelId).FirstOrDefault();
                if (isIncluso == null)
                {
                    ResponsaveisParAdcionar.Add(responsavel);
                }
            }

            aluno.Atualizar(command.Nome, command.DataNascimento, command.Rg, command.Cpf, command.Observacao, command.TurmaId);
            aluno.AtribuirEndereco(endereco);
            aluno.AtribuirResponsaveis(novosAlunoResponsavels);

            _alunoRepository.Alterar(aluno);

            await _alunoRepository.SalvarAsync();

            return BaseResult;
        }

        public async Task<BaseResult> Handle(ExcluirAlunoCommand command, CancellationToken cancellationToken)
        {
            if (!command.Validar()) return command.BaseResult;

            var aluno = await _alunoRepository.ObterPorIdAsync(command.AlunoId);

            if (aluno == null)
            {
                AdicionarErro("Não foi possível localizar o aluno!");
                return BaseResult;
            }

            aluno.Excluir();

            _alunoRepository.Alterar(aluno);

            await _alunoRepository.SalvarAsync();

            return BaseResult;
        }

        public async Task<BaseResult> Handle(AlterarEnderecoAlunoCommand command, CancellationToken cancellationToken)
        {
            if (!command.Validar()) return command.BaseResult;

            var aluno = await _alunoRepository.ObterPorIdAsync(command.AlunoId);

            if (aluno == null)
            {
                AdicionarErro("Não foi possível localizar o aluno!");
                return BaseResult;
            }

            // Atualiza o endereço
            var endereco = aluno.Endereco;
            endereco.Atualizar(command.Logradouro, command.Numero, command.Complemento, command.Bairro, command.Cep, command.Cidade, command.Estado);

            _alunoRepository.Alterar(aluno);

            await _alunoRepository.SalvarAsync();

            return BaseResult;
        }
    }
}