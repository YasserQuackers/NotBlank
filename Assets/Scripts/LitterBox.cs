using UnityEngine;
using UnityEngine.Tilemaps;

public class LitterBox : MonoBehaviour, IInteractable
{
    public TilemapRenderer tilemapRenderer;
    public TilemapRenderer cleanedTiles;
    public GameObject textTrigger;
    public LitterBoxManager lbManager;

    [Header("Audio")]
    public AudioSource scoopAudioSource; // Assign an AudioSource with a "scoop" sound

    private void Awake()
    {
        if (tilemapRenderer != null) tilemapRenderer.enabled = true;
        if (cleanedTiles != null) cleanedTiles.enabled = false;
    }

    public bool CanInteract()
    {
        return lbManager.canClean;
    }

    public void Interact()
    {
        // Play the sound right when the player interacts
        if (scoopAudioSource != null)
        {
            scoopAudioSource.Play();
        }

        CleanBox();
        ObjectiveManager.Instance.AddProgress("Clean Litter Box");
    }

    public void CleanBox()
    {
        if (tilemapRenderer != null) tilemapRenderer.enabled = false;
        if (cleanedTiles != null) cleanedTiles.enabled = true;
        textTrigger.SetActive(false);
        lbManager.canClean = false;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}