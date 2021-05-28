using AutoMapper;
using MinhaEscolaDigital.API.Application.DTO;
using MinhaEscolaDigital.Domain.Entities;

namespace EntregaFutura.Repository.DTO.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Aluno, AlunoDTO>().ReverseMap();
            CreateMap<Endereco, EnderecoDTO>().ReverseMap();
            CreateMap<Responsavel, ResponsavelDTO>().ReverseMap();
            CreateMap<Observacao, ObservacaoDTO>().ReverseMap();
        }
    }
}
