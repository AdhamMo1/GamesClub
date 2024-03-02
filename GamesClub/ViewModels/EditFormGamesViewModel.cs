
namespace GamesClub.ViewModels
{
    public class EditFormGamesViewModel:BaseFormGamesViewModel
    {
        public int Id { get; set; }
        [AllowedExtenstion(FileSettings.allowedExtestion), AllowedSize(FileSettings.MaxSizeAllowed)]
        public IFormFile? Cover { get; set; } = default!;
        public string CurrentCover { get; set; } = string.Empty;
    }
}
