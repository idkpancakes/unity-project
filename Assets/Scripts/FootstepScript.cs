using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepScript : MonoBehaviour
{

    public  AudioClip playerWalkSound; 
    private AudioSource audioSrc; 

    public bool isWalking; 


    // Start is called before the first frame update
    void Start()
    {
        playerWalkSound = Resources.Load<AudioClip>("RunningSound"); 

    
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isWalking) {
            audioSrc.PlayOneShot(playerWalkSound); 
        }
        
    }

     private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();

    }

      public void StartWalking()
    {
        isWalking = true;
    }

    // Call this method when the player stops walking
    public void StopWalking()
    {
        isWalking = false;
    }
}
