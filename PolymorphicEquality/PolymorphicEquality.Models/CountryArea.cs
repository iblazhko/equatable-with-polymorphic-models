namespace PolymorphicEquality.Models
{
    public sealed record CountryArea(CountryCode Country) : AreaType
    {
        public override bool ContainsAddress(Address testAddress) =>
            testAddress.Country == Country;

        public override string ToString() =>
            $"{nameof(CountryArea)}, Country: '{Country}'";
    }
}
