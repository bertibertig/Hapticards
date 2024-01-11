using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSetter : MonoBehaviour
{
    bool colliding;

    private void Start()
    {
        colliding = false;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.layer != 9)
        {
            colliding = true;
        }
        
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.layer != 9)
        {
            colliding = false;
        }
    }

    public bool getCol()
    {
        return colliding;
    }
}
