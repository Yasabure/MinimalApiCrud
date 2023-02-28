using System.Data;
using MinimalApiCrud.Factory;
using MinimalApiCrud.Interfaces;
using MinimalApiCrud.Models;
using Dapper;
 
namespace MinimalApiCrud.Repositories
{
    public class ChampionRepository : IChampionRepository
    {  
        private readonly IDbConnection _connection;
        public ChampionRepository()
        {
            _connection = new SqlFactory().SqlConnection();
        }

        public bool Delete(int id)
        {
            var query = "DELETE [ChampionLOL].[dbo].[Champions] WHERE [Id] = @championId";
            var parameters = new {championId = id};
            int result = 0;

            using(_connection)
            {
                 result = _connection.Execute(query, parameters);
            }

            return(result != 0 ? true:false);
        }

        public IEnumerable<ChampionLancamentos> GetChampions()
        {
            var champions = new List<ChampionLancamentos>();
            var query = "SELECT *FROM [ChampionLOL].[dbo].[Champions]";
            
            using(_connection)
            {
                champions = _connection.Query<ChampionLancamentos>(query).ToList();
            }

            return champions;
        }

        public bool InsertChampion(ChampionLancamentos champion)
        {
            var query = 
            @"INSERT INTO [ChampionLOL].[dbo].[Champions]
            VALUES
            (
                @nome,
                @anolancamento,
                @funcao
            )  ";
            var parameters = new
            {
                nome = champion.Nome,
                anolancamento = champion.AnoLancamento,
                funcao = champion.Funcao
            };

            int result = 0;

            using(_connection)
            {
                result = _connection.Execute(query, parameters);
            }
            return(result != 0 ? true:false);
        }

        public bool UpdateFuncao(string Funcao, int id)
        {
            var query = @"UPDATE [ChampionLOL].[dbo].[Champions]
            SET
            [Funcao] = @funcaoChamp
            WHERE
            [ID] = @ChampId";
            var parameters = new
            {
                funcaochamp = Funcao,
                champId = id
            };
            
            int result = 0;

            using(_connection)
            {
                result = _connection.Execute(query,parameters);
            }
             return(result != 0 ? true:false);
        }
    }
}