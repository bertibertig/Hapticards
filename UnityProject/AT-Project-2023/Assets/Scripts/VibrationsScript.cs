using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationsScript : MonoBehaviour
{
    bool vibrating;
    [SerializeField] ColliderSetter[] colliders;

    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        vibrating = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (vibrating)
        {
            return;
        }

        counter = 0;
        for(int i=0;i<colliders.Length; i++)
        {
            if (colliders[i].getCol())
            {
                counter++;
            }
        }

        if (counter > 0)
        {
            vibrating = true;
        }

        switch (counter)
        {
            case 1:
                StartCoroutine(Vibrate(1.0f, 1.0f));
                break;
            case 2:
                StartCoroutine(Vibrate(0.5f, 0.5f));
                break;
            case 3:
                StartCoroutine(Vibrate(0.01f, 0.01f));
                break;
        }
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
