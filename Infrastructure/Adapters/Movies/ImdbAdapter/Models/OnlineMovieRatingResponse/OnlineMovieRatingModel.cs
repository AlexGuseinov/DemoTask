using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters.Movies.ImdbAdapter.Models.OnlineMovieRatingResponse
{
 
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Attribute
    {
        public string id { get; set; }
        public string text { get; set; }
    }

    public class CanRate
    {
        public bool isRatable { get; set; }
    }

    public class Category
    {
        public string id { get; set; }
        public string text { get; set; }
        public string value { get; set; }
    }

    public class Country
    {
        public string id { get; set; }
    }
    public class OnlineMovieRatingModel
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public Title title { get; set; }
    }

    public class DisplayableProperty
    {
        public object qualifiersInMarkdownList { get; set; }
        public Value value { get; set; }
    }

    public class OriginalTitleText
    {
        public string text { get; set; }
        public bool isOriginalTitle { get; set; }
    }

    public class PrimaryImage
    {
        public string __typename { get; set; }
        public string id { get; set; }
        public string url { get; set; }
        public int height { get; set; }
        public int width { get; set; }
    }

    public class RatingsSummary
    {
        public int voteCount { get; set; }
        public double aggregateRating { get; set; }
        public TopRanking topRanking { get; set; }
    }

    public class ReleaseDate
    {
        public string __typename { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public int year { get; set; }
        public Country country { get; set; }
        public object restriction { get; set; }
        public List<Attribute> attributes { get; set; }
        public DisplayableProperty displayableProperty { get; set; }
    }

    public class ReleaseYear
    {
        public string __typename { get; set; }
        public int year { get; set; }
        public object endYear { get; set; }
    }

    public class Root
    {
        public OnlineMovieRatingModel data { get; set; }
    }

    public class Title
    {
        public string __typename { get; set; }
        public string id { get; set; }
        public TitleText titleText { get; set; }
        public OriginalTitleText originalTitleText { get; set; }
        public ReleaseYear releaseYear { get; set; }
        public ReleaseDate releaseDate { get; set; }
        public TitleType titleType { get; set; }
        public PrimaryImage primaryImage { get; set; }
        public CanRate canRate { get; set; }
        public RatingsSummary ratingsSummary { get; set; }
    }

    public class TitleText
    {
        public string text { get; set; }
        public bool isOriginalTitle { get; set; }
    }

    public class TitleType
    {
        public string __typename { get; set; }
        public string id { get; set; }
        public string text { get; set; }
        public List<Category> categories { get; set; }
        public bool canHaveEpisodes { get; set; }
        public bool isEpisode { get; set; }
        public bool isSeries { get; set; }
        public DisplayableProperty displayableProperty { get; set; }
    }

    public class TopRanking
    {
        public int rank { get; set; }
    }

    public class Value
    {
        public string plainText { get; set; }
    }


}
