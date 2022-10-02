using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public int maxHealth = 5;  // character maximum health
    public int currentHealth;          

    Rigidbody2D rigidbody2D;
    float horizontal;
    float vertical;

    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);

    public GameObject projectilePrefab;

    public AudioClip projectileSound;

    public Image HPBar; 
    // Start is called before the first frame update
    void Start()
    {
    currentHealth = maxHealth;   // when start game, playuer will get maximum health
 
    }

    // Update is called once per frame
    void Update()
    {
 




}

    public void ChangeHealth(int amount)

{
    currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);    // player to reduce or change health
    HPBar.fillAmount     = (float)currentHealth / (float)maxHealth;

    if(Input.GetKeyDown(KeyCode.J))  // press J it will launch the bullets
{
    Launch();
}
}


    public void Launch()
{
    GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2D.position + Vector2.up * -1.0f, Quaternion.identity);

    AudioSource.PlayClipAtPoint(projectileSound, Camera.main.transform.position);

    Projectile projectile = projectileObject.GetComponent<Projectile>();
    projectile.Launch(lookDirection, 300);  //300 is the speed of the bullet 
}    
}



