using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    //handle to the spider
    private Spider _spider;

    private void Start()
    {
        _spider = GetComponentInParent<Spider>();
    }

    public void Fire()
    {
        //Tell Spider to Fire
        _spider.Attack();
    }
}
