using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2D;

    void Awake()
     {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.magnitude > 150.0f)  // how far the bullet travel
     {
     
        Destroy(gameObject);
     }
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2D.AddForce(direction * force);
    }

    private void OnTriggerEnter2D(Collider2D other) 
 {
    EnemyController e = other.GetComponent<EnemyController>();

    if(e!=null)
    {
        e.killEnemy();
    }

    Destroy(gameObject);
    
  }
}


