using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats {

    public int Brawn { get; private set; }
    public int Speed { get; private set; }
    public int Brains { get; private set; }
    public int Guile { get; private set; }
    public int Toughness { get; private set; }

    public Stats()
    {
        Brawn = Random.Range(3, 19);
        Speed = Random.Range(3, 19);
        Brains = Random.Range(3, 19);
        Guile = Random.Range(3, 19);
        Toughness = Random.Range(3, 19);
    }


}
