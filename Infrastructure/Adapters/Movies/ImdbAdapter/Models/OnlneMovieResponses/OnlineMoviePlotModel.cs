using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters.Movies.ImdbAdapter.Models.OnlneMovieResponses
{
    public class Category
    {
        public string id { get; set; }
        public string text { get; set; }
        public string value { get; set; }
    }
    public class OnlineMovieModel
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public Title title { get; set; }
    }

    public class DisplayableProperty
    {
        public Value value { get; set; }
    }

    public class Plot
    {
        public string id { get; set; }
        public PlotText plotText { get; set; }
    }

    public class PlotText
    {
        public string plainText { get; set; }
    }

    public class Root
    {
        public Data data { get; set; }
    }

    public class Title
    {
        public string id { get; set; }
        public Plot plot { get; set; }
        public Type type { get; set; }
    }

    public class Type
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

    public class Value
    {
        public string plainText { get; set; }
    }


}
