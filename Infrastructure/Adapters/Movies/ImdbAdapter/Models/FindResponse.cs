using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters.Movies.ImdbAdapter.Models;

public class FindResponse
{
    public string[] ResultsSectionOrder { get; set; }
    public Findpagemeta FindPageMeta { get; set; }
    public Keywordresults KeywordResults { get; set; }
    public Titleresults TitleResults { get; set; }
    public Nameresults NameResults { get; set; }
    public Companyresults CompanyResults { get; set; }
}

public class Findpagemeta
{
    public string SearchTerm { get; set; }
    public bool IncludeAdult { get; set; }
    public bool IsExactMatch { get; set; }
}

public class Keywordresults
{
    public object[] Results { get; set; }
}

public class Titleresults
{
    public List<Result> Results { get; set; }
    public string NextCursor { get; set; }
    public bool HasExactMatches { get; set; }
}

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

public class Titleposterimagemodel
{
    public string Url { get; set; }
    public int MaxHeight { get; set; }
    public int MaxWidth { get; set; }
    public string Caption { get; set; }
}

public class Nameresults
{
    public Result1[] Results { get; set; }
    public string NextCursor { get; set; }
    public bool HasExactMatches { get; set; }
}

public class Result1
{
    public string Id { get; set; }
    public string DisplayNameText { get; set; }
    public string KnownForJobCategory { get; set; }
    public string KnownForTitleText { get; set; }
    public string KnownForTitleYear { get; set; }
    public Avatarimagemodel AvatarImageModel { get; set; }
}

public class Avatarimagemodel
{
    public string Url { get; set; }
    public int MaxHeight { get; set; }
    public int MaxWidth { get; set; }
    public string Caption { get; set; }
}

public class Companyresults
{
    public object[] Results { get; set; }
}
