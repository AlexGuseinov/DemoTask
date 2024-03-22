using FluentValidation;

namespace Application.Features.Movies.Queries
{
    public class GetMovieByNameQueryValidator : AbstractValidator<GetMovieByNameQuery>
    {
        public GetMovieByNameQueryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
        }
    }


}
