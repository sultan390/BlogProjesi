﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage
                ("Kategori adı  boş geçilemez");

            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage
               ("Kategori açıklama kısmı boş geçilemez");

            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage
               ("Kategori adı en fazla 50 karakter olmalıdır");

            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage
               ("Kategori adı en fazla 2 karakter olmalıdır");
        }



    }
}
