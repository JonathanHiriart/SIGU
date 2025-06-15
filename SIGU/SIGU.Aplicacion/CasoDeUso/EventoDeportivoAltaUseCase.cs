using SIGU.Aplicacion.Entidades;
using SIGU.Aplicacion.Interfaces;
using SIGU.Aplicacion.DTOs;
using SIGU.Aplicacion.Excepciones;
using System;
namespace SIGU.Aplicacion.CasoDeUso;
public class EventoDeportivoAltaUseCase
{
    private readonly IRepositorioEventoDeportivo _repositorioEventoDeportivo;
    private readonly IRepositorioPersona _repositorioPersona;

    public EventoDeportivoAltaUseCase(IRepositorioEventoDeportivo repositorioEventoDeportivo)
    {
        _repositorioEventoDeportivo = repositorioEventoDeportivo;
    }
    public async Task<EventoDeportivo> EjecutarAsync(EventoDeportivoDTO dto, Guid idUsuario)
    {

    }

}
