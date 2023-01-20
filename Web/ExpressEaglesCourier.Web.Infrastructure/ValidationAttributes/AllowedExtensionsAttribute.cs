namespace ExpressEaglesCourier.Web.Infrastructure.ValidationAttributes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;

    using Microsoft.AspNetCore.Http;

    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] extensions;

        public AllowedExtensionsAttribute(string[] extensions)
        {
            this.extensions = extensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IEnumerable<IFormFile> files = value as IEnumerable<IFormFile>;
            foreach (IFormFile file in files)
            {
                if (file != null)
                {
                    string extension = Path.GetExtension(file.FileName);
                    if (!this.extensions.Contains(extension.ToLower()))
                    {
                        return new ValidationResult($"{file.FileName} has extension {extension.TrimStart('.')} that is not allowed!");
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
