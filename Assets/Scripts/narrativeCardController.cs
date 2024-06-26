using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static cardButton;
using static narrativeInkKnots;

public class narrativeCardController : MonoBehaviour
{
    [SerializeField] float textboxDefaultWidth;
    [SerializeField] float basicTextboxSpacing;
    [SerializeField] GameObject cardPrefab;
    //===
    [SerializeField] Transform cardDisplayPosition, cardStorePosition, cardBackdropPosition;
    private Coroutine currentAnimation;
    [SerializeField] AnimationCurve storeCurve, drawCurve, backdropCurve;
    private List<Transform> backdroppedCards = new List<Transform>();
    private Transform currentDeck;
    //===
    private static narrativeCardController instance;
    //===
    private cardInfo currentCardInfo;
    private Transform currentCard;
    private narrativeInkKnots.textInfo currentTextInfo;
    private TextMeshProUGUI titleText, topText, bottomText;
    private List<cardChoice> cardChoices = new List<cardChoice>();
    private cardButton cardButtonComponent;

    private RectTransform titleTextTransform, topTextTransform, bottomTextTransform;
    private List<RectTransform> cardChoiceTransforms = new List<RectTransform>();
    private RectTransform topBottomDivider;
    //===
    public static narrativeCardController getInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogWarning("There were multiple objects attempting to be assigned as the singleton instance");
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public void deckInteracted(deckTags deckTag, Transform deckTransform) //sets card text and starts layout & animation
    {
        currentDeck = deckTransform;
        textInfo textInfo = narrativeInkKnots.getInstance().drawCard(deckTag);

        currentTextInfo = textInfo;
        spawnNewCard();

        setCardVisuals(textInfo);

        stopCardAnimation();
        currentAnimation = StartCoroutine(drawCardAnimation(1f, deckTransform));
    }

    private void setCardVisuals(textInfo textInfo)
    {
        //set texts
        titleText.text = textInfo.title;
        topText.text = textInfo.text;

        //disable misc
        disableAllChoices();
        bottomText.gameObject.SetActive(false);
        cardButtonComponent.gameObject.SetActive(false);


        if (textInfo.choices.Count == 0)
        {
            layoutFullText(textInfo);

        }
        else
        {
            //set choice texts

            if (textInfo.choices.Count > cardChoices.Count)
            {
                Debug.LogError("there are more choices in the knot than there are in the card!");
            }

            for (int i = 0; i < textInfo.choices.Count; i++)
            {
                cardChoices[i].gameObject.SetActive(true);

                cardChoices[i].choiceText.text = textInfo.choices[i].text;
                cardChoices[i].inkChoice = textInfo.choices[i];
            }

            layoutChoices(textInfo);
        }
    }

    private void nextCardInteracted()
    {
        narrativeInkKnots.textInfo textInfo = narrativeInkKnots.getInstance().drawCard(currentTextInfo.nextCard);
        currentTextInfo = textInfo;

        spawnNewCard();
        
        setCardVisuals(textInfo);

        stopCardAnimation();
        currentAnimation = StartCoroutine(drawCardAnimation(1f, currentDeck));
    }


    public void layoutFullText(textInfo textInfo) //layout for card with no choices
    {
        layoutTop();

        cardButtonComponent.gameObject.SetActive(true);
        cardButtonComponent.setButtonFunction(textInfo.buttonFunction);
    }

    public void layoutChoices(textInfo textInfo) //layout for card with choices
    {
        layoutTop();

        scaleTextboxToText(cardChoiceTransforms[0], cardChoices[0].choiceText, true);
        moveBelow(cardChoiceTransforms[0], topBottomDivider, basicTextboxSpacing);

        for (int i = 1; i < textInfo.choices.Count; i++)
        {
            scaleTextboxToText(cardChoiceTransforms[i], cardChoices[i].choiceText, true);
            moveBelow(cardChoiceTransforms[i], cardChoiceTransforms[i-1], basicTextboxSpacing);
        }
    }

