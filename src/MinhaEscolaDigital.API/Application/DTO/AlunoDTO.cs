using MinhaEscolaDigital.Domain.Entities;
using System;

namespace MinhaEscolaDigital.API.Application.DTO
{
    public class AlunoDTO
    {
        public Guid Id { get; set; }

        public Guid ClienteId { get; set; }
        public int Status { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorTotal { get; set; }

        public decimal Desconto { get; set; }
        public string VoucherCodigo { get; set; }
        public bool VoucherUtilizado { get; set; }


        public EnderecoDTO Endereco { get; set; }

        public static AlunoDTO ParaAlunoDTO(Aluno aluno)
        {
            var alunoDTO = new AlunoDTO
            {
                Endereco = new EnderecoDTO()
            };

            alunoDTO.Endereco = new EnderecoDTO
            {
                Logradouro = aluno.Endereco.Logradouro,
                Numero = aluno.Endereco.Numero,
                Complemento = aluno.Endereco.Complemento,
                Bairro = aluno.Endereco.Bairro,
                Cep = aluno.Endereco.Cep,
                Cidade = aluno.Endereco.Cidade,
                Estado = aluno.Endereco.Estado,
            };

            return alunoDTO;
        }
    }
}