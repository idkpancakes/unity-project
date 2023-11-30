using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    private Vector3 offset = new Vector3(0.6f, 0.05f, 0f);
    private Vector2 origin;

    public float fireDelta = 0.5F;
    private float fireDelay = 0.5F;
    private float sinceFire = 0.0F;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        sinceFire += Time.deltaTime;
        if (Input.GetButton("Fire1") && sinceFire > fireDelay)
        {
            ShotgunFire();
            Debug.Log("Fired!");
            // shotgunParticleBurst.Emit(Random.Range(25, 45));
            sinceFire = 0.0f;
        }
    }

    private void ShotgunFire()
    {
        origin = transform.position + offset;
        var bulletCount = 8;

        List<RaycastHit2D> bulletRays = new List<RaycastHit2D>();


        for (int i = 0; i < bulletCount; i++)
        {
            var bulletAngle = Quaternion.AngleAxis(Random.Range(-45.0f, 45.0f), Vector3.forward) * Vector2.right;
            // RaycastHit2D bulletRay = Physics2D.Raycast(origin, bulletAngle.normalized, 3.0f);
            //
            // //might not be needed
            // bulletRays.Add(bulletRay);

            Debug.DrawRay(origin, bulletAngle.normalized * 3, Color.red, 0.05f);
        }
    }
}