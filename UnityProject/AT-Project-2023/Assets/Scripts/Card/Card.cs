using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Card;
using UnityEngine;

public class Card :MonoBehaviour
{
    public CardType cardType;
    public int cardValue;
    public string cardName;

    public override string ToString() {
        return $"{cardName} o' {cardType.ToString().ToLower()}";
    }
}
