using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class Mystery_Temple : MonoBehaviour
{
    [SerializeField] private Button[] btns;
    [SerializeField] private Button btnEnter;
    [SerializeField] private string chars = "EHILMNPRST"; // Possible characters
    [SerializeField] private string RIGHTANSWER = "SHRINE"; // Correct answer
    [SerializeField] private GameView view;

    private List<int> currentIndexes = new List<int>(); // Tracks the current index of each button's character
    private List<TextMeshProUGUI> texts = new List<TextMeshProUGUI>(); // Text objects to display characters on buttons
    private bool unlocked = false; // To track if the correct answer has been unlocked

    void Start()
    {
        // Initialize each button with its corresponding settings
        for (int i = 0; i < btns.Length; i++)
        {
            currentIndexes.Add(0); // Start with the first character
            TextMeshProUGUI buttonText = btns[i].GetComponentInChildren<TextMeshProUGUI>();
            texts.Add(buttonText); // Store the TextMeshProUGUI reference for later use

            int index = i; // Capture the current loop variable
            btns[i].onClick.AddListener(() => OnButtonClick(index)); // Add listener to the button
        }

        // Add a listener to the enter button
        btnEnter.onClick.AddListener(CheckAnswer);
    }

    // Method called when a button is clicked
    void OnButtonClick(int index)
    {
        // Increment the current index and loop back if it exceeds the available characters
        currentIndexes[index] = (currentIndexes[index] + 1) % chars.Length;
        texts[index].text = chars[currentIndexes[index]].ToString(); // Update the displayed character
    }

    // Method to check if the current combination matches the correct answer
    void CheckAnswer()
    {
        string currentAnswer = "";
        for (int i = 0; i < texts.Count; i++)
        {
            currentAnswer += texts[i].text;
        }

        if (currentAnswer == RIGHTANSWER)
        {
            Debug.Log("Correct");
            unlocked = true;
            view.SetMystery(false);
            view.SetStory2(true);
        }
        else
        {
            Debug.Log("Incorrect");
        }
    }
}