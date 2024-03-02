namespace GamesClub.ViewModels
{
    public class BaseFormGamesViewModel
    {
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        [Display(Name = "Available Devices")]
        public List<int> DevieceId { get; set; } = new List<int>();
        public IEnumerable<SelectListItem> Deviecs { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
