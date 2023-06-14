using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : Enemy
{
    [SerializeField] private float Shoot_Interval = 0.2f;
    [SerializeField] private GameObject Projectile;
    [SerializeField] private GameObject AttackPoint;
    [SerializeField] private int Damage;
    
    private float Shoot_Interval_Timer = 0;
    

    private void Update()
    {
        Shoot_Interval_Timer += Time.deltaTime;
        if (Shoot_Interval_Timer >= Shoot_Interval)
        {
            attack();
            Shoot_Interval_Timer = 0;
        }
    }

    private void attack()
    {
        Projectile projectile = Instantiate(Projectile, AttackPoint.transform.position, Quaternion.identity).GetComponent<Projectile>();
        projectile.setDamage(Damage);
        projectile.setDirection(Vector2.down);
        projectile.trigger();
    }

    
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            //damage logic

            GameObject entity = other.gameObject;
            if (entity.GetComponent<Enemy>() != null)
            {
                entity.GetComponent<Enemy>().damage(Damage);
            }else if (entity.GetComponent<PlayerEntity>() != null)
            {
                entity.GetComponent<PlayerEntity>().damage(Damage);
            }
            
        }
    }
}
