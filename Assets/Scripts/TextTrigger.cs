using UnityEngine;
using TMPro;

public class TextTrigger : MonoBehaviour
{
    public GameObject uiTextObject;
    public TextMeshProUGUI promptText;
    public string messageToShow = "Press E to interact";

    [Header("Audio")]
    public AudioSource uiPopSound; // Assign a small "blip" or "click" sound

    void Start()
    {
        uiTextObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            promptText.text = messageToShow;
            uiTextObject.SetActive(true);

            // Play the UI sound effect
            if (uiPopSound != null)
            {
                uiPopSound.Play();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            uiTextObject.SetActive(false);
        }
    }
}