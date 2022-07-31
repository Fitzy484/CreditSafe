namespace CreditsafeCountryApi.Models
{
    public class City
    {
        public int CityId { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public int TouristRating { get; set; }

        public int DateEstablished { get; set; }

        public int EstimatedPopulation { get; set; }
    }
}
