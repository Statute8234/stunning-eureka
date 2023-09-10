using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slotScript : MonoBehaviour
{
    public List<Sprite> images;
    public Image buttonImage;

    void Start()
    {
        RandomizeImages();
    }

    public void RandomizeImages()
    {
        // Check if the images list is not empty
        if (images.Count > 0)
        {
            // Shuffle the list of images
            Shuffle(images);

            // Set the button's image to a random image from the shuffled list
            if (buttonImage != null)
            {
                int randomIndex = Random.Range(0, images.Count);
                buttonImage.sprite = images[randomIndex];
            }
            float value = Random.Range(0f, 1f);
            Color lerpedColor = Color.Lerp(Color.green, Color.red, value);
            
            // Set the button's color
            buttonImage.color = lerpedColor;

            // You can also add color changing logic here if needed
        }
        else
        {
            Debug.LogWarning("Images list is empty. Add images to the list.");
        }
    }

    private void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
