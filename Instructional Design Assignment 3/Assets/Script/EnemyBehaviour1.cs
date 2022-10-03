using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour1 : MonoBehaviour
{

    public float Hitpoints; 
    public float MaxHitpoints = 5;

    
    // Start is called before the first frame update
    void Start()
    {
        Hitpoints = MaxHitpoints;
    }

    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        if(Hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
