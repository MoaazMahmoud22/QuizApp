module Main

open System
open System.Windows.Forms
open QuizForm

[<EntryPoint>]
let main _ = 
    Application.Run(new QuizForm())
    0
