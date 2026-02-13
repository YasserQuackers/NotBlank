using UnityEngine;

public class LitterBoxManager : MonoBehaviour
{
    [HideInInspector]
    public bool canClean;

    private void Start()
    {
        canClean = true;
    }
}
