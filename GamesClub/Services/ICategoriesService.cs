namespace GamesClub.Services
{
    public interface ICategoriesService
    {
        IEnumerable<SelectListItem> GetCategoriesSelectList();
    }
}
