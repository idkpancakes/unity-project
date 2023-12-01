using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D ground;

    private float moveSpeed = 2.5f;

    private Vector2 leftBound;
    private Vector2 rightBound;
    private Vector2 targetDir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        var gBound = ground.bounds;


        // needs to take into account the offsets

        rightBound = (Vector2)gBound.center + (Vector2)gBound.extents;
        leftBound = new Vector2(rightBound.x - gBound.size.x, rightBound.y);

        // Debug.Log("leftBound " + leftBound.x);
        // Debug.Log("rightBound " + rightBound.x);
        
        targetDir = UnityEngine.Random.value > 0.5f ? Vector2.left : Vector2.right;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 rbPos = rb.position;
        
        if(rb.position.x < leftBound.x) {
            targetDir = Vector2.right;
        }
        else if (rb.position.x > rightBound.x) {
            targetDir = Vector2.left;
        }

        rb.velocity = targetDir * moveSpeed;
    
        // Debug.DrawLine(leftBound, leftBound + Vector2.up, Color.green, 0.5f);
        // Debug.DrawLine(rightBound, rightBound + Vector2.up, Color.green, 0.5f);
    }
}