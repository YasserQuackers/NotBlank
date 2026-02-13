using UnityEngine;

public class Dish : MonoBehaviour, IInteractable
{
    private bool isCleaned = false;
    public GameObject DirtyDish;
    public GameObject CleanDish;

    [Header("Audio")]
    public AudioSource dishAudioSource; // Assign an AudioSource here

    public bool CanInteract()
    {
        return !isCleaned;
    }

    public void Interact()
    {
        DirtyDish.SetActive(false);
        CleanDish.SetActive(true);
        isCleaned = true;

        if (dishAudioSource != null)
        {
            dishAudioSource.Play();
        }

        ObjectiveManager.Instance.AddProgress("Do Dishes");
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}