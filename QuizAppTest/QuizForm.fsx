module QuizForm

open System
open System.Windows.Forms
open Models
open Questions
open Utilities

type QuizForm() as this =
    inherit Form()

    let nameLabel = new Label(Text = "Enter your name:", Top = 20, Left = 20, Width = 360)
    let nameInput = new TextBox(Top = 50, Left = 20, Width = 360)
    let startButton = new Button(Text = "Start Quiz", Top = 100, Left = 150)

    let questionLabel = new Label(Top = 20, Left = 20, Width = 360, Height = 60)
    let answerBox = new TextBox(Top = 120, Left = 20, Width = 360)
    let nextButton = new Button(Text = "Next", Top = 220, Left = 150)
    let radioPanel = new Panel(Top = 120, Left = 20, Width = 360, Height = 100)

    do
        this.Text <- "Quiz Application"
        this.Width <- 400
        this.Height <- 300

        this.Controls.Add(nameLabel)
        this.Controls.Add(nameInput)
        this.Controls.Add(startButton)

    let mutable userName = ""
    let mutable score = 0
    let mutable currentQuestion = 0

    let loadQuestion index =
        let question = questions.[index]
        questionLabel.Text <- question.QuestionText

        match question.Choices with
        | Some options ->
            radioPanel.Controls.Clear()
            options
            |> List.iteri (fun i choice ->
                let radioButton = new RadioButton(Text = choice, Top = i * 25, Left = 0, Width = 360)
                radioPanel.Controls.Add(radioButton)
            )
            radioPanel.Visible <- true
            answerBox.Visible <- false
        | None ->
            answerBox.Text <- ""
            answerBox.Visible <- true
            radioPanel.Visible <- false

    let getUserAnswer() =
        if radioPanel.Visible then
            radioPanel.Controls
            |> Seq.cast<RadioButton>
            |> Seq.tryFind (fun rb -> rb.Checked)
            |> Option.map (fun rb -> rb.Text)
        else
            if String.IsNullOrWhiteSpace(answerBox.Text) then None
            else Some (answerBox.Text.Trim())

    do
        startButton.Click.Add(fun _ ->
            userName <- nameInput.Text
            if userName = "" then
                MessageBox.Show("Please enter your name.") |> ignore
            else
                this.Controls.Clear()
                this.Controls.Add(questionLabel)
                this.Controls.Add(answerBox)
                this.Controls.Add(radioPanel)
                this.Controls.Add(nextButton)
                loadQuestion currentQuestion
        )

        nextButton.Click.Add(fun _ ->
            match getUserAnswer() with
            | Some userAnswer ->
                let question = questions.[currentQuestion]
                let isCorrect =
                    match question.Choices with
                    | Some _ -> userAnswer = question.CorrectAnswer
                    | None -> isAnswerCorrect userAnswer question.CorrectAnswer

                if isCorrect then score <- score + 1

                currentQuestion <- currentQuestion + 1

                if currentQuestion < questions.Length then
                    loadQuestion currentQuestion
                else
                    MessageBox.Show($"Thank you, {userName}! Your final score is {score}/{questions.Length}.") |> ignore
                    Application.Exit()
            | None ->
                MessageBox.Show("Please select or enter an answer.") |> ignore
        )
