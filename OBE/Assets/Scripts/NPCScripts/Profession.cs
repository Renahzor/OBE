using System;
using System.Collections.Generic;
using UnityEngine;

public enum Professions { Villager, Blacksmith, Armorer, Alchemist, Leatherworker, Innkeeper, Brewer, Barkeep, Scholar }

public class ProfessionScript {

    bool isAdventurer = false;

    public Dictionary<Professions, int> professionExperience { get; private set; }
    public Dictionary<Professions, int> professionLevels { get; private set; }

    public Professions assignedProfession { get; private set; }

    public ProfessionScript(int startingLevel, Stats stats)
    {
        professionExperience = new Dictionary<Professions, int>();
        professionLevels = new Dictionary<Professions, int>();

        int maxProfession = 4;

        //I want a random distribution of profession levels from 0-3, with no more than one level 3 profession
        //I create a list of random ints, randomly select and remove those from the list to apply to the
        //different professions.
        List<int> professionLvlRandom = new List<int>();
        for (int i = 0; i < Enum.GetValues(typeof (Professions)).Length; i++)
        {
            int numberToAdd = UnityEngine.Random.Range(0, maxProfession);
            if (numberToAdd == 3)
                maxProfession = 3;
            professionLvlRandom.Add(numberToAdd);
        }

        foreach (var profType in Enum.GetValues(typeof(Professions)) )
        {
            professionExperience.Add((Professions)profType, 0);

            if ((Professions)profType == Professions.Villager)
                professionLevels.Add((Professions)profType, 1);

            else
            {
                int proflvl = professionLvlRandom[UnityEngine.Random.Range(0, professionLvlRandom.Count)];
                professionLevels.Add((Professions)profType, proflvl);
                professionLvlRandom.Remove(proflvl);
            }

        }

        //New NPCs start as villagers unless overwitten specifically.
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
