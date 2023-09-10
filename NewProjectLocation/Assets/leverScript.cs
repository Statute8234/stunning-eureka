using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leverScript : MonoBehaviour
{
    public List<Button> slots; // Public list of buttons (slots)
    public  bool canClick = true;
    private Vector3 originalScale;
    private Quaternion originalRotation;
    private Vector3 activatedRotation = new Vector3(0f, 0f, -180f);
    private Vector3 activatedScale = new Vector3(-1f, 1f, 1f);
    public float animationDuration = 1f;
    public float delayDuration = 1f;
    public float randomizeInterval = 0f; // Time between RandomizeImages calls
    // Audio
    public AudioClip spinningAudioClip;
    public AudioClip winningAudioClip;
    private AudioSource spinningAudioSource;
    private AudioSource winningAudioSource;
    // change color
    public GameEndingScript gameEndingScript; 
    private void Start()
    {
        gameEndingScript = FindObjectOfType<GameEndingScript>();
        // Initialize the AudioSource and stop the audio at the start
        spinningAudioSource = gameObject.AddComponent<AudioSource>();
        winningAudioSource = gameObject.AddComponent<AudioSource>();
        spinningAudioSource.clip = spinningAudioClip;
        winningAudioSource.clip = winningAudioClip;
        spinningAudioSource.Stop();
        winningAudioSource.Stop();
        // lever main
        originalScale = transform.localScale;
        originalRotation = transform.rotation;

        // Find all buttons in children
        Button[] buttonsInScene = GetComponentsInChildren<Button>();
        foreach (var button in buttonsInScene)
        {
            button.onClick.AddListener(() => OnClickButton(button));
        }
    }

    private void OnClickButton(Button clickedButton)
    {
        if (canClick)
        {
            canClick = false;
            StartCoroutine(AnimateButton(clickedButton));
        }
    }

    public IEnumerator AnimateButton(Button clickedButton)
    {
        // Change button's rotation and scale when activated
        clickedButton.transform.rotation = Quaternion.Euler(activatedRotation);
        clickedButton.transform.localScale = activatedScale;
        // Wait for the animation duration
        yield return new WaitForSeconds(animationDuration);
        // Play the audio
        spinningAudioSource.Play();
        // Check if lever's position and rotation meet the criteria
        if (transform.rotation == Quaternion.Euler(0f, 0f, -180f))
        {
            // Trigger RandomizeImages() for all associated slot scripts
            while (spinningAudioSource.isPlaying)
            {
                foreach (var slot in slots)
                {
                    slotScript slotScriptComponent = slot.GetComponent<slotScript>();
                    if (slotScriptComponent != null)
                    {
                        slotScriptComponent.RandomizeImages();
                        Button slotButton = slot.GetComponent<Button>();
                        Color newColor = new Color(0f, 0f, 0f); // Change this to the desired color
                        gameEndingScript.ChangeSlotColor(slotButton, newColor);
                        yield return new WaitForSeconds(randomizeInterval);
                    }
                }
            }
        }
        spinningAudioSource.Stop();
        winningAudioSource.Play();
        // Wait for a brief delay to prevent immediate re-click
        yield return new WaitForSeconds(delayDuration);
        // Reset the button's rotation to its original state
        clickedButton.transform.rotation = originalRotation;
        clickedButton.transform.localScale = originalScale;
        // Play the end audio when done spinning
        winningAudioSource.Stop();
        // Allow the button to be clicked again
        canClick = true;
        // Stop the audio when done spinning
    }
}
