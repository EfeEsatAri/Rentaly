using FluentValidation;
using Rentaly.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Kategori Adı En Az 2 Karakter Olmalıdır")
                .MaximumLength(30).WithMessage("Kategori Adı En fazla 30 Karakter Olabilir");
        }
    }
}
