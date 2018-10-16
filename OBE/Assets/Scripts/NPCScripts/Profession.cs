using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Professions { Villager, Blacksmith, Armorer, Alchemist, Innkeeper, Brewer, Barkeep, Scholar }

public class ProfessionScript {

    public Professions profession { get; private set; }

    public int level { get; private set; }
    public int experiencePoints { get; private set; }
    public int experienceToLevel { get; private set; }

    public ProfessionScript(int startingLevel)
    {
        profession = Professions.Villager;
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

    public void SwitchProfession(Professions newProfession)
    {
        profession = newProfession;
    }

}
