using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class cardTextManager : MonoBehaviour
{
    /*
     * Manages card layout and text
     */
    public static cardTextManager instance;

    [Header("Visual Setup")]
    [Tooltip("Must be ordered from top to bottom, and must contain at least two displays")]
    [SerializeField] List<cardChoice> cardChoiceDisplays;
    [SerializeField] TextMeshProUGUI topText, bottomText, titleText;
    [SerializeField] RectTransform topToBottomDivider, choiceDivider;
    [SerializeField] Image cardExitButton;
    private List<RectTransform> additionalChoiceDividers = new List<RectTransform>();

    [Header("Ink Setup")]
    private Story cardTexts;
    Dictionary<string, string> currentKnotTagValues = new Dictionary<string, string>();

    [Header("Card Layout Settings")]
    [SerializeField] float titleToTopSpacing;
    [SerializeField] float topToBottomSpacing, choiceSpacing;
    [Range(0f, 1f)]
    [SerializeField] float topToBottomDividerLocation;

    [Header("Misc Settings")]
    [SerializeField] float cardDisplaySpeed;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
        }
    }

    private void Start()
    {
        cardTexts = new Story(narrativeManager.instance.cardTextAsset.text);
    }


    public IEnumerator initializeCardText(string targetKnot)
    {
        topToBottomDivider.gameObject.SetActive(false);
        setCardExitVisiblity(false);
        cardTexts.ChoosePathString(targetKnot);

        //parseKnotTags
        parseKnotTags(cardTexts.TagsForContentAtPath(targetKnot));

        //Empty Texts
        titleText.text = currentKnotTagValues["title"];
        topText.text = "";
        bottomText.text = "";
        for (int i = 0; i < cardChoiceDisplays.Count; i++)
        {
            //cardChoiceDisplays[i].deactivate();
        }

        while (cardTexts.canContinue)
        {
            string continueText = cardTexts.Continue();
            topText.text += "     ";
            for (int i = 0; i < continueText.Length; i++)
            {
                topText.text += continueText[i];
                layoutTextboxes(false);

                yield return new WaitForSeconds(cardDisplaySpeed);
                /*
                //only pause display at spaces or after the last word of the current paragraph
                if (continueText[i] == ' ' || i == continueText.Length - 1)
                {
                    yield return new WaitForSeconds(cardDisplaySpeed);
                }
                else
                {
                    continue;
                }
                */
            }
        }

        if (cardTexts.currentChoices.Count > 0)
        {
            if (cardTexts.currentChoices.Count > cardChoiceDisplays.Count)
            {
                Debug.LogWarning("There are more choices in the knot than there are choice displays! Text will not be shown.");
                yield break;
            }

            int i = 0;
            while (i < cardTexts.currentChoices.Count)
            {
                Choice choice = cardTexts.currentChoices[i];

                /*
                cardChoiceDisplays[i].activate();
                cardChoiceDisplays[i].setChoice(choice);
                i++;
                */
            }

            while (i < cardChoiceDisplays.Count)
            {
                /*
                cardChoiceDisplays[i].deactivate();
                i++;
                */
            }
        }

        topToBottomDivider.gameObject.SetActive(true);
        layoutTextboxes(true);
    }

    public IEnumerator selectChoice(cardChoice callingObject)
    {
        int choiceIndex = 0;

        for (int i = 0; i < cardChoiceDisplays.Count; i++)
        {
            if (cardChoiceDisplays[i] == callingObject)
            {
                choiceIndex = i;
            }

            //cardChoiceDisplays[i].deactivate();
        }

        cardTexts.ChooseChoiceIndex(choiceIndex);

        bottomText.text = "";

        while (cardTexts.canContinue)
        {
            string continueText = cardTexts.Continue();
            bottomText.text += "     ";
            for (int i = 0; i < continueText.Length; i++)
            {
                bottomText.text += continueText[i];
                layoutTextboxes(false);

                yield return new WaitForSeconds(cardDisplaySpeed);
            }
        }
        setCardExitVisiblity(true);
    }

    public void layoutTextboxes(bool displayChoices)
    {
        //setup
        RectTransform titleTransform = titleText.GetComponent<RectTransform>();
        RectTransform topTransform = topText.GetComponent<RectTransform>();
        RectTransform bottomTransform = bottomText.GetComponent<RectTransform>();
        RectTransform choiceTransform = cardChoiceDisplays[0].GetComponent<RectTransform>();

        scaleTextboxToContent(titleTransform, titleText);
        scaleTextboxToContent(topTransform, topText);
        scaleTextboxToContent(bottomTransform, bottomText);
        scaleTextboxToContent(choiceTransform, cardChoiceDisplays[0].choiceText);

        while (true)
        {
            if (additionalChoiceDividers.Count == 0) break;

            Destroy(additionalChoiceDividers[0].gameObject);
            additionalChoiceDividers.RemoveAt(0);
        }

        //Arrange textboxes
        float textboxBottom = rectTransformBottom(titleTransform);

        topTransform.anchoredPosition = new Vector2(topTransform.anchoredPosition.x, textboxBottom-titleToTopSpacing);
        textboxBottom = rectTransformBottom(topTransform);

        topToBottomDivider.anchoredPosition = new Vector2(topToBottomDivider.anchoredPosition.x, textboxBottom- topToBottomSpacing * topToBottomDividerLocation);

        bottomTransform.anchoredPosition = new Vector2(bottomTransform.anchoredPosition.x, textboxBottom - topToBottomSpacing);

        //Arrange choices
        choiceTransform.anchoredPosition = new Vector2(choiceTransform.anchoredPosition.x, textboxBottom - topToBottomSpacing);
        textboxBottom = rectTransformBottom(choiceTransform);

        if (cardTexts.currentChoices.Count == 0 || !displayChoices)
        {
            choiceDivider.gameObject.SetActive(false);

            return;
        } else
        {
            choiceDivider.gameObject.SetActive(true);
            choiceDivider.anchoredPosition = new Vector2(choiceDivider.anchoredPosition.x, textboxBottom - (choiceSpacing / 2));
        }

        for (int i = 1; i < cardChoiceDisplays.Count; i++)
        {
            //choice box contents
            choiceTransform = cardChoiceDisplays[i].GetComponent<RectTransform>();
            scaleTextboxToContent(choiceTransform, cardChoiceDisplays[i].choiceText);
            choiceTransform.anchoredPosition = new Vector2(choiceTransform.anchoredPosition.x, textboxBottom - choiceSpacing);
            textboxBottom = rectTransformBottom(choiceTransform);

            if (i >= cardTexts.currentChoices.Count) continue;
            //bottom divider
            RectTransform newDivider = Instantiate(choiceDivider);
            newDivider.SetParent(choiceDivider.parent);
            newDivider.sizeDelta = choiceDivider.sizeDelta;
            newDivider.localScale = choiceDivider.localScale;
            newDivider.anchoredPosition3D = new Vector3(newDivider.anchoredPosition.x, textboxBottom - (choiceSpacing / 2), 0f);
            newDivider.eulerAngles = Vector3.zero;
            additionalChoiceDividers.Add(newDivider);
        }
    }

    private void scaleTextboxToContent(RectTransform rectTransform, TextMeshProUGUI textComponent)
    {
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 0.25f);

        while (true)
        {
            textComponent.ForceMeshUpdate();
            if (!textComponent.isTextOverflowing) break;
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y + 0.25f);

        }
    }

    private float rectTransformBottom(RectTransform rectTransform)
    {
        return rectTransform.anchoredPosition.y - rectTransform.sizeDelta.y;
    }

    private void parseKnotTags(List<string> tags)
    {
        currentKnotTagValues.Clear();
        string[] tagPair = new string[2];

        for (int i = 0; i < tags.Count; i++)
        {
            tagPair = tags[i].Split(":");
            currentKnotTagValues.Add(tagPair[0], tagPair[1]);
        }
    }

    public void setCardExitVisiblity(bool visibility)
    {
        cardExitButton.gameObject.SetActive(visibility);
    }


}
