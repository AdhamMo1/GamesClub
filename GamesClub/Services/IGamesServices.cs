namespace GamesClub.Services
{
    public interface IGamesServices
    {
        Task<IEnumerable<Game>> GetAllGames();
        void Create(CreateFormGamesViewModel model) ;
    }
}
