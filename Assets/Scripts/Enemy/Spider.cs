using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }

    [SerializeField] private GameObject _acidProjectilePrefab;

    public override void Init()
    {
        base.Init();

        Health = base.health;
    }

    public override void Update()
    {
        
    }

    public void Damage()
    {
        if (isDead == true)
        {
            return;
        }

        Health -= 1;

        if(Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            GameObject gem = Instantiate(gemPrefab, transform.position, Quaternion.identity) as GameObject;
            gem.GetComponent<Gem>().gemValue = base.gem;
            //Destroy(this.gameObject);
        }
    }

    public override void Movement()
    {
        //base.Movement();
        //Do nothing
    }

    public void Attack()
    {
        //call from Spider Animation Event
        //instantiate acid projectile

        float x = .5f;
        var offset = new Vector3(x, 0, 0);
        Instantiate(_acidProjectilePrefab, transform.position - offset, Quaternion.identity);
    }
}


