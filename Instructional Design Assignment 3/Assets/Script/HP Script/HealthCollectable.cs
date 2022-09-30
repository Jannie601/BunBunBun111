using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        PlayerController controller = other.GetComponent<PlayerController>();
      
        if(controller!= null)    // if player touch nothing, nothing will happen
        {
            if (controller.currentHealth < controller.maxHealth)
            {
          
            controller.ChangeHealth(1); // if the player touch the health potion it will add 1 
            Destroy(gameObject);     // after collecting the health it will dissapear in the game 
            }
       }
    }
}
