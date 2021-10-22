namespace PolymorphicEquality.Models.FSharp.AddressCapturing

open PolymorphicEquality.Models.FSharp.Address

type CountryArea = {
    CountryCode: CountryCode
}

type NumericPostcodeRangeArea = {
    CountryCode: CountryCode
    PostcodeFrom: int
    PostcodeTo: int
}

type Area =
    | CountryArea of CountryArea
    | NumericPostcodesRangeArea of NumericPostcodeRangeArea

type AreaGroup = {
    Name: string
    IncludedAreas: Area list
    ExcludedAreas: Area list
}


// TODO: implement ContainsAddress
