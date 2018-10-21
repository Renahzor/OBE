using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCNeeds{

    float hunger;
    float thirst;
    float social;
    float fun;
    float work;

    List<float> decayRates = new List<float>();

    public NPCNeeds(Professions profession, Stats stats)
    {
        hunger = Random.Range (50.0f, 95.0f);
        thirst = Random.Range(50.0f, 95.0f);
        social = Random.Range(50.0f, 95.0f);
        fun = Random.Range(50.0f, 95.0f);
        work = Random.Range(50.0f, 95.0f);

        decayRates.AddRange(new float[] { 0.25f, 0.25f, 0.25f, 0.25f, 0.25f });
    }

    public void DecayNeeds()
    {
        hunger -= (decayRates[0] * Time.deltaTime);
        thirst -= (decayRates[1] * Time.deltaTime);
        social -= (decayRates[2] * Time.deltaTime);
        fun -= (decayRates[3] * Time.deltaTime);
        work -= (decayRates[4] * Time.deltaTime);
    }
}
