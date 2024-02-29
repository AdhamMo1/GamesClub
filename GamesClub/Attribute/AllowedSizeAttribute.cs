namespace GamesClub.Attribute
{
    public class AllowedSizeAttribute:ValidationAttribute
    {
        private readonly long _maxSize;

        public AllowedSizeAttribute(long maxSize)
        {
            _maxSize = maxSize;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                if (file.Length > _maxSize)
                {
                    return new ValidationResult("File size must be less than 1MB .");
                }
            }
            return ValidationResult.Success;
        }

    }
}
