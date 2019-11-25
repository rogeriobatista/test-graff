using LeilaoGraff.Dtos;
using System.Collections.Generic;

namespace LeilaoGraff.Interfaces
{
    public interface ILanceService
    {
        List<LanceDto> Listar();
        List<LanceDto> Filtrar(FiltroLanceDto filtro);
        bool Armazenar(LanceDto lance);
    }
}
