using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Assets.Scripts.Card;
using UnityEngine;
using Vuforia;

public class CardCreator : MonoBehaviour {
    public string pathToCards = "Vuforia/Cards.xml";

    private bool cardGone = false;

    private List<GameObject> cardGos = new List<GameObject>();
    //Could also be done with VuforiaBehaviour.Instance.GetDatabaseTargetInfo(...)
    private List<string> cardNames = new List<string>() { "spades-13", "spades-12", "spades-11", "spades-10", "spades-09", "spades-08", "spades-07", "spades-06", "spades-05", "spades-04", "spades-03", "spades-02", "spades-01", "joker-03", "joker-02", "joker-01", "hearts-13", "hearts-12", "hearts-11", "hearts-10", "hearts-09", "hearts-08", "hearts-07", "hearts-06", "hearts-05", "hearts-04", "hearts-03", "hearts-02", "hearts-01", "diamonds-13", "diamonds-01", "diamonds-12", "diamonds-11", "diamonds-10", "diamonds-09", "diamonds-08", "diamonds-07", "diamonds-06", "diamonds-05", "diamonds-04", "diamonds-03", "diamonds-02", "clubs-queen", "clubs-king", "clubs-jack", "clubs-10", "clubs-09", "clubs-08", "clubs-07", "clubs-06", "clubs-05", "clubs-04", "clubs-03", "clubs-02", "clubs-ace" };

    // Start is called before the first frame update
    void Start() {
        VuforiaApplication.Instance.OnVuforiaInitialized += OnVuforiaInitialized;
    }

    private void OnVuforiaInitialized(VuforiaInitError error) {
        if (error == VuforiaInitError.NONE) {
            InizializeCards();
        }
    }

    private void InizializeCards() {
        GameObject rootGo = GameObject.Find("Cards");
        foreach (var cs in cardNames) {
            var imgTar = VuforiaBehaviour.Instance.ObserverFactory.CreateImageTarget(pathToCards, cs);
            print($"target created: {imgTar}");
            string[] cardStringInfo = cs.Split('-');
            imgTar.OnTargetStatusChanged +=ImgTar_OnTargetStatusChanged;
            var cardInfo = imgTar.gameObject.AddComponent<Card>();
            var observerHandler = imgTar.gameObject.AddComponent<DefaultObserverEventHandler>();

            cardInfo.CardType = (CardType)Enum.Parse(typeof(CardType), char.ToUpper(cardStringInfo[0][0]) + cardStringInfo[0].Substring(1));
            cardInfo.CardValue = ConvertCardValue(cardStringInfo[1]);
            cardInfo.CardName = ParseCardName(cardInfo.CardValue);
            imgTar.transform.name = cardInfo.ToString();
            imgTar.transform.parent = rootGo.transform;
            
            //Create CubeForTesting
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(0.08f, 0.08f, 0.08f);
            cube.transform.parent = imgTar.transform;
        }
    }

    private int ConvertCardValue(string cardValue) {
        int value = -1;
        if (!int.TryParse(cardValue, out value)) {
            switch (cardValue.ToLower()) {
                case "jack":
                    return 11;
                case "queen":
                    return 12;
                case "king":
                    return 13;
                case "ace":
                    return 1;
            }
        }
        return value;
    }

    private string ParseCardName(int cardValue) {
        switch (cardValue) {
            case 1:
                return "Ace";
            case 2:
                return "Two";
            case 3:
                return "Three";
            case 4:
                return "Four";
            case 5:
                return "Five";
            case 6:
                return "Six";
            case 7:
                return "Seven";
            case 8:
                return "Eight";
            case 9:
                return "Nine";
            case 10:
                return "Ten";
            case 11:
                return "Jack";
            case 12:
                return "Queen";
            case 13:
                return "King";
            default:
                return "Invalid number";
        }
    }

    private void ImgTar_OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status) {
        Card cardInfo = behaviour.transform.gameObject.GetComponent<Card>();
        if (status.Status == Status.TRACKED) {
            //TODO Vibrate
            cardGone = false;
            StartCoroutine(Vibrate(0.5f, ConvertCardTypeToInt(cardInfo.CardType), cardInfo.CardValue));
        }
        else {
            //TODO Stop Vibrating
            cardGone = true;
        }
        
        print($"target status: {behaviour.TargetName} {status.Status}");
    }

    private int ConvertCardTypeToInt(CardType cardType)
    {
        switch (cardType)
        {
            case CardType.Clubs:
                return 1;
            case CardType.Diamonds:
                return 2;
            case CardType.Hearts:
                return 3;
            case CardType.Spades:
                return 4;
            case CardType.Joker:
                return 5;
            default:
                return -1;
        }
    }

    private IEnumerator Vibrate(float _interval, float top, float top2)
    {
        float interval = _interval;
        WaitForSeconds wait = new WaitForSeconds(interval);
        float t;

        for (t = 0; t < top & !cardGone; t += interval) // Change the end condition (t < 1) if you want
        {
            Handheld.Vibrate();
            yield return wait;
        }

        yield return new WaitForSeconds(1f);

        for (t = 0; t < top2 & !cardGone; t += interval) // Change the end condition (t < 1) if you want
        {
            Handheld.Vibrate();
            yield return wait;
        }

        //Vibrate 4 times very fast in case that card is gone
        if (cardGone) 
        {
            for (t = 0; t < 1; t += 0.25f) // Change the end condition (t < 1) if you want
            {
                Handheld.Vibrate();
                yield return wait;
            }
        }
    }

    private List<string> GetCardNamesFromXml() {
        List<string> cardNames = new List<string>();
        XmlDocument xmlDoc = new XmlDocument();
        StreamReader sr = new StreamReader(pathToCards);
        xmlDoc.LoadXml(sr.ReadToEnd());
        XmlNodeList imageTargets = xmlDoc.GetElementsByTagName("ImageTarget");
        foreach (XmlNode node in imageTargets) {
            if (node.Attributes != null) {
                XmlAttribute attribute = node.Attributes["name"];
                if (attribute != null) {
                    cardNames.Add(attribute.Value);
                }
            }
        }
        return cardNames;
    }

    // Update is called once per frame
    void Update() {

    }
}
