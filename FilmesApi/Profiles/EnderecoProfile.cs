using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.models;

namespace FilmesApi.Profiles
{
    public class EnderecoProfile : Profile
    {

        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<UpdateEnderecoDto, Endereco>();
            CreateMap<Endereco, UpdateEnderecoDto>();
            CreateMap<Endereco, ReadEnderecoDto>();
        }
    }
}
