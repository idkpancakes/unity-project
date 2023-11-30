using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    private float Length, StartPos;

    [SerializeField] public GameObject cam;
    [SerializeField] private float parallexEffect;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position.x;
        Length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    

    // Update is called once per frame
    void Update()
    {
        float temp = cam.transform.position.x * (1 - parallexEffect);
        float distance = cam.transform.position.x * parallexEffect;
        transform.position = new Vector3(StartPos + distance, transform.position.y, transform.position.z);

        if (temp > StartPos + Length)
            StartPos += Length;
        else if (temp < StartPos - Length)
            StartPos -= Length;
    }
}