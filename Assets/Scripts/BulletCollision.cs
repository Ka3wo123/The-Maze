using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Renderer rend = GetComponent<Renderer>();       // use it to change color of Object

        if(collision.gameObject.tag == "Player"){

            rend.material.color = Color.blue;
            Debug.Log("Entered collision with " + collision.gameObject.name);
        }
  
    }




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
