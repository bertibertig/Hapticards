using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distancemanager : MonoBehaviour
{
    [SerializeField] GameObject target;
    bool collission;

    bool vibrating;
    float vibrationtimer;
    int vibrationcounter;
    // Start is called before the first frame update
    void Start()
    {
        collission = false;
        vibrating = false;
        vibrationtimer = 0;
        vibrationcounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (collission || vibrating)
        {
            return;
        }
        RaycastHit hit;
        if(Physics.Raycast(transform.position, target.transform.position-transform.position, out hit))
        {
            vibrating = true;
            if (hit.distance < 0.3)
            {
                StartCoroutine(Vibrate(0.3f, 0.3f));
            }
            else
            {
                StartCoroutine(Vibrate(hit.distance, hit.distance));
            }
            
            //long strength = (long)(600 / hit.distance);
            //Vibration.Vibrate(new long[] { strength, 100, strength }, 1);
        }
       
    }

    private void OnTriggerStay(Collider other)
    {
        collission = true;
        if (!vibrating)
        {
            vibrating = true;
            StartCoroutine(Vibrate(0.05f, 0.05f));
        }
       
               
                
                
           
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        collission = false;
    }

    private IEnumerator Vibrate(float _interval, float top)
    {
        float interval = _interval;
        WaitForSeconds wait = new WaitForSeconds(interval);
        float t;

        for (t = 0; t < top; t += interval) // Change the end condition (t < 1) if you want
        {
            Handheld.Vibrate();
            yield return wait;
        }

       // yield return new WaitForSeconds(0.4f);

       /* for (t = 0; t < 1; t += interval) // Change the end condition (t < 1) if you want
        {
            Handheld.Vibrate();
            yield return wait;
        }
        */
        vibrating = false;
    }
}
