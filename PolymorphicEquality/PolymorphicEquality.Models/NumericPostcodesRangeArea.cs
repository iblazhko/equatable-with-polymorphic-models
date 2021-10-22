namespace PolymorphicEquality.Models
{
    public sealed record NumericPostcodeRangeArea(
        CountryCode Country,
        int PostcodeFrom,
        int PostcodeTo) : AreaType
    {
        public override bool ContainsAddress(Address testAddress) =>
            testAddress.Country == Country &&
            ContainsPostcode(testAddress.Postcode);

        private bool ContainsPostcode(Postcode postcode) =>
            int.TryParse(postcode.Code, out var numPostcode) &&
            numPostcode >= PostcodeFrom &&
            numPostcode <= PostcodeTo;

        public override string ToString()
            => $"[{nameof(NumericPostcodeRangeArea)}, Country: {Country}, Postcodes: '{PostcodeFrom}'-'{PostcodeTo}']";
    }
}
