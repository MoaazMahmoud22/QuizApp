module Questions

open Models

let questions = 
    [ { QuestionText = "What is the capital of Egypt?"
        Choices = Some ["Cairo"; "Alexandria"; "Luxor"; "Aswan"]
        CorrectAnswer = "Cairo" }
      { QuestionText = "What is the chemical formula for water?"
        Choices = None
        CorrectAnswer = "H2O" }
      { QuestionText = "Name a programming language that starts with 'P'."
        Choices = None
        CorrectAnswer = "Python" }
      { QuestionText = "What is an operating system?"
        Choices = None
        CorrectAnswer = "interface between the hardware and application programs" }]
