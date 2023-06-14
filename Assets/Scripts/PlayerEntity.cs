using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Vector2 = System.Numerics.Vector2;

public class PlayerEntity : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private int Health = 3;

    [SerializeField] private GameObject Projectile;
    [SerializeField] private GameObject AttackPoint;
    [SerializeField] private float ShootInterval;
    [SerializeField] private HealthManager HealthManager;
    [SerializeField] private int Damage = 1;
    private bool shooting = false;
    private float shootIntervalTimer = 0;

    public UnityEvent deathEvent;

    public void damage(int damage)
    {
        SoundManager soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
        soundManager.playSound(SoundManager.Sounds.ATTACK_IMPACT);
        Health = (Health - damage <= 0) ? 0 : Health - damage;
        if(Health <= 0)
        {
            //Death event
            death();
        }
    }

    public void death()
    {
        //death logic
        //TODO
        deathEvent.Invoke();
    }

    public void attack(InputAction.CallbackContext ci)
    {
        if (ci.performed)
            shooting = true;
        else if (ci.canceled)
            shooting = false;
        else
            shooting = false;
    }

    private void Update()
    {
        shootIntervalTimer += Time.deltaTime;
        if (shootIntervalTimer > ShootInterval && shooting)
        {
            //play sound
            SoundManager soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
            soundManager.playSound(SoundManager.Sounds.ATTACK_SHOOT);
            
            Projectile projectile = Instantiate(Projectile, AttackPoint.transform.position, Quaternion.identity).GetComponent<Projectile>();
            projectile.setDamage(Damage);
            projectile.setDirection(UnityEngine.Vector2.up);
            projectile.trigger();
            shootIntervalTimer = 0;
        }
        HealthManager.updateHealth(Health);
    }
}
