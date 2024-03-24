namespace Infrastructure.Adapters.Movies.ImdbAdapter.Models.ImdbResponses;

public class Result
{
    public string Id { get; set; }
    public string TitleNameText { get; set; }
    public string TitleReleaseText { get; set; }
    public string TitleTypeText { get; set; }
    public Titleposterimagemodel TitlePosterImageModel { get; set; }
    public string[] TopCredits { get; set; }
    public string ImageType { get; set; }
}