    public void layoutTopBottom(textInfo textInfo) //layout for after selecting a choice
    {
        layoutTop();

        scaleTextboxToText(bottomTextTransform, bottomText, false);
        moveBelow(bottomTextTransform, topBottomDivider, basicTextboxSpacing);
    }

    private void layoutTop() //layout top sections
    {
        scaleTextboxToText(titleTextTransform, titleText, true);
        scaleTextboxToText(topTextTransform, topText, false);

        moveBelow(topTextTransform, titleTextTransform, basicTextboxSpacing);
        moveBelow(topBottomDivider, topTextTransform, basicTextboxSpacing);
    }

    private void moveBelow(RectTransform bottomTransform, RectTransform topTransform, float distance)
    {
        float bottomOfTop = topTransform.anchoredPosition.y - topTransform.sizeDelta.y;
        bottomTransform.anchoredPosition = new Vector2(bottomTransform.anchoredPosition.x, bottomOfTop - distance);
    }
    private void scaleTextboxToText(RectTransform textboxTransform, TextMeshProUGUI textboxComponent, bool scaleHorizontally)
    {
        textboxTransform.sizeDelta = new Vector2(textboxDefaultWidth, 0.25f);
        textboxComponent.ForceMeshUpdate();

        while (textboxComponent.isTextOverflowing)
        {
            textboxTransform.sizeDelta = new Vector2(textboxTransform.sizeDelta.x, textboxTransform.sizeDelta.y + 0.25f);
            textboxComponent.ForceMeshUpdate();
        }

        if (!scaleHorizontally) return;

        while (!textboxComponent.isTextOverflowing)
        {
            textboxTransform.sizeDelta = new Vector2(textboxTransform.sizeDelta.x - 0.25f, textboxTransform.sizeDelta.y);
            textboxComponent.ForceMeshUpdate();
        }

        textboxTransform.sizeDelta = new Vector2(textboxTransform.sizeDelta.x + 0.25f, textboxTransform.sizeDelta.y);
    }
    private void disableAllChoices()
    {
        for (int i = 0; i < cardChoices.Count; i++)
        {
            cardChoices[i].gameObject.SetActive(false);
        }
    }
    private void spawnNewCard()
    {
        cardInfo newCard = Instantiate(cardPrefab).GetComponent<cardInfo>();

        //assign text components
        titleText = newCard.titleText;
        topText = newCard.topText;
        bottomText = newCard.bottomText;
        cardChoices = newCard.cardChoices;

        //assign transform components
        titleTextTransform = newCard.titleText.GetComponent<RectTransform>();
        topTextTransform = newCard.topText.GetComponent<RectTransform>();
        bottomTextTransform = newCard.bottomText.GetComponent<RectTransform>();

        cardChoiceTransforms.Clear();
        for (int i = 0; i < newCard.cardChoices.Count; i++)
        {
            cardChoiceTransforms.Add(newCard.cardChoices[i].GetComponent<RectTransform>());
        }

        topBottomDivider = newCard.topBottomDivider;

        //assign misc
        newCard.canvasComponent.worldCamera = Camera.main;
        cardButtonComponent = newCard.buttonComponent;

        currentCardInfo = newCard;
        currentCard = newCard.transform;
    }

    public void chooseChoice(Choice choice)
    {
        narrativeInkKnots.textInfo choiceInfo = narrativeInkKnots.getInstance().chooseChoice(choice);
        disableAllChoices();

        currentTextInfo = choiceInfo;

        bottomText.gameObject.SetActive(true);
        bottomText.text = choiceInfo.text;
        layoutTopBottom(choiceInfo);

        //exit button
        cardButtonComponent.gameObject.SetActive(true);
        cardButtonComponent.setButtonFunction(choiceInfo.buttonFunction);
    }

