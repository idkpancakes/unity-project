using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressMenuButtons : MonoBehaviour
{

    
    public GlobalScript lvlCount; 
    // Start is called before the first frame update
    void Start()
    {
        lvlCount = FindObjectOfType<GlobalScript>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pressPlay() {
        lvlCount.lvlCounter++; 
        SceneManager.LoadScene("lvlOne"); 
    }

    public void pressRules() {
        SceneManager.LoadScene("Rules"); 
    }

     public void pressSettings() {
        SceneManager.LoadScene("Settings"); 
    }

    public void pressReturn() {
        SceneManager.LoadScene("Menu"); 
    }


    public void pressQuit() {
      Application.Quit();
    }
}
