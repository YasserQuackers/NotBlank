using UnityEngine;

public class Feesh : MonoBehaviour, IInteractable
{
    [HideInInspector] 
    public bool isTaken = false;
    public FoodManager foodManager;
    public bool CanInteract()
    {
        return !isTaken;
    }

    public void Interact()
    {
        isTaken = true;
        foodManager.canFill = isTaken;
        gameObject.SetActive(false);
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }

}
