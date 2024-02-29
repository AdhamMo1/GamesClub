namespace GamesClub.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IDevicesServices _devicesServices;
        private readonly IGamesServices _gamesServices;

        public GamesController(ICategoriesService categoriesService, IDevicesServices devicesServices, IGamesServices gamesServices)
        {
            _categoriesService = categoriesService;
            _devicesServices = devicesServices;
            _gamesServices = gamesServices;
        }

        public async Task<IActionResult> Index()
        {
            var games = await _gamesServices.GetAllGames();
            return View(games);
        }
       
        [HttpGet]
        public IActionResult Create()
        {
            CreateFormGamesViewModel model = new CreateFormGamesViewModel()
            {
                Categories = _categoriesService.GetCategoriesSelectList(),
                Deviecs = _devicesServices.GetDevicesSelectList()
            };
            
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create (CreateFormGamesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesService.GetCategoriesSelectList();
                model.Deviecs = _devicesServices.GetDevicesSelectList();
                return View(model);
            }
            _gamesServices.Create(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
