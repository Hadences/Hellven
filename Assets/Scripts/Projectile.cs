using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float force = 20f;
    [SerializeField] private float lifeTime = 3; //3 sec
    [SerializeField] private Vector2 direction;
    private float lifeTime_Timer = 0;
    private int damage = 0;

    private void Update()
    {
        lifeTime_Timer += Time.deltaTime;
        if (lifeTime_Timer > lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void trigger()
    {
        rb.AddForce(direction * force, ForceMode2D.Impulse);
    }
    
    public void setDamage(int value)
    {
        damage = value;
    }

    public void setDirection(Vector2 dir)
    {
        direction = dir;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            //damage logic

            GameObject entity = other.gameObject;
            if (entity.GetComponent<Enemy>() != null)
            {
                entity.GetComponent<Enemy>().damage(damage);
            }else if (entity.GetComponent<PlayerEntity>() != null)
            {
                entity.GetComponent<PlayerEntity>().damage(damage);
            }
            
        }
    }
}
