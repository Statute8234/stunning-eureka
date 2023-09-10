using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndingScript : MonoBehaviour
{
    public List<Button> slots;
    public void ChangeSlotColor(Button slot, Color newColor)
    {
        int totalPossibilities = (98/6);
        Image slotImage = slot.GetComponent<Image>();
        if (slotImage != null)
        {
            int randint = Random.Range(0, totalPossibilities + 1);
            if (randint <= 1) 
            {
                slotImage.color = newColor;
            }
        }
    }
}
