﻿namespace ListaCompra.Profile;
using AutoMapper;
using ListaCompra.Data.DTOs;
using ListaCompra.Models;

public class ListaCompartilhadaProfile : Profile
{
    public ListaCompartilhadaProfile()
    {
        CreateMap<CreateListaCompartilhadaDto, ListaCompartilhadas>();
        CreateMap<ListaCompartilhadas, ReadListaCompartilhadaDto>();
    }

}
