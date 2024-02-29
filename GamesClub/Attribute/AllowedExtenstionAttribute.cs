namespace GamesClub.Attribute
{
    public class AllowedExtenstionAttribute : ValidationAttribute
    {
        private string _allowedExtenstion {  get; set; } = string.Empty;

        public AllowedExtenstionAttribute(string allowedExtenstion)
        {
            _allowedExtenstion = allowedExtenstion;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                var isAllowed = _allowedExtenstion.Split(',').Contains(extension, StringComparer.OrdinalIgnoreCase);
                if (!isAllowed)
                {
                    return new ValidationResult($"Only {_allowedExtenstion} is allowed.");
                }
            }
            return  ValidationResult.Success;
            
        }

    }
}
