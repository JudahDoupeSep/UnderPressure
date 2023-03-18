using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    //bool isCurrentlyColliding;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter3D(Collision collision)
    {
        if (collision.gameObject.tag == "interactable")
        {
            //isCurrentlyColliding = true;
        }
    }

    void OnCollisionExit3D(Collision collision)
    {
        if (collision.gameObject.tag == "interactable")
        {
            //isCurrentlyColliding = false;
        }
    }
}
