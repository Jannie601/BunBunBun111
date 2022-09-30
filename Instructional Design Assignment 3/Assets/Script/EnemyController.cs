using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;    // speed of the enemy
    public bool vertical;   // enemy walking direction
    public float changeTime = 3.0f;    // 3.0f os 3 seconds, means enemy will walk to left 3 seconds and to the right 3 seconds 

    Rigidbody2D rigidbody2D;
    float timer;    
    int direction = 1;

    Animator animator;

    public AudioClip EnemyDieSound;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime; 
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;   // timer

        if(timer < 0)               // if time become 0
        {
            direction =- direction;    // it will change the enemy direciton (left right up down)
            timer = changeTime;         // reset timer 
        }
    }

        void FixedUpdate()
         {
            Vector2 position = rigidbody2D.position;

            if(vertical)
            {
                position.y = position.y + Time.deltaTime * speed * direction;
                animator.SetFloat("Move X" , 0);
                animator.SetFloat("Move Y" , direction);
                
            }
            else
            {
                position.x = position.x + Time.deltaTime * speed * direction;
                animator.SetFloat("Move X" , direction);
                animator.SetFloat("Move Y" , 0);
            }
            rigidbody2D.MovePosition(position);
        }

         private void OnTriggerEnter2D(Collider2D other) 
         {
            PlayerController controller = other.GetComponent<PlayerController>();
            if(controller != null)
            {
                controller.ChangeHealth(-1);   //when player touch the enemy, health will -1
            }
            
        }
        public void killEnemy()
        {
            AudioSource.PlayClipAtPoint(EnemyDieSound, Camera.main.transform.position);
            Destroy(gameObject);
        }
}
