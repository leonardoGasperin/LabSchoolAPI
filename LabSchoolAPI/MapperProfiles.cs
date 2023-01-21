using AutoMapper;
using LabSchoolAPI.Models;
using LabSchoolAPI.Models.Dto.AlunoDTO;
using LabSchoolAPI.Models.Dto.PedagogoDTO;
using LabSchoolAPI.Models.Dto.ProfessorDTO;

namespace LabSchoolAPI
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Aluno, AlunoRequestDTO>();
            CreateMap<AlunoRequestDTO, Aluno>();

            CreateMap<Aluno, AlunoResponseDTO>()
                .ForMember(dest => dest.DataNascimento, act => act.MapFrom(resp => resp.DataNascimento.ToShortDateString()));
            CreateMap<AlunoResponseDTO, Aluno>()
                .ForMember(dest => dest.DataNascimento, act => act.MapFrom(resp => resp.DataNascimento));

            CreateMap<Aluno, AlunoMatriculaAtualizacaoDTO>();
            CreateMap<AlunoMatriculaAtualizacaoDTO, Aluno>();

            CreateMap<Professor, ProfessorResponseDTO>()
                .ForMember(dest => dest.DataNascimento, act => act.MapFrom(resp => resp.DataNascimento.ToShortDateString()));
            CreateMap<ProfessorResponseDTO, Professor>()
                .ForMember(dest => dest.DataNascimento, act => act.MapFrom(resp => resp.DataNascimento));

            CreateMap<Pedagogo, PedagogoResponseDTO>()
                .ForMember(dest => dest.DataNascimento, act => act.MapFrom(resp => resp.DataNascimento.ToShortDateString()));
            CreateMap<PedagogoResponseDTO, Pedagogo>()
                .ForMember(dest => dest.DataNascimento, act => act.MapFrom(resp => resp.DataNascimento));

        }

    }

}
