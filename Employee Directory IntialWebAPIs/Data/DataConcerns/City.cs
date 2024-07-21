namespace Repository.DataConcerns;

public partial class City
{
    public int CityId { get; set; }

    public string CityName { get; set; } = null!;

    public string Country { get; set; } = null!;

    public int? Population { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }
}
