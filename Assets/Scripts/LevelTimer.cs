using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{

    private GlobalScript global; 

    public float endLevelTime;

    [SerializeField] TextMeshProUGUI timerT;

    // Start is called before the first frame update
    void Start()
    {
        global = FindObjectOfType<GlobalScript>(); 

        // endLevelTime = 20.0f; 
    }

    // Update is called once per frame
    void Update()
    {

        endLevelTime -= Time.deltaTime; 

        timerT.text = "Time: " + endLevelTime; 

        if(endLevelTime <= 0.0f) {
            timerEnd(); 
        }
        
    }


    public void timerEnd() {
        SceneManager.LoadScene("YouDied"); 
        DestroyImmediate(this); 
    }
}
