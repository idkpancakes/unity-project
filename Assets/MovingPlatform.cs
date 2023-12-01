using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 movementVector = new Vector3(5f, 0f, 0f);
    public float speed = 0.5f;
    public float minX = 0f;
    public float maxX = 10f;

    private int direction = 1; // 1:right -1:left

    void Update()
    {
        Vector3 nextPosition = transform.position + movementVector * speed * direction * Time.deltaTime;

        if (nextPosition.x < minX || nextPosition.x > maxX)
        {
            direction *= -1;
        }

        float clampedX = Mathf.Clamp(nextPosition.x, minX, maxX);
        nextPosition.x = clampedX;

        transform.position = nextPosition;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown("space"))
            {
                collision.transform.SetParent(null);
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
