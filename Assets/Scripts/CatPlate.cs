using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CatPlate : MonoBehaviour, IInteractable
{
    public FoodManager fm;
    public TilemapRenderer tilemapRenderer;
    public TilemapRenderer fullPlateTiles;
    public GameObject textTrigger;

    public Animator catAnimator;
    public AudioSource catAudioSource;

    private void Awake()
    {
        if (tilemapRenderer != null) tilemapRenderer.enabled = true;
        if (fullPlateTiles != null) fullPlateTiles.enabled = false;
    }

    public bool CanInteract()
    {
        return fm.canFill;
    }

    public void Interact()
    {
        PlaceFeesh();
    }

    public void PlaceFeesh()
    {
        if (!fm.canFill) return;

        if (tilemapRenderer != null) tilemapRenderer.enabled = false;
        if (fullPlateTiles != null) fullPlateTiles.enabled = true;
        textTrigger.SetActive(false);
        fm.canFill = false;
        ObjectiveManager.Instance.AddProgress("Feed Cat");

        if (catAnimator != null)
        {
            catAnimator.SetTrigger("Eat");
        }

        if (catAudioSource != null)
        {
            catAudioSource.Play();
        }
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
}