using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pressMenuButtons : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenu; 
    [SerializeField] private GameObject pauseButton; 
    public GlobalScript lvlCount; 
    // Start is called before the first frame update
    void Start()
    {
        lvlCount = FindObjectOfType<GlobalScript>(); 
        pauseMenu.SetActive(false); 
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
}
