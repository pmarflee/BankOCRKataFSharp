namespace BankOCRKataFSharp.Core

open System

module AccountNumberParser =

    open System

    module private Parser =

        let numbers = [|
            " _ ","| |","|_|";
            "   ", "  |", "  |";
            " _ "," _|","|_ ";
            " _ "," _|"," _|";
            "   ","|_|","  |";
            " _ ","|_ "," _|";
            " _ ","|_ ","|_|";
            " _ ","  |","  |";
            " _ ","|_|","|_|";
            " _ ","|_|"," _|"
        |]

    let Parse (input : string) =
        let lines = input.Split([|Environment.NewLine|], StringSplitOptions.RemoveEmptyEntries)
        let rec parseline (state : string list) (current : char list) (remaining : char list) =
            match remaining with
            | [] -> state
            | hd :: tl ->
                let new_current = hd :: current
                match new_current with
                | [_;_;_] -> parseline (new String(new_current |> List.rev |> List.toArray) :: state) [] tl                    
                | _ -> parseline state new_current tl
        let segments = lines 
                        |> Seq.map (fun line -> parseline [] [] (line.ToCharArray() |> Array.toList)) 
                        |> Seq.toList
        let parsednumbers = List.zip3 segments.[0] segments.[1] segments.[2] 
                            |> List.rev
                            |> List.map (fun parsed -> (Parser.numbers |> Array.findIndex (fun number -> number = parsed)).ToString())
        Int32.Parse(String.Join("", parsednumbers))