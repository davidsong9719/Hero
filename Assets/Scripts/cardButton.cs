using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class cardButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public enum exitFunction
    {
        none,
        nextCard,
        store,
    }

    //attack to choice text gameObject;
    private Image buttonImage;

    [SerializeField] Sprite  nextCardSprite, storeSprite, enterCombatSprite;
    private exitFunction currentButtonFunction;

    private void Awake()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.alphaHitTestMinimumThreshold = 0f;
    }

    private void OnEnable()
    {
        buttonImage.color = Color.white;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        buttonImage.color = visualSettings.highlightedText;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        buttonImage.color = Color.white;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        narrativeCardController.getInstance().buttonInteracted(currentButtonFunction);
    }

    public void setButtonFunction(exitFunction newButtonFunction)
    {
        switch(newButtonFunction)
        {
            case exitFunction.none:
            case exitFunction.store:
                buttonImage.sprite = storeSprite;
                break;

            case exitFunction.nextCard:
                buttonImage.sprite = nextCardSprite;
                break;

            default:
                Debug.LogWarning("Enum has not been implemented in button switch function");
                break;
        }

        currentButtonFunction = newButtonFunction;
    }
}
