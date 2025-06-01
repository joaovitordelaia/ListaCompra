namespace ListaCompra.Profile;
using AutoMapper;
using ListaCompra.Data.DTOs;
using ListaCompra.Models;

public class ProdutoProfile : Profile 
{
    public ProdutoProfile()
    {
        CreateMap<CreateProdutoDto, Produtos>();
        CreateMap<UpdateProdutoDto, Produtos>();
        CreateMap<Produtos, ReadProdutoDto>();
    }
}
