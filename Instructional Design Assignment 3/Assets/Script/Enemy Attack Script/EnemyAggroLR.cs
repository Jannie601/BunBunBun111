using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggroLR : MonoBehaviour
{
    [SerializeField]
    GameObject Bear;

    Animator BearAnimation;

    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;
  

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        BearAnimation = Bear.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
      

        //distance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        print("distToPlayer:" + distToPlayer);

        if(distToPlayer < agroRange)
        {
             //code to chase player
             ChasePlayer();
        }
        else
        {
             //stop chasing player
             StopChasingPlayer();
        }
    }



     void ChasePlayer()
    {
       if(transform.position.x < player.position.x)
       {
           //enemy is to the left side of the player, so move right
           rb2d.velocity = new Vector2(moveSpeed, 0);
           

       }
       else if(transform.position.x > player.position.x)
       {
           //enemy is to the right side of the player, so move left
           rb2d.velocity = new Vector2(-moveSpeed, 0);
           
       }

       else if(transform.position.y < player.position.y)
       {
           //enemy is to the left side of the player, so move right
           rb2d.velocity = new Vector2(moveSpeed, 0);
           
       }
       else if(transform.position.y > player.position.y)
       {    
           rb2d.velocity = new Vector2(-moveSpeed, 0);
           
       }

       BearAnimation.Play("Enemy Bear");



    }

     void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
        BearAnimation.Play("Enemy Bear Idle");
    }
}
