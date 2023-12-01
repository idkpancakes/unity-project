using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoring : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI pebbleSoreText; 

    [SerializeField] TextMeshProUGUI fishScoreText; 

    [SerializeField] TextMeshProUGUI levelCounterText; 

    public GlobalScript global; 
    // Start is called before the first frame update
    void Start()
    {
        global = FindAnyObjectByType<GlobalScript>(); 
       

        pebbleSoreText.text =  global.totalPebbles + ""; 
        fishScoreText.text =  global.totalFish + ""; 

        var displayLevel = global.lvlCounter + 1;

        levelCounterText.text = "You reached level " + displayLevel; 

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
