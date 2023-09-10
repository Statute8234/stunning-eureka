using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class DayActivitysScript : MonoBehaviour
{
    public leverScript lever;
    public List<GameObject> buttons;
    public TextMeshProUGUI textMeshProText;
    public ActivityListsScript activityListsScript;
    private int currentListIndex = 0;
    private bool codePieceExecuted = false;

    void Update()
    {
        if (!lever.canClick)
        {
            textMeshProText.text = "";
            codePieceExecuted = false;
        }
        else if (!codePieceExecuted)
        {
            bool allButtonsAreBlack = false; // Initialize as false

            foreach (var button in buttons)
            {
                Image buttonImage = button.GetComponent<Image>();

                if (buttonImage != null && buttonImage.sprite != null)
                {
                    string imageName = buttonImage.sprite.name;

                    // Check if the button's color is black
                    if (buttonImage.color == Color.black)
                    {
                        allButtonsAreBlack = true; // At least one black button found
                    }

                    // Display image text for non-black buttons
                    if (imageName == "add-user" && currentListIndex == 0 && buttonImage.color != Color.black)
                    {
                        int index = CalculateButtonEmotionIndex(buttonImage.color);
                        textMeshProText.text += activityListsScript.DailyActivity[currentListIndex][index] + " ";
                    }
                    currentListIndex++;

                    if (imageName == "amenities" && currentListIndex == 1 && buttonImage.color != Color.black)
                    {
                        int index = CalculateButtonEmotionIndex(buttonImage.color);
                        textMeshProText.text += activityListsScript.DailyActivity[currentListIndex][index] + " ";
                    }
                    currentListIndex++;

                    if (imageName == "budget" && currentListIndex == 2 && buttonImage.color != Color.black)
                    {
                        int index = CalculateButtonEmotionIndex(buttonImage.color);
                        textMeshProText.text += activityListsScript.DailyActivity[currentListIndex][index] + " ";
                    }
                }

                currentListIndex = 0;
            }

            if (allButtonsAreBlack)
            {
                textMeshProText.text = "Sorry, you lost the game";
            }
            codePieceExecuted = true;
        }
    }

    int CalculateButtonEmotionIndex(Color buttonColor)
    {
        int closestIndex = -1;
        float closestDistance = float.MaxValue;
        List<string> currentList = activityListsScript.DailyActivity[currentListIndex];

        for (int i = 0; i < currentList.Count; i++)
        {
            float greenValue = buttonColor.g;
            float redValue = buttonColor.r;

            int index = Mathf.RoundToInt((1f - greenValue) * (currentList.Count - 1));

            float distanceToIndex = Mathf.Abs(index - redValue * (currentList.Count - 1));

            if (distanceToIndex < closestDistance)
            {
                closestIndex = index;
                closestDistance = distanceToIndex;
            }
        }

        return closestIndex;
    }
}
