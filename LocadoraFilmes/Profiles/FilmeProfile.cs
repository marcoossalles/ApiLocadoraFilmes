
using LocadoraFilmes.Data.Dto;
using LocadoraFilmes.Models;
using AutoMapper;

namespace LocadoraFilmes.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();
    }
}
