module Utilities

open System

let isAnswerCorrect (userAnswer: string) (correctAnswer: string): bool =
    let normalize (str: string) =
        str.ToLowerInvariant().Split([|' '; ','; '.'; '!'|], StringSplitOptions.RemoveEmptyEntries)
        |> List.ofArray
    let userWords = normalize userAnswer
    let correctWords = normalize correctAnswer

    let matchCount = userWords |> List.filter (fun word -> List.contains word correctWords) |> List.length
    matchCount >= min 2 (List.length correctWords)
