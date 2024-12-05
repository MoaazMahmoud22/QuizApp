# QuizAppTest

A simple interactive quiz application built using **F#** and **Windows Forms**. This application allows users to answer multiple-choice and written questions, tracks their scores, and provides feedback upon completion. 

## Features

- **User Input:** Users provide their name before starting the quiz.
- **Mixed Question Types:** 
  - Multiple-choice questions (MCQs) with radio button options.
  - Written answer questions with flexible matching (e.g., case-insensitive and partial word matches).
- **Score Tracking:** The application tracks the user's score, increasing it for correct answers.
- **Feedback:** At the end of the quiz, the user's final score is displayed.
- **Responsive UI:** Supports switching between MCQs and written answer formats dynamically.

## How It Works

1. The user starts by entering their name.
2. The application presents one question at a time:
   - **MCQs:** The user selects an answer using radio buttons.
   - **Written Questions:** The user types their answer into a text box.
3. The application checks if the answer is correct:
   - For MCQs, it matches the selected option exactly.
   - For written answers, it uses case-insensitive matching and allows partial matches (e.g., at least 2 words must match).
4. The score is updated for each correct answer.
5. At the end of the quiz, the user's name and final score are displayed.

## Technologies Used

- **Language:** [F#](https://fsharp.org/) - Functional-first programming language in the .NET ecosystem.
- **UI Framework:** Windows Forms - For creating the graphical user interface.
