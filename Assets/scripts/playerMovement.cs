using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



public class playerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D ground;
    [SerializeField] [Range(0.0f, 100.0f)] private float horizontalSpeed = 30;
    [SerializeField] private float verticalSpeed = 1000;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI fishText; 

    private int pickupCount = 0;

    
    private int fishCount = 0;

    private  GlobalScript fishFinal; 

    public float friction = 0.5f; 


    // Start is called before the first frame update
    void Start()
    {

        fishFinal = FindAnyObjectByType<GlobalScript>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(Input.GetKeyDown("space")){
            SceneManager.LoadScene("Transition"); 
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0) {
            
            Vector2 fuckingBitches = new Vector2((horizontal * horizontalSpeed), rb.velocity.y); 
            
                rb.velocity =  Vector2.Lerp(rb.velocity, fuckingBitches , Time.fixedDeltaTime);

                Debug.Log(Time.fixedDeltaTime + " is moving"); 

    
            }



        if(rb.IsTouching(ground) && horizontal == 0 ) {

            Vector2 name  = new Vector2(0, rb.velocity.y); 

             rb.velocity = Vector2.Lerp(rb.velocity, name, Time.fixedDeltaTime); 
             Debug.Log(Time.fixedDeltaTime + " is not moving"); 
            
        } 
        
         if (rb.IsTouching(ground) && vertical > 0)
        {
             rb.AddForce(Vector2.up * (vertical * verticalSpeed));
        }
    }

     private void OnCollisionEnter2D(Collision2D other )
    {


        if (other.gameObject.CompareTag("PickupItem") == true) {
            pickupCount++;
            scoreText.text = "Score: " + pickupCount;
            Destroy(other.gameObject);
            return; 

        }

        
        if(other.gameObject.CompareTag("fish") == true){

      
            fishCount++; 
            fishText.text = "Fish: " + fishCount;

            fishFinal.fishCount = fishCount; 

            Destroy(other.gameObject);
             Debug.Log(fishCount);

             return; 
        }

        
        // ...and got a little worried! -- get downs so gooooood
        Debug.Log(pickupCount);
    }

/*
    private void collectFish(Collision2D other) {

       
        if(other.gameObject.CompareTag("fish") == true){

      
            fishCount++; 
            fishText.text = "Fish: " + fishCount;

            fishFinal.fishCount = fishCount; 

            Destroy(other.gameObject);
             Debug.Log(fishFinal.fishCount);
        
        }
    }

    */
    
}

