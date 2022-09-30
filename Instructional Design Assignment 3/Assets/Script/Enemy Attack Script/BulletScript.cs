using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float moveSpeed = 7f; 

    Rigidbody2D rb;

    PlayerMovement target; 
    Vector2 moveDirection;

    //use this for initialization

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        target = GameObject.FindObjectOfType<PlayerMovement>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
        Destroy (gameObject, 3f);
    }

  void OnTriggerEnter2D (Collider2D col)
  {
      if (col.gameObject.name.Equals ("PlayerMovement")) {
          Debug.Log ("Hit!");
          Destroy (gameObject);
      }
  }
}
