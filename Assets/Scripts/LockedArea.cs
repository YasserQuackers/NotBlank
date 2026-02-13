using Unity.VisualScripting;
using UnityEngine;

public class LockedArea : MonoBehaviour
{
    public CameraSwitching camSwitch;
    public bool canEnterArea;
    public GameObject areaLock;

    private void Start()
    {
        Decide();
    }

    public void Decide()
    {
        if (!canEnterArea)
        {
            camSwitch.enabled = false;
            areaLock.SetActive(true);
        }
        else
        {
            camSwitch.enabled = true;
            areaLock.SetActive(false);
        }

    }
}
