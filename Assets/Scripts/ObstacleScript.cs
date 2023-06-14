using System;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 2.0f;
    public Vector3 destroy_point;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = speed * UnityEngine.Vector2.down;
        if (transform.position.y < destroy_point.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerEntity player = other.gameObject.GetComponent<PlayerEntity>();
            player.damage(99999);
        }    
    }

}
