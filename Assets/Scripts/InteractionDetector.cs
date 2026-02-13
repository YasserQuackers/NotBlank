using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDetector : MonoBehaviour
{
    public GameObject interactionIcon;
    private List<IInteractable> interactablesInRange = new List<IInteractable>();
    private IInteractable closestInteractable = null;

    void Update()
    {
        UpdateClosestInteractable();
    }

    private void UpdateClosestInteractable()
    {
        IInteractable bestTarget = null;
        float closestDistanceSqr = float.MaxValue;
        Vector3 currentPos = transform.position;

        for (int i = interactablesInRange.Count - 1; i >= 0; i--)
        {
            IInteractable interactable = interactablesInRange[i];

            if (interactable == null || !interactable.CanInteract())
            {
                interactablesInRange.RemoveAt(i);
                continue;
            }

            float distSqr = (interactable.GetPosition() - currentPos).sqrMagnitude;
            if (distSqr < closestDistanceSqr)
            {
                closestDistanceSqr = distSqr;
                bestTarget = interactable;
            }
        }

        closestInteractable = bestTarget;

        if (closestInteractable != null)
        {
            interactionIcon.SetActive(true);
        }
        else
        {
            interactionIcon.SetActive(false);
        }
    }

    void Start()
    {
        interactionIcon.SetActive(false);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed && closestInteractable != null)
        {
            closestInteractable.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable))
        {
            if (!interactablesInRange.Contains(interactable))
            {
                interactablesInRange.Add(interactable);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable))
        {
            interactablesInRange.Remove(interactable);
        }
    }

}
