using System.Linq;
using PolymorphicEquality.Models;
using Xunit;

namespace PolymorphicEquality.Tests
{
    public class EqualityTests
    {
        [Fact]
        public void AreaGroups_WithSameSemanticContent_ShouldBeEqual()
        {
            ICaptureAddresses areaGroup1 = new AreaGroup(
                "Berlin and Frankfurt",
                new AreaType[]
                {
                    new NumericPostcodeRangeArea(
                        new CountryCode("DE"),
                        10115,
                        10999),
                    new NumericPostcodeRangeArea(
                        new CountryCode("DE"),
                        60306,
                        65936)
                }.ToHashSet(),
                new AreaType[] { }.ToHashSet());

            ICaptureAddresses areaGroup2 = new AreaGroup(
                "Berlin and Frankfurt",
                new AreaType[]
                {
                    new NumericPostcodeRangeArea(
                        new CountryCode("DE"),
                        60306,
                        65936),
                    new NumericPostcodeRangeArea(
                        new CountryCode("DE"),
                        10115,
                        10999)
                }.ToHashSet(),
                new AreaType[] { }.ToHashSet());

            Assert.True(areaGroup1.Equals(areaGroup2));
        }

        [Fact]
        public void AreaGroups_WithDifferentSemanticContent_ShouldNotBeEqual()
        {
            ICaptureAddresses areaGroup1 = new AreaGroup(
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

            ICaptureAddresses areaGroup2 = new AreaGroup(
                "Germany excluding Berlin Springbrunnen",
                new AreaType[]
                {
                    new CountryArea(new CountryCode("DE"))
                }.ToHashSet(),
                new AreaType[]
                {
                    new NumericPostcodeRangeArea(
                        new CountryCode("DE"),
                        10178,
                        10178)
                }.ToHashSet());

            Assert.False(areaGroup1.Equals(areaGroup2));
        }
    }
}
