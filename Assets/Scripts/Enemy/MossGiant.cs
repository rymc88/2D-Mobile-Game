﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Movement()
    {
        base.Movement();
    }

    public void Damage()
    {
        if (isDead == true)
        {
            return;
        }

        Health -= 1;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);

        if(Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            GameObject gem = Instantiate(gemPrefab, transform.position, Quaternion.identity) as GameObject;
            gem.GetComponent<Gem>().gemValue = base.gem;
            
        }
    }
}




