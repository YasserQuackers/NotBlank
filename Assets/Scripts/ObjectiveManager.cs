using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public static ObjectiveManager Instance;

    public List<Objective> objectives = new List<Objective>();
    public Objective lastObjective;

    public Transform objectiveContainer;
    public GameObject objectiveText;

    private List<TextMeshProUGUI> objectiveTexts = new List<TextMeshProUGUI>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CreateObjectiveUI();
        UpdateUI();
    }

    private bool finalObjectiveShown = false;

    private void Update()
    {
        if (AllObjectivesCompleted() && !finalObjectiveShown)
        {
            ShowLastObjectiveOnly();
            finalObjectiveShown = true;
        }
    }


    public void AddProgress(string description, int amount = 1)
    {
        foreach (var obj in objectives)
        {
            if (obj.description == description)
            {
                obj.currentAmount += amount;

                if (obj.isCompleted)
                {
                    Debug.Log("Objective Completed: " + obj.description);
                }

                UpdateUI();
                return;
            }
        }

        Debug.LogWarning("Objective not found: " + description);
    }

    private void CreateObjectiveUI()
    {
        float yOffset = -30f;

        for (int i = 0; i < objectives.Count; i++)
        {
            GameObject newText = Instantiate(objectiveText, objectiveContainer);
            TextMeshProUGUI tmp = newText.GetComponent<TextMeshProUGUI>();

            RectTransform rect = newText.GetComponent<RectTransform>();

            float baseX = rect.anchoredPosition.x;
            float baseY = rect.anchoredPosition.y;

            rect.anchoredPosition = new Vector2(baseX, baseY + (i * yOffset));

            objectiveTexts.Add(tmp);
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < objectives.Count; i++)
        {
            Objective obj = objectives[i];
            TextMeshProUGUI text = objectiveTexts[i];

            text.text = obj.description + "  (" + obj.currentAmount + " / " + obj.requiredAmount + ")";

            if (obj.isCompleted)
            {
                text.color = Color.green;
            }
            else
            {
                text.color = Color.white;
            }
        }
    }

    public bool AllObjectivesCompleted()
    {
        foreach (var obj in objectives)
        {
            if (!obj.isCompleted)
            {
                return false;
            }
        }

        return true;
    }
    private void ClearObjectiveUI()
    {
        foreach (Transform child in objectiveContainer)
        {
            Destroy(child.gameObject);
        }

        objectiveTexts.Clear();
    }

    private void ShowLastObjectiveOnly()
    {
        ClearObjectiveUI();

        GameObject newText = Instantiate(objectiveText, objectiveContainer);
        TextMeshProUGUI tmp = newText.GetComponent<TextMeshProUGUI>();

        tmp.enabled = true;
        tmp.text = lastObjective.description;
        tmp.color = Color.red;

        objectiveTexts.Add(tmp);
    }


}
