namespace ListaCompra.Profile;
using AutoMapper;
using ListaCompra.Data.DTOs;
using ListaCompra.Models;

public class ListaCompraProfile : Profile
{
    public ListaCompraProfile()
    {
        CreateMap<CreateListaComprasDto, ListaDeCompras>();
        CreateMap<UpdateListaCompraDto, ListaDeCompras>();
        CreateMap<ListaDeCompras, ReadListaCompraDto>()
            .ForMember(ListaCompraDto => ListaCompraDto.UsuarioCriador,
            opts => opts.MapFrom(ListaCompra => ListaCompra.UsuarioCriador.UserName))
            .ForMember(ListaCompraDto => ListaCompraDto.Produtos,
            opts => opts.MapFrom(ListaCompra => ListaCompra.Produtos));

    }
}
