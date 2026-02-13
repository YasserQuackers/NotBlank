using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bed : MonoBehaviour, IInteractable
{
    private bool allObjFin;
    public ObjectiveManager objMgr;
    public string sceneName;

    private void Update()
    {
        allObjFin = objMgr.AllObjectivesCompleted();
    }
    public bool CanInteract()
    {
        return allObjFin;
    }
    public void Interact()
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Load next level");
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
