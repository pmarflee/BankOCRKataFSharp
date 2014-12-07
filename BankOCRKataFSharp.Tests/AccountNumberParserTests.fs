namespace BankOCRKataFSharp.Tests

open Xunit
open Xunit.Extensions
open FsUnit.Xunit
open BankOCRKataFSharp.Core

module AccountNumberParserTests =

    [<Theory>]
    [<InlineData("    _  _     _  _  _  _  _ \r\n  | _| _||_||_ |_   ||_||_|\r\n  ||_  _|  | _||_|  ||_| _|", 123456789)>]
    [<InlineData("    _  _     _  _  _  _  _ \r\n  | _| _||_||_ |_   ||_||_|\r\n  ||_  _|  | _||_|  ||_||_|", 123456788)>]
    [<InlineData("    _  _     _  _  _  _  _ \r\n  | _| _||_||_ |_   ||_||_|\r\n  | _| _|  | _||_|  ||_||_|", 133456788)>]
    [<InlineData("    _  _     _  _  _  _  _ \r\n  | _| _||_||_ |_   ||_|| |\r\n  | _| _|  | _||_|  ||_||_|", 133456780)>]
    let ``AccountNumberParser.Parse Returns Correct Result`` entry expected =
        entry
        |> AccountNumberParser.Parse
        |> should equal expected
