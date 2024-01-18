using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Card;
using UnityEngine;

public class Card :MonoBehaviour
{
    public CardType CardType { get; set; }
    public int CardValue { get; set; }
    public string CardName { get; set; }

    public override string ToString() {
        if(CardType == CardType.Joker) {
            return "Joker";
        }
        return $"{CardName} o' {CardType.ToString().ToLower()}";
    }
}
