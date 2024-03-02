

using GamesClub.Models;
using Microsoft.AspNetCore.Http.HttpResults;

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
        public Game? getById(int id)
        {
            return _context.Games.Include(c => c.Category).Include(gd => gd.Devices).ThenInclude(d => d.Device).AsNoTracking().SingleOrDefault(x=>x.Id == id);
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

        public async Task<Game?> Update(EditFormGamesViewModel model)
        {
            var game = _context.Games
                .Include(g => g.Devices)
                .SingleOrDefault(g => g.Id == model.Id);

            if (game is null)
                return null;

            var hasNewCover = model.Cover is not null;
            var oldCover = game.Cover;

            game.Name = model.Name;
            game.Description = model.Description;
            game.CategoryId = model.CategoryId;
            game.Devices = model.DevieceId.Select(d => new GameDevice { DeviceId = d }).ToList();

            if (hasNewCover)
            {
                game.Cover = await SaveCover(model.Cover!);
            }

            var effectedRows = _context.SaveChanges();

            if (effectedRows > 0)
            {
                if (hasNewCover)
                {
                    var cover = Path.Combine(ImagesPath, oldCover);
                    File.Delete(cover);
                }

                return game;
            }
            else
            {
                var cover = Path.Combine(ImagesPath, game.Cover);
                File.Delete(cover);

                return null;
            }
        }

        private async Task<string> SaveCover(IFormFile cover)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";

            var path = Path.Combine(ImagesPath, coverName);

            using var stream = File.Create(path);
            await cover.CopyToAsync(stream);

            return coverName;
        }

        public bool Delete(int id)
        {
            var isDeleted = false;
            var game = _context.Games.Include(x=>x.Category).Include(x=>x.Devices).FirstOrDefault(x=>x.Id==id);
            if (game is null)
            {
                return isDeleted;
            }
            _context.Games.Remove(game);
            var rowEffected = _context.SaveChanges();
            if(rowEffected > 0)
            {
                var cover = Path.Combine(ImagesPath, game.Cover);
                File.Delete(cover);
                isDeleted = true;
            }
            return isDeleted;
        }
    }
}
