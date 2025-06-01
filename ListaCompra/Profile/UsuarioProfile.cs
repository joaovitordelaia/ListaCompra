namespace ListaCompra.Profile;
using AutoMapper;
using ListaCompra.Data.DTOs;
using ListaCompra.Models;


public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<CreateUsuarioDto, Usuario>();
        //CreateMap<UpdateUsuarioDto, Usuario>();
        //CreateMap<Usuario, ReadUsuarioDto>();
    }
}
