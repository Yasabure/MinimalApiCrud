using MinimalApiCrud.Models;

namespace MinimalApiCrud.Interfaces
{
    public interface IChampionRepository
    {
        IEnumerable<ChampionLancamentos> GetChampions();
        bool InsertChampion(ChampionLancamentos champion);
        bool UpdateFuncao(string Funcao, int id);
        bool Delete(int id);

    }

}