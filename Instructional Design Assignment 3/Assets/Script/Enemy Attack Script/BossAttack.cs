using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
   public AudioClip EnemyDieSound;
    private Animator anim;
    private Vector3 dir;
    private Rigidbody2D rb;
    private Transform target;
    public bool shouldRotate;

    private bool isInAttackRange;

    [SerializeField]
    GameObject bullet;

    float fireRate;
    float nextFire;
    //Use this for initialization

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;

        fireRate = 1f; 
        nextFire = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        dir = target.position - transform.position;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		dir.Normalize();
        if(shouldRotate)
		{
			anim.SetFloat("X", dir.x);
			anim.SetFloat("Y", dir.y);
		}
    
        CheckIfTimeToFire ();
        
    }

    void CheckIfTimeToFire ()
    {
        if (Time.time > nextFire) {
            Instantiate (bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
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
