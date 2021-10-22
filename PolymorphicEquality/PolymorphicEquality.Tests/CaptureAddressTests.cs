using System.Linq;
using PolymorphicEquality.Models;
using Xunit;

namespace PolymorphicEquality.Tests
{
    public class CaptureAddressTests
    {
        [Theory]
        [InlineData("GB", "GB", true)]
        [InlineData("DE", "FR", false)]
        public void CountryArea_CapturesAddress(
            string areaCountryCode,
            string addressCountryCode,
            bool shouldMatch)
        {
            ICaptureAddresses area = new CountryArea(new CountryCode(areaCountryCode));

            var address = new Address(
                new CountryCode(addressCountryCode),
                CityName.None(),
                Postcode.None());

            Assert.Equal(
                area.ContainsAddress(address),
                shouldMatch);
        }

        [Theory]
        [InlineData("DE", 10000, 11000, "DE", "10500", true)]
        [InlineData("DE", 10000, 11000, "DE", "21500", false)]
        [InlineData("DE", 10000, 11000, "FR", "10500", false)]
        public void NumericPostcodesRangeArea_CapturesAddress(
            string areaCountryCode,
            int areaPostcodeFrom,
            int areaPostcodeTo,
            string addressCountryCode,
            string addressPostcode,
            bool shouldMatch)
        {
            ICaptureAddresses area = new NumericPostcodeRangeArea(
                new CountryCode(areaCountryCode),
                areaPostcodeFrom,
                areaPostcodeTo);

            var address = new Address(
                new CountryCode(addressCountryCode),
                CityName.None(),
                new Postcode(addressPostcode));

            Assert.Equal(
                area.ContainsAddress(address),
                shouldMatch);
        }

        [Fact]
        public void AreaGroup_WithMatchingIncludedArea_CapturesAddress()
        {
            ICaptureAddresses areaGroup = new AreaGroup(
                "United Kingdom",
                new AreaType[]
                {
                    new CountryArea(new CountryCode("GB"))
                }.ToHashSet(),
                new AreaType[] {}.ToHashSet());
            var address = new Address(
                new CountryCode("GB"),
                new CityName("London"),
                new Postcode("WU1 3AA"));

            Assert.True(areaGroup.ContainsAddress(address));
        }

        [Fact]
        public void AreaGroup_WithMatchingExcludedArea_DoesNotCaptureAddress()
        {
            ICaptureAddresses areaGroup = new AreaGroup(
                "Germany excluding Berlin Praiser Platz",
                new AreaType[]
                {
                    new CountryArea(new CountryCode("DE"))
                }.ToHashSet(),
                new AreaType[]
                {
                    new NumericPostcodeRangeArea(
                        new CountryCode("DE"),
                        10117,
                        10117)
                }.ToHashSet());
            var address = new Address(
                new CountryCode("DE"),
                new CityName("Berlin"),
                new Postcode("10117"));

            Assert.False(areaGroup.ContainsAddress(address));
        }
    }
}
