using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int Health;
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
    
    public void damage(int value)
    {
        SoundManager soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
        soundManager.playSound(SoundManager.Sounds.ATTACK_IMPACT);
        Health = (Health - value <= 0) ? 0 : Health - value;
        if (Health == 0)
        {
            kill();
        }
    }

    public void kill()
    {
        Destroy(gameObject);
    }
    
}
