using UnityEngine;

public class Duck : MonoBehaviour, IInteractable
{
    // Adding [SerializeField] lets you see it in the Inspector 
    // without making it public to other scripts.
    [SerializeField] private AudioSource duckSound;

    private void Awake()
    {
        // If you forgot to drag the source in, this tries to find it automatically
        if (duckSound == null)
        {
            duckSound = GetComponent<AudioSource>();
        }
    }

    public bool CanInteract()
    {
        return true;
    }

    public void Interact()
    {
        if (duckSound != null)
        {
            // Reset the pitch slightly for a "random" quack effect
            duckSound.pitch = Random.Range(0.8f, 1.2f);
            duckSound.Play();
        }

        // Optional: If this is part of your objectives
        // ObjectiveManager.Instance.AddProgress("Squeeze the Duck");
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}