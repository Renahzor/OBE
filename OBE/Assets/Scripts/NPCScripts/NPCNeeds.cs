using System.Collections;
using System.Collections.Generic;

public class NPCNeeds{

    float hunger;
    float thirst;
    float social;
    float materials;
    float work;

    List<float> decayRates = new List<float>();

    public NPCNeeds(Professions profession, Stats stats)
    {
        hunger = 85.0f;
        thirst = 85.0f;
        social = 85.0f;
        materials = 85.0f;
        work = 85.0f;

        decayRates.AddRange(new float[] { 1.0f, 1.0f, 1.0f, 1.0f, 1.0f });
    }
}
