using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Card;
using UnityEngine;

public class VibrationsScript : MonoBehaviour
{
    bool vibrating;

    private Card card;

    // Start is called before the first frame update
    void Start()
    {
        vibrating = false;
        card = GetComponentInParent<Card>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enabled & !vibrating & card != null)
        {
            int colorNumber = -1;
            switch (card.cardType)
            {
                case CardType.Clubs:
                    colorNumber = 1;
                    break;
                case CardType.Diamonds:
                    colorNumber = 2;
                    break;
                case CardType.Heart:
                    colorNumber = 3;
                    break;
                case CardType.Spades:
                    colorNumber = 4;
                    break;
            }

            vibrating = true;
            StartCoroutine(Vibrate(1, colorNumber, 2, card.cardValue));
        }
    }

    private void OnEnable()
    {
        print("test");
    }


    private IEnumerator Vibrate(float _interval, float top, float waitEnd, float top2)
    {
        float interval = _interval;
        WaitForSeconds wait = new WaitForSeconds(interval);
        float t;

        for (t = 0; t < top; t += interval) // Change the end condition (t < 1) if you want
        {
            Handheld.Vibrate();
            yield return wait;
        }

        yield return new WaitForSeconds(1f);
        print("Between");

        for (t = 0; t < top2; t += interval) // Change the end condition (t < 1) if you want
        {
            Handheld.Vibrate();
            yield return wait;
        }

        vibrating = false;
    }
}