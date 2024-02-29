namespace GamesClub.Services
{
    public interface IDevicesServices
    {
        IEnumerable<SelectListItem> GetDevicesSelectList();
    }
}
