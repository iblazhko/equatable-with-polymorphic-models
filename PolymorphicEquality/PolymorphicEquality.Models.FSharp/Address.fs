module PolymorphicEquality.Models.FSharp.Address

type CountryCode = private CountryCode of string
module CountryCode =
    let create code = CountryCode code
    let value (CountryCode code) = code

type CityName = private CityName of string
module CityName =
    let create city = CityName city
    let value (CityName city) = city

type Postcode = private Postcode of string
module Postcode =
    let create postcode = Postcode postcode
    let value (Postcode postcode) = postcode

type Address = {
    Country: CountryCode
    City: CityName
    Postcode: Postcode
}
