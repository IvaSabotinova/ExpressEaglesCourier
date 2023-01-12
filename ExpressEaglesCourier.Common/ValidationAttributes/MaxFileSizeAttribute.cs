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
            long totalFileSize = 0;
            foreach (IFormFile file in files)
            {
                if (file != null)
                {
                    totalFileSize += file.Length;
                    if (totalFileSize > this.maxFileSize)
                    {
                        return new ValidationResult($"Total files size should not exceed {this.maxFileSize} bytes!");
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
