namespace PolymorphicEquality.Models
{
    public record CountryCode(string Code)
    {
        public override string ToString() => Code;
    }

    public record CityName(string City)
    {
        public static CityName None() => new (string.Empty);
        public override string ToString() => City;
    }

    public record Postcode(string Code)
    {
        public static Postcode None() => new (string.Empty);
        public override string ToString() => Code;
    }

    public record Address(
        CountryCode Country,
        CityName City,
        Postcode Postcode)
    {
        public override string ToString() =>
            $"[Country: '{Country}', City: '{City}', Postcode: '{Postcode}']";
    }
}
