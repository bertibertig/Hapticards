using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFeedback : MonoBehaviour {
    public GameObject currentCard;

    //private bool newCard = true;
    //private TextToSpeech tts;
    //// Start is called before the first frame update
    //void Start() {
    //    tts = GetComponent<TextToSpeech>();
    //    if (tts == null) {
    //        print("No TTS Component found!");
    //    }
    //    else {
    //        tts.SetLanguage(TextToSpeech.Locale.UK);
    //        tts.SetSpeed(1.0f);
    //        tts.SetPitch(1.0f);
    //    }
    //}

    //// Update is called once per frame
    //void Update() {
    //    if (newCard && currentCard != null) {
    //        newCard = false;
    //        var cardInfo = currentCard.GetComponent<Card>();
    //        if (cardInfo == null) {
    //            print($"{currentCard} has no card info, skipping!");
    //            return;
    //        }
    //        tts.Speak(cardInfo.ToString());
    //    }
    //}
}
