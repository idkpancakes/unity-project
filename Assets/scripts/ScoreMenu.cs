using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMenu : MonoBehaviour
{

    public GlobalScript global; 

    [SerializeField] GameObject fishOne; 

    [SerializeField] GameObject fishTwo; 
    
    [SerializeField] GameObject fishThree; 

    
    



    // Start is called before the first frame update
    void Start()
    {
        global = FindAnyObjectByType<GlobalScript>();

        fishOne.SetActive(false); 
        fishTwo.SetActive(false); 
        fishThree.SetActive(false); 

         if(global.fishCount == 1) {
            fishOne.SetActive(true);

            

        } else if(global.fishCount == 2) {
            fishOne.SetActive(true);
            fishTwo.SetActive(true);
            
        } else if ( global.fishCount == 3) {
             fishOne.SetActive(true);
            fishTwo.SetActive(true);
            fishThree.SetActive(true); 

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
