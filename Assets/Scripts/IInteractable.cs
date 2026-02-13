
using UnityEngine;

public interface IInteractable
{
    void Interact();
    bool CanInteract();
    Vector3 GetPosition();
}
