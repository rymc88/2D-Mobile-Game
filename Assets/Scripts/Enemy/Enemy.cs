using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int gem;
    [SerializeField] protected Transform [] waypoints;
    [SerializeField] protected int targetID;

    protected Animator anim;
    protected SpriteRenderer sprite;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        targetID = (targetID + 1) % waypoints.Length;
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        Movement();
    }

    public virtual void Movement()
    {
        if (targetID == 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        if (transform.position == waypoints[targetID].transform.position)
        {
            targetID = (targetID + 1) % waypoints.Length;
            anim.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[targetID].transform.position, speed * Time.deltaTime);
    }

}

