

namespace GamesClub.ViewModels
{
    public class CreateFormGamesViewModel:BaseFormGamesViewModel
    {
        [Required,AllowedExtenstion(FileSettings.allowedExtestion), AllowedSize(FileSettings.MaxSizeAllowed)]
        public IFormFile Cover { get; set; } = default!;
    }
}
