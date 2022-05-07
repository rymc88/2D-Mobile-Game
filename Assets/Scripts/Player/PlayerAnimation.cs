using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private Animator _swordAnimation;
 
   
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _swordAnimation = transform.GetChild(1).GetComponent<Animator>();

        if(_anim == null)
        {
            Debug.Log("Animator is null");
        }

        if(_swordAnimation == null)
        {
            Debug.Log("Sword Arc Animator is null");
        }

    }

    public void Move(float horizontalInput)
    {
        _anim.SetFloat("Move", Mathf.Abs(horizontalInput));
    }

    public void Jump(bool jumping)
    {
        _anim.SetBool("Jumping", jumping);
    }

    public void Attack()
    {
        _anim.SetTrigger("Attack");
        _swordAnimation.SetTrigger("SwordArc");
     
    }

    public void Death()
    {
        _anim.SetTrigger("Death");
    }
   
}
