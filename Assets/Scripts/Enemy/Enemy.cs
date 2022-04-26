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

    protected bool isHit = false;
    protected bool isDead = false;

    protected Player player;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        if(player == null)
        {
            Debug.Log("Player is Null");
        }

        targetID = (targetID + 1) % waypoints.Length;
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat") == false)
        {
            return;
        }

        if(isDead != true)
        {
            Movement();
        }
        
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

        if(isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[targetID].transform.position, speed * Time.deltaTime);
        }

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if(distance > 2.0f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }

        Vector3 direction = player.transform.position - transform.position;

        if (direction.x < 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = true;
        }
        else if (direction.x > 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = false;
        }
    }

}

