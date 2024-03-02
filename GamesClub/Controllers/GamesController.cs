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
        public IActionResult Details(int id)
        {
            return View(_gamesServices.getById(id));
        }
        public IActionResult Edit(int id)
        {
            var game = _gamesServices.getById(id);
            if(game == null)
                return NotFound();
            var viewModel = new EditFormGamesViewModel()
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
                CategoryId = game.CategoryId,
                Categories = _categoriesService.GetCategoriesSelectList(),
                Deviecs = _devicesServices.GetDevicesSelectList(),
                DevieceId = game.Devices.Select(x => x.DeviceId).ToList(),
                CurrentCover = game.Cover
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditFormGamesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesService.GetCategoriesSelectList();
                model.Deviecs = _devicesServices.GetDevicesSelectList();
                return View(model);
            }
             
            var game = await _gamesServices.Update(model);

            if (game is null)
                return BadRequest();


            return RedirectToAction(nameof(Index));
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
        public IActionResult Delete (int id)
        {
            var isDeleted = _gamesServices.Delete(id);
            return isDeleted? Ok() : BadRequest();
        }
    }
}
