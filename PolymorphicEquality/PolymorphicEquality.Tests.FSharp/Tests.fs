module Tests

open PolymorphicEquality.Models.FSharp.AddressCapturing
open PolymorphicEquality.Models.FSharp.Address
open Xunit

[<Fact>]
let ``AreaGroups with same semantic content should be equal`` () =
    let areaGroup1 = {
        Name = "Berlin and Frankfurt"
        IncludedAreas = [
            NumericPostcodesRangeArea
                {
                    CountryCode = CountryCode.create "DE"
                    PostcodeFrom = 10115
                    PostcodeTo = 10888
                }
            NumericPostcodesRangeArea
                {
                    CountryCode = CountryCode.create "DE"
                    PostcodeFrom = 60306
                    PostcodeTo = 65936
                }
        ]
        ExcludedAreas = []
    }

    let areaGroup2 = {
        Name = "Berlin and Frankfurt"
        IncludedAreas = [
            NumericPostcodesRangeArea
                {
                    CountryCode = CountryCode.create "DE"
                    PostcodeFrom = 10115
                    PostcodeTo = 10888
                }
            NumericPostcodesRangeArea
                {
                    CountryCode = CountryCode.create "DE"
                    PostcodeFrom = 60306
                    PostcodeTo = 65936
                }
        ]
        ExcludedAreas = []
    }

    Assert.True(areaGroup1.Equals areaGroup2)


[<Fact>]
let ``AreaGroups with different semantic content should not be equal`` () =
    let areaGroup1 = {
        Name = "Germany excluding Berlin Praiser Platz"
        IncludedAreas = [
            CountryArea
                {
                    CountryCode = CountryCode.create "DE"
                }
        ]
        ExcludedAreas = [
            NumericPostcodesRangeArea
                {
                    CountryCode = CountryCode.create "DE"
                    PostcodeFrom = 10117
                    PostcodeTo = 10117
                }
        ]
    }

    let areaGroup2 = {
        Name = "Germany excluding Berlin Springbrunnen"
        IncludedAreas = [
            CountryArea
                {
                    CountryCode = CountryCode.create "DE"
                }
        ]
        ExcludedAreas = [
            NumericPostcodesRangeArea
                {
                    CountryCode = CountryCode.create "DE"
                    PostcodeFrom = 10178
                    PostcodeTo = 10178
                }
        ]
    }

    Assert.False(areaGroup1.Equals areaGroup2)
