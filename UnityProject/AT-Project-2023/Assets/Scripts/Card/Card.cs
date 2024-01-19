using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Card;
using UnityEngine;

public class Card :MonoBehaviour
{
    public CardType CardType { get; set; }
    public string CardTypeAsString { get; set; }
    public string Sepperator { get; set; }
    public int CardValue { get; set; }
    public string CardName { get; set; }

    public override string ToString() {
        if(CardType == CardType.Joker) {
            return CardTypeAsString;
        }
        return $"{CardName}{Sepperator}{CardTypeAsString}";
    }
}
