module Models

type Question = 
    { QuestionText: string
      Choices: string list option // Some for MCQs, None for written answers
      CorrectAnswer: string }
