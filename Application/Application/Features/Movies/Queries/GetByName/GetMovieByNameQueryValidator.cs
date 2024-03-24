using FluentValidation;

namespace Application.Features.Movies.Queries.GetByName
{
    public class GetMovieByNameQueryValidator : AbstractValidator<GetMovieByNameQuery>
    {
        public GetMovieByNameQueryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
        }
    }


}
