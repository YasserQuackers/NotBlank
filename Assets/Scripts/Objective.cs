using System;

[System.Serializable]
public class Objective
{
    public string description;

    public int currentAmount;
    public int requiredAmount;

    public bool isCompleted => currentAmount >= requiredAmount;

}

