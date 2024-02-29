namespace GamesClub.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ApplicationDbContext _context;

        public CategoriesService(ApplicationDbContext context)
        {
            _context = context;
        }

        IEnumerable<SelectListItem> ICategoriesService.GetCategoriesSelectList()
        {
            return _context.Categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).
               OrderBy(c => c.Text).AsNoTracking().ToList();
        }
    }
}
