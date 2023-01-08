namespace ExpressEaglesCourier.Common.ValidationAttributes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            this.maxFileSize = maxFileSize;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IEnumerable<IFormFile> files = value as IEnumerable<IFormFile>;
            foreach (IFormFile file in files)
            {
                if (file != null)
                {
                    if (file.Length > this.maxFileSize)
                    {
                        return new ValidationResult($"{file.FileName} should have maximum size of {this.maxFileSize} bytes!");
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
