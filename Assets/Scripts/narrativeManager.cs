using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class narrativeManager : MonoBehaviour
{

    public static narrativeManager instance;

    public enum deckTags
    {
        road,
        market
    }

    public TextAsset cardTextAsset;
    [SerializeField] Transform narrativeCard;
    [SerializeField] Transform cardDisplayPosition;
    [SerializeField] Transform cardStorePosition;
    private Story cardTexts;
    public bool isCardDisplaying { get; private set; }

    [Header("Card Decks")]
    [SerializeField] List<mapDeck> mapDecks;
    public List<string> allCards;
    public List<string> roadCards, marketCards;
    public List<string> completedCards;

    private Coroutine currentCardAnimation;

    
    private string currentCard;
        
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        cardTexts = new Story(cardTextAsset.text);
        sortKnotToLocation();
        assignDeckKnots();

        narrativeCard.position = cardStorePosition.position;
    }

    private void sortKnotToLocation()
    {
        cardTexts.ChoosePathString("INDEX");
        
        while (cardTexts.canContinue)
        {
            string[] tagPair = new string[2];
            string currentKnot = cardTexts.Continue();
            currentKnot = currentKnot.Replace("\n", "");

            allCards.Add(currentKnot);

            for (int i = 0; i < cardTexts.TagsForContentAtPath(currentKnot).Count; i++)
            {
                tagPair = cardTexts.TagsForContentAtPath(currentKnot)[i].Split(":");
                if (tagPair[0] == "location")
                {
                    switch(tagPair[1])
                    {
                        case "road":
                            roadCards.Add(currentKnot);
                            break;

                        case "market":
                            marketCards.Add(currentKnot);
                            break;
                    }
                    break; //remove if parsing for any tags other than location
                }
            }
        }
    }

    private void assignDeckKnots()
    {
        for (int i = 0; i <mapDecks.Count; i++)
        {
            switch(mapDecks[i].deckTag)
            {
                case deckTags.market:
                    mapDecks[i].setList(marketCards);
                    break;

                case deckTags.road:
                    mapDecks[i].setList(roadCards);
                    break;
            }
        }
    }

    public void drawCard(mapDeck deck)
    {
        if (deck == null)
        {
            Debug.LogWarning("mapDeck component not assigned to deck!");
            return;
        }
        if (isCardDisplaying)
        {
            Debug.LogWarning("card is already being displayed");
            return;
        }

        stopCardAnimation();
        currentCardAnimation = StartCoroutine(displayCard(deck.transform, 1f));
        string knot = deck.getCard();
        StartCoroutine(cardTextManager.instance.initializeCardText(knot));
        isCardDisplaying = true;
    }

    public void endCard()
    {
        if (!isCardDisplaying)
        {
            Debug.LogWarning("card is not displaying");
        }

        stopCardAnimation();
        currentCardAnimation = StartCoroutine(storeCard(1f));
        isCardDisplaying = false;
    }

    private void stopCardAnimation()
    {
        if (currentCardAnimation == null) return;
        StopCoroutine(currentCardAnimation);
    }

    IEnumerator displayCard(Transform deckTransform, float duration)
    {
        narrativeCard.gameObject.SetActive(true);
        float timer = -Time.deltaTime;

        while (true)
        {
            timer += Time.deltaTime;
            float curveValue = visualSettings.easeOutCurveVar0.Evaluate(timer / duration);
            narrativeCard.position = Vector3.Lerp(deckTransform.position, cardDisplayPosition.position, curveValue);
            narrativeCard.rotation = Quaternion.Lerp(deckTransform.rotation, cardDisplayPosition.rotation, curveValue);
            //horizontal spin
            narrativeCard.eulerAngles = new Vector3(narrativeCard.eulerAngles.x, narrativeCard.eulerAngles.y, Mathf.Lerp(360, -180, curveValue));

            if (timer >= duration)
            {
                yield break;
            }
            yield return null;
        }
    }

    IEnumerator storeCard(float duration)
    {
        float timer = -Time.deltaTime;

        while (true)
        {
            timer += Time.deltaTime;
            float curveValue = visualSettings.easeOutCurve.Evaluate(timer / duration);
            narrativeCard.position = Vector3.Lerp(cardDisplayPosition.position, cardStorePosition.position, curveValue);
            narrativeCard.rotation = Quaternion.Lerp(cardDisplayPosition.rotation, cardStorePosition.rotation, curveValue);

            if (timer >= duration)
            {
                yield break;
            }
            yield return null;
        }
    }
}
