using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameGenerator : MonoBehaviour {

    private List<string> maleFirstNames = new List<string>();
    private List<string> femaleFirstNames = new List<string>();
    private List<string> lastNames = new List<string>();


    public TextAsset maleNamesText;
    public TextAsset femaleNamesText;
    public TextAsset lastNamesText;

    void Awake()
    {
        var maleNameList = maleNamesText.text.Split('\n');
        var femaleNameList = femaleNamesText.text.Split('\n');
        var lastNameList = lastNamesText.text.Split('\n');

        maleFirstNames.AddRange(maleNameList);
        femaleFirstNames.AddRange(femaleNameList);
        lastNames.AddRange(lastNameList);
    }

    public string GetName(bool isMale)
    {
        if (isMale)
            return maleFirstNames[Random.Range(0, maleFirstNames.Count)] + " " + lastNames[Random.Range(0, lastNames.Count)];

        else
            return femaleFirstNames[Random.Range(0, femaleFirstNames.Count)] + " " + lastNames[Random.Range(0, lastNames.Count)];
    }

}
