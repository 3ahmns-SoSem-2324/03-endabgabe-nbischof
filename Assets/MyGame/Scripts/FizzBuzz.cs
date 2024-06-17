using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FizzBuzz : MonoBehaviour
{
    public TextMeshProUGUI zufZahl;
    public TextMeshProUGUI[] infoTexts;
    public TMP_Text resultText;
    public Image panel;
    private int randomNumber; private void Start()
    {
        StartCoroutine(ShowInfoTextForSeconds(infoTexts[0], "W drücken, wenn die Zahl durch 3&5 teilbar ist, um FIZZBUZZ zu sagen.", 5f));
    }

    private IEnumerator ShowInfoTextForSeconds(TextMeshProUGUI textObject, string text, float seconds)
    {
        textObject.text = text;
        yield return new WaitForSeconds(seconds);
        textObject.text = "";

        int index = System.Array.IndexOf(infoTexts, textObject);
        if (index < infoTexts.Length - 1)
            StartCoroutine(ShowInfoTextForSeconds(infoTexts[index + 1], GetNextMessage(index + 1), 5f));
        else
            PrintRandomNumber();
    }

    private string GetNextMessage(int index)
    {
        switch (index)
        {
            case 1: return "S drücken, wenn die Zahl durch 3 teilbar ist, um FIZZ zu sagen.";
            case 2: return "A drücken, wenn die Zahl durch 5 teilbar ist, um BUZZ zu sagen.";
            case 3: return "D drücken, wenn die Zahl durch nichts teilbar ist.";
            default: return "";
        }
    }

    private void GenerateRandomNumber()
    {
        randomNumber = Random.Range(1, 1000);
        zufZahl.text = randomNumber.ToString();
    }

    public void PrintRandomNumber()
    {
        ChangePanelColor(Color.grey);
        GenerateRandomNumber();

        try
        {
            int number = int.Parse(zufZahl.text);
            string message = " ";

            if (number % 3 == 0 && number % 5 == 0)
            {
                message = "FizzBuzz";
                WaitForInput(KeyCode.W, message, Color.green);
            }
            else if (number % 3 == 0)
            {
                message = "Fizz";
                WaitForInput(KeyCode.S, message, Color.green);
            }
            else if (number % 5 == 0)
            {
                message = "Buzz";
                WaitForInput(KeyCode.A, message, Color.green);
            }
            else
            {
                message = "keine Zahl";
                WaitForInput(KeyCode.D, message, Color.green);
            }
        }
        catch
        {
            ShowResultText("Leider falscher Input", Color.red);
        }
    }

    private void ChangePanelColor(Color color)
    {
        panel.color = color;
    }

    private void ShowResultText(string message, Color color)
    {
        resultText.text = message;
        ChangePanelColor(color);
    }

    private void WaitForInput(KeyCode expectedKey, string message, Color color)
    {
        StartCoroutine(WaitForKeyPress(expectedKey, message, color));
    }

    private IEnumerator WaitForKeyPress(KeyCode expectedKey, string message, Color color)
    {
        float elapsedTime = 0f;
        float waitTime = 10f;

        while (elapsedTime < waitTime)
        {
            if (Input.GetKeyDown(expectedKey))
            {
                ShowResultText(message, color);
                yield return new WaitForSeconds(1f);
                PrintRandomNumber();
                yield break;
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        ShowResultText("Zeit abgelaufen! Korrekte Taste nicht gedrückt.", Color.red);
        yield return new WaitForSeconds(1f);
    }
}