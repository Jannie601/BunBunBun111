using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelControllerLevel3 : MonoBehaviour
{

    bool isTouch;
    public string LevelName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) // press E to activate the level 
        {
            if(isTouch == true)
            {
                Application.LoadLevel(LevelName);
            }
        }  
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            isTouch = true; // if player touch it will activate 
        }
    }
}
