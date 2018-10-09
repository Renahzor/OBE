using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profession {

    enum StartingProfessions { Villager }

    StartingProfessions startingProfession = StartingProfessions.Villager;

    public int level { get; private set; }
    public int experiencePoints { get; private set; }
    public int experienceToLevel { get; private set; }

    public Profession(int startingLevel)
    {
        level = startingLevel;
        experiencePoints = 0;
        experienceToLevel = 15;
    }

    public void AddXP(int quantity)
    {
        experiencePoints += quantity;
        if (experiencePoints >= experienceToLevel)
        {
            level++;
            experienceToLevel = (int) (4 * Mathf.Pow(level, 3)) / 5;
        }
        return;
    }

}
