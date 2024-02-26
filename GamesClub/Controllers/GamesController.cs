namespace GamesClub.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateFormGamesViewModel model = new CreateFormGamesViewModel()
            {
                Categories = _context.Categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).
                OrderBy(c => c.Text).ToList(),
                Deviecs = _context.Devices.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).
                OrderBy(c => c.Text).ToList()
            };
            
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create (CreateFormGamesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _context.Categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).
                OrderBy(c => c.Text).ToList();
                model.Deviecs = _context.Devices.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).
                OrderBy(c => c.Text).ToList();
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
