

namespace GamesClub.Services
{
    public class GamesServices : IGamesServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string ImagesPath;
        public GamesServices(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            ImagesPath = $"{_webHostEnvironment.WebRootPath}{FileSettings.ImagesPath}";
        }
        public async Task<IEnumerable<Game>> GetAllGames()
        {
            return await _context.Games.Include(c => c.Category).Include(gd => gd.Devices).ThenInclude(d=>d.Device).AsNoTracking().ToListAsync();
        }
        public void Create(CreateFormGamesViewModel model)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";
            var path = Path.Combine(ImagesPath, coverName) ;
            using var dataStream = File.Create(path);
            model.Cover.CopyTo(dataStream);

            Game game = new()
            {
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Devices = model.DevieceId.Select(d => new GameDevice { DeviceId = d }).ToList(),
                Cover = coverName
            };
            _context.Add(game);
            _context.SaveChanges();

        }

        
    }
}
