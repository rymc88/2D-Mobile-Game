using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidProjectile : MonoBehaviour
{
    //move left at 3 meters per second
    //detect player and deal damage (IDamageable Interface)
    //destroy this after 5 seconds

    [SerializeField] private float _speed;

    private void Start()
    {
        Destroy(this.gameObject, 5.0f);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            IDamageable hit = other.GetComponent<IDamageable>();

            if(hit != null)
            {
                hit.Damage();
                Destroy(this.gameObject);
            }
        }
    }


}
