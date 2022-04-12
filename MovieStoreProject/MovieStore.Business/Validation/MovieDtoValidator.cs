using FluentValidation;
using MovieStore.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Business.Validation
{
    public class MovieDtoValidator : AbstractValidator<MovieDto>
    {
        public MovieDtoValidator()
        {
            RuleFor(m => m.MovieName)
                .NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(m => m.Price)
                .InclusiveBetween(1, int.MaxValue)
                .WithMessage("{PropertyName} must be greater than 0 ");

            RuleFor(m => m.DirectorId)
                .InclusiveBetween(1, int.MaxValue)
                .WithMessage("{PropertyName} must be greater than 0 ");

        }
    }
}
