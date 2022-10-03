using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLevel3 : MonoBehaviour
{

    public float Speed = 4;

  
    // Start is called before the first frame update
    void Start()
    {
         transform.position += -transform.right * Speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<EnemyBehaviour1>();
        if (enemy) 
        {
            enemy.TakeHit(1);
        }

        Destroy(gameObject);
    }

}
