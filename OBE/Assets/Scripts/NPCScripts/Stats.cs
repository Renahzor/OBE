using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats {

    public Dictionary<string, int> StatsList { get; private set; }

    public Stats()
    {
        StatsList = new Dictionary<string, int>();
        StatsList.Add("Brawn", Random.Range(3, 19));
        StatsList.Add("Speed", Random.Range(3, 19));
        StatsList.Add("Brains", Random.Range(3, 19));
        StatsList.Add("Guile", Random.Range(3, 19));
        StatsList.Add("Toughness", Random.Range(3, 19));
    }


}
