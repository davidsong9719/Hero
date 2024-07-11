using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class cardButton : clickable2dBehavior
{
    public enum buttonFunction
    {
        none,
        nextCard,
        store,
        enterCombat
    }

    //attack to choice text gameObject;
    private Image buttonImage;

    [SerializeField] Sprite  nextCardSprite, storeSprite, enterCombatSprite;
    private buttonFunction currentButtonFunction;

    private void Awake()
    {
        buttonImage = GetComponent<Image>();
        //buttonImage.alphaHitTestMinimumThreshold = 0f;
    }

    private void OnEnable()
    {
        buttonImage.color = Color.white;
    }

    public override void OnPointerEnter(PointerEventData pointerEventData)
    {
        buttonImage.color = visualSettings.highlightedText;
    }

    public override void OnPointerExit(PointerEventData pointerEventData)
    {
        buttonImage.color = Color.white;
    }

    public override void OnPointerClick(PointerEventData pointerEventData)
    {
        narrativeCardController.getInstance().buttonInteracted(currentButtonFunction);
    }

    public void setButtonFunction(buttonFunction newButtonFunction)
    {
        switch(newButtonFunction)
        {
            case buttonFunction.none:
            case buttonFunction.store:
                buttonImage.sprite = storeSprite;
                break;

            case buttonFunction.nextCard:
                buttonImage.sprite = nextCardSprite;
                break;

            case buttonFunction.enterCombat:
                buttonImage.sprite = enterCombatSprite;
                break;

            default:
                Debug.LogWarning("Enum has not been implemented in button switch function");
                break;
        }

        currentButtonFunction = newButtonFunction;
    }
}