    public void buttonInteracted(buttonFunction endFunction)
    {
        switch (endFunction)
        {
            case buttonFunction.none:
            case buttonFunction.store:
                stopCardAnimation();
                currentAnimation = StartCoroutine(storeCardAnimation(1f));

                for (int i = 0; i < backdroppedCards.Count; i++)
                {
                    StartCoroutine(storeCardAnimation(0.5f, backdroppedCards[i]));
                }
                backdroppedCards.Clear();
                break;

            case buttonFunction.nextCard:
                stopCardAnimation();
                StartCoroutine(backdropCardAnimation(0.5f, currentCard));
                backdroppedCards.Add(currentCard);
                nextCardInteracted();
                break;
        }
    }

    public void stopCardAnimation()
    {
        if (currentAnimation != null)
        {
            StopCoroutine(currentAnimation);
        }
    }

    IEnumerator storeCardAnimation(float duration)
    {
        Vector3 cardStartPosition = currentCard.position;
        Vector3 cardStartRotation = currentCard.eulerAngles;
        float timeCounter = -Time.deltaTime;


        while(true)
        {
            timeCounter += Time.deltaTime;
            float curveValue = storeCurve.Evaluate(timeCounter / duration);

            currentCard.position = Vector3.Lerp(cardStartPosition, cardStorePosition.position, curveValue);
            currentCard.eulerAngles = Vector3.Lerp(cardStartRotation, cardStorePosition.eulerAngles, curveValue);

            if (timeCounter > duration) break;
            yield return null;
        }

        narrativeInkKnots.getInstance().storeCard();
        mapManager.enableMapInteraction();
        Destroy(currentCard.gameObject);
    }

    IEnumerator storeCardAnimation(float duration, Transform cardTransform)
    {
        Vector3 cardStartPosition = cardTransform.position;
        Vector3 cardStartRotation = cardTransform.eulerAngles;
        float timeCounter = -Time.deltaTime;


        while (true)
        {
            timeCounter += Time.deltaTime;
            float curveValue = storeCurve.Evaluate(timeCounter / duration);

            cardTransform.position = Vector3.Lerp(cardStartPosition, cardStorePosition.position, curveValue);
            cardTransform.eulerAngles = Vector3.Lerp(cardStartRotation, cardStorePosition.eulerAngles, curveValue);

            if (timeCounter > duration) break;
            yield return null;
        }

        narrativeInkKnots.getInstance().storeCard();
        mapManager.enableMapInteraction();
        Destroy(cardTransform.gameObject);
    }

    IEnumerator drawCardAnimation(float duration, Transform cardSource)
    {
        float timeCounter = -Time.deltaTime;

        while(true)
        {
            timeCounter += Time.deltaTime;
            float curveValue = drawCurve.Evaluate(timeCounter / duration);

            currentCard.transform.position = Vector3.Lerp(cardSource.position, cardDisplayPosition.position, curveValue);
            currentCard.transform.eulerAngles = Vector3.Lerp(Vector3.zero, cardDisplayPosition.eulerAngles, curveValue);

            if (timeCounter > duration) break;
            yield return null;
        }
    }

    IEnumerator backdropCardAnimation(float duration, Transform cardTransform) //used if the current card ended with a nextcard exit
    {
        Vector3 cardStartPosition = cardTransform.position;
        Vector3 cardStartRotation = cardTransform.eulerAngles;
        float timeCounter = -Time.deltaTime;

        while (true)
        {
            timeCounter += Time.deltaTime;
            float curveValue = backdropCurve.Evaluate(timeCounter / duration);

            cardTransform.position = Vector3.Lerp(cardStartPosition, cardBackdropPosition.position, curveValue);
            cardTransform.eulerAngles = Vector3.Lerp(cardStartRotation, cardBackdropPosition.eulerAngles, curveValue);

            if (timeCounter > duration) break;
            yield return null;
        }
    }
}
