using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressButton : MonoBehaviour
{
    
    [SerializeField] private GameObject pauseMenu; 
    [SerializeField] private GameObject pauseButton; 
    public GlobalScript globalScript; 
    // Start is called before the first frame update
    void Start()
    {
        globalScript = FindObjectOfType<GlobalScript>(); 
        pauseMenu.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pressPlay() {
     
     
       
        SceneManager.LoadScene("lvlOne"); 
    }

    public void pressRules() {
        SceneManager.LoadScene("Rules"); 
    }

     public void pressSettings() {
        SceneManager.LoadScene("Settings"); 
    }

    public void pressReturn() {
        globalScript.lvlCounter = 0; 
        globalScript.totalFish = 0; 
        globalScript.fishCount = 0; 
        globalScript.levelPebbles = 0; 
        globalScript.totalPebbles = 0; 
        
        SceneManager.LoadScene("Menu"); 
    }


    public void pressQuit() {
      Application.Quit();
    }

    public void pressPause() {
        Time.timeScale = 0f; 
        pauseMenu.SetActive(true); 
        pauseButton.SetActive(false); 
    }

    public void pressContinue() {
        Time.timeScale = 1.0f; 
        pauseMenu.SetActive(false); 
        pauseButton.SetActive(true); 
    }

    public void nextLevel() {
      
        int levelCount = globalScript.lvlCounter; 
        globalScript.levelPebbles = 0; 
             globalScript.fishCount = 0; 
             

       if(levelCount == 1 )
       { SceneManager.LoadScene("LevelTwo"); 
       
      
       } else if (levelCount == 2) {
           SceneManager.LoadScene("LevelThree");

       } else if(levelCount == 3) {
           // globalScript.lvlCounter++;
           SceneManager.LoadScene("LevelFour");
       } else if (levelCount == 4) {
           SceneManager.LoadScene("Win"); 
       }
    }
}
