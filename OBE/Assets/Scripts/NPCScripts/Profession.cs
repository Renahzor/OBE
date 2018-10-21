using System;
using System.Collections.Generic;
using UnityEngine;

public enum Professions { Villager, Blacksmith, Armorer, Alchemist, Innkeeper, Brewer, Barkeep, Scholar }

public class ProfessionScript {

    bool isAdventurer = false;

    public Dictionary<Professions, int> professionExperience { get; private set; }
    public Dictionary<Professions, int> professionLevels { get; private set; }

    public Professions assignedProfession { get; private set; }

    public ProfessionScript(int startingLevel, Stats stats)
    {
        professionExperience = new Dictionary<Professions, int>();
        professionLevels = new Dictionary<Professions, int>();

        foreach (var profType in Enum.GetValues(typeof(Professions)) )
        {
            professionExperience.Add((Professions)profType, 0);
            professionLevels.Add((Professions)profType, 1);
        }

        assignedProfession = Professions.Villager;
    }

    public void AddXP(int quantity, Professions prof)
    {
        professionExperience[prof] += quantity;

        if (professionExperience[prof] >= (int)(4 * Mathf.Pow(professionLevels[prof], 3)) / 5)
            professionLevels[prof]++;

        return;

    }

    public void SwitchProfession(Professions newProfession)
    {
        assignedProfession = newProfession;
    }

    public int GetProfessionLevel(Professions profession)
    {
        return professionExperience[profession];
    }

}
