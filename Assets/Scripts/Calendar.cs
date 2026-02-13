using UnityEngine;

public class Calendar : MonoBehaviour, IInteractable
{
    public GameObject calendarView;
    public PlayerMovement playerMovement;

    private bool isOpen = false;

    public bool CanInteract()
    {
        return true;
    }

    public void Interact()
    {
        isOpen = !isOpen;
        calendarView.SetActive(isOpen);

        playerMovement.canMove = !isOpen;
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
