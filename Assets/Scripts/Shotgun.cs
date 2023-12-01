using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    private Vector2 offset = new Vector2(1.025f, 0.05f);
    private Vector2 origin;
    
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        origin = transform.position + (Vector3)offset;

        // if(Input.GetButton("Fire1"))
        
    }
}
