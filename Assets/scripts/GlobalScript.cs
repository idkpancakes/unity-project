using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GlobalScript : MonoBehaviour
{
 
    public int lvlCounter = 0; 

    public int fishCount = 0; 

    public int levelPebbles = 0; 

    public float levelTime = 0.0f; 

    public int totalPebbles = 0; 
    public int totalFish = 0; 

 


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
    }
}