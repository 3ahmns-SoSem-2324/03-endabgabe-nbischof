# 03-endabgabe-nbischof

Spielanleitung:

FizzBuzz ist ein Lernspiel in dem Personen die Teilbarkeitsregeln von 3 & 5 lernen können. Die Person bekommt eine zufällige Zahl. Wenn eine Zahl durch 3 teilbar ist, ist es "fizz", wenn sie durch 5 teilbar ist "buzz", wenn sie durch beide Zahlen teilbar ist "FizzBuzz" und wenn sie durch keine der beiden teilbar ist, passiert nichts.

Spielsteuerung:

Taste W = "FizzBuzz"
Taste A = "Buzz"
Taste S = keine Zahl
Taste D = "Fizz"

Feedback Fragebogen:

Alle Befragten fanden das UX verständlich, jedoch nicht kreativ gestaltet. 2 von 3 Befragten würden sich ein Feedback in dem Spiel wünschen, wenn es falsch ist und was es endgültig ist. Alle behaupteten, dass das Spiel nach ein paar Mal spielen langweilig wird. Bei keinem der Befragten ist ein Fehler oder Absturz aufgetaucht.

classDiagram
    MonoBehaviour <|-- FizzBuzz

    class MonoBehaviour{

    }
    class FizzBuzz {
        +TextMeshProUGUI zufZahl
        +TextMeshProUGUI[] infoTexts
        +TMP_Text resultText
        +Image panel


    }
    class FizzBuzz {
        +TextMeshProUGUI zufZahl
        +TextMeshProUGUI[] infoTexts
        +TMP_Text resultText
        +Image panel
        -int randomNumber
        -void Start()
        -IEnumerator ShowInfoTextForSeconds(TextMeshProUGUI textObject, string text, float seconds)
        -string GetNextMessage(int index)
        -void GenerateRandomNumber()
        +void PrintRandomNumber()
        -void ChangePanelColor(Color color)
        -void ShowResultText(string message, Color color)
        -void WaitForInput(KeyCode expectedKey, string message, Color color)
        -IEnumerator WaitForKeyPress(KeyCode expectedKey, string message, Color color)
    }

    FizzBuzz : -void Start()
    FizzBuzz : +IEnumerator ShowInfoTextForSeconds(TextMeshProUGUI textObject, string text, float seconds)
    FizzBuzz : +string GetNextMessage(int index)
    FizzBuzz : -void GenerateRandomNumber()
    FizzBuzz : +void PrintRandomNumber()
    FizzBuzz : -void ChangePanelColor(Color color)
    FizzBuzz : -void ShowResultText(string message, Color color)
    FizzBuzz : -void WaitForInput(KeyCode expectedKey, string message, Color color)
    FizzBuzz : +IEnumerator WaitForKeyPress(KeyCode expectedKey, string message, Color color)
