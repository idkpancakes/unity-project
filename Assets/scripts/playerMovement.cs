using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] [Range(0.0f, 100.0f)] private float horizontalSpeed = 25;
    [SerializeField] private float verticalSpeed = 10;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI fishText;

    private Camera cam;
    private Animator _animator;


    private int pickupCount = 0;
    private int fishCount = 0;

    private GlobalScript globalScript;
    public float friction = 0.5f;


    private float JUMP_DELAY = 0.10f;
    private float sinceJump = 0f;

    private Vector2 CameraOffsetVector2 = new Vector2(3.5f, 2.5f);

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        globalScript = FindAnyObjectByType<GlobalScript>();

        cam = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("Transition");
        }

        /*
         * Please reformat and simplify! 
         */

        if (cam.transform.position.x - rb.position.x > CameraOffsetVector2.x)
        {
            cam.transform.position = new Vector3(rb.position.x + CameraOffsetVector2.x, cam.transform.position.y,
                cam.transform.position.z);
        }
        else if (rb.position.x - cam.transform.position.x > CameraOffsetVector2.x)
        {
            cam.transform.position = new Vector3(rb.position.x - CameraOffsetVector2.x, cam.transform.position.y,
                cam.transform.position.z);
        }


        if (cam.transform.position.y - rb.position.y > CameraOffsetVector2.y)
        {
            cam.transform.position = new Vector3(cam.transform.position.x, rb.position.y + CameraOffsetVector2.y,
                cam.transform.position.z);
        }
        else if (rb.position.y - cam.transform.position.y > CameraOffsetVector2.y)
        {
            cam.transform.position = new Vector3(cam.transform.position.x, rb.position.y - CameraOffsetVector2.y,
                cam.transform.position.z);
        }
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        bool grounded = IsGrounded();
        if (grounded)
            sinceJump += Time.deltaTime;
        else
            transform.rotation = Quaternion.identity;

        if (horizontal != 0)
        {
            Vector2 targetPos =
                new Vector2((horizontal * horizontalSpeed) * (grounded ? 1 : 0.40f), rb.velocity.y);
            rb.velocity = Vector2.Lerp(rb.velocity, targetPos, Time.fixedDeltaTime);
            // Debug.Log(Time.fixedDeltaTime + " is moving");


            Vector3 scale = transform.localScale;

            // math! :)
            scale.x = Math.Abs(scale.x) * (Math.Abs(horizontal) / horizontal);
            transform.localScale = scale;
        }

        if (grounded && horizontal == 0)
        {
            Vector2 name = new Vector2(0, rb.velocity.y);
            rb.velocity = Vector2.Lerp(rb.velocity, name, Time.fixedDeltaTime);
            // Debug.Log(Time.fixedDeltaTime + " is not moving");
        }

        if (grounded && sinceJump > JUMP_DELAY && vertical > 0)
        {
            rb.AddForce(Vector2.up * (vertical * verticalSpeed), ForceMode2D.Impulse);
            sinceJump = 0.0f;
            Debug.Log("Please Jump!");
        }

        _animator.SetBool("Walking", horizontal != 0 && grounded);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PickupItem") == true)
        {
            pickupCount++;
            globalScript.totalPebbles++;

            globalScript.levelPebbles = pickupCount;
            scoreText.text = "Score: " + pickupCount;
            Destroy(other.gameObject);
            return;
        }

        if (other.gameObject.CompareTag("Fish") == true)
        {
            fishCount++;
            fishText.text = "Fish: " + fishCount;

            globalScript.fishCount = fishCount;
            globalScript.totalFish = fishCount;

            Destroy(other.gameObject);
            Debug.Log(fishCount);

            return;
        }

        if (other.gameObject.CompareTag("Flag") == true)
        {
            SceneManager.LoadScene("Transition");
            return;
        }
    }

    private bool IsGrounded()
    {
        // Setup our rays
        List<RaycastHit2D> rayList = new List<RaycastHit2D>();


        //0.000001f
        rayList.Add(Physics2D.Raycast(transform.position, Vector2.down, 1f)); // center ray
        rayList.Add(Physics2D.Raycast(transform.position, Vector2.down + Vector2.left, 1f)); // left ray
        rayList.Add(Physics2D.Raycast(transform.position, Vector2.down + Vector2.right, 1f)); // right ray

        Debug.DrawRay(transform.position, Vector2.down, Color.green);
        Debug.DrawRay(transform.position, Vector2.down + Vector2.left, Color.red);
        Debug.DrawRay(transform.position, Vector2.down + Vector2.right, Color.blue);


        foreach (RaycastHit2D ray in rayList)
        {
            // if null check next ray
            if (ray.collider == null)
                continue;

            var grounded = ray.collider.gameObject.CompareTag("Platform");

            if (grounded)
            {
                // Debug.DrawLine(ray.point, ray.point + ray.normal, Color.green);
                transform.rotation = Quaternion.FromToRotation(transform.up, ray.normal) * transform.rotation;
                Debug.DrawLine(transform.position, ray.point, Color.green);
            }

            return ray.collider.gameObject.CompareTag("Platform");
        }

        return false;
    }
}