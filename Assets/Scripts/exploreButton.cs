using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using static narrativeInkKnots;

public class exploreButton : clickable2dBehavior
{
    enum buttonState
    {
        landmarkInteract,
        landmarkEmpty,
        exploreInteract,
        exploreEmpty,
        empty
    }

    [SerializeField] private playerFigureController player3Dcontroller;
    [SerializeField] private TextMeshProUGUI debugTextDisplay;

    private buttonState currentState;
    private buttonState currentButtonState
    {
        get
        {
            return currentState;
        }
        set
        {
            currentState = value;
            updateButtonDisplay(value);
        }
    }

    private void Update()
    {
        currentButtonState = updateButtonState();

    }

    public override void OnPointerClick(PointerEventData pointerEventData)
    {
        if (!mapManager.getInstance().isMapInteractable) return;

        switch (currentButtonState)
        {
            case buttonState.exploreInteract:
                narrativeCardController.getInstance().deckInteracted(player3Dcontroller.currentExploreDecks);
                break;

            case buttonState.landmarkInteract:
                player3Dcontroller.currentLandmark.landmarkDeck.deckInteracted();
                break;

            case buttonState.exploreEmpty:
            case buttonState.landmarkEmpty:
            case buttonState.empty:
                break;
    }

    }

    private buttonState updateButtonState()
    {
        //landmark deck
        if (player3Dcontroller.currentLandmark != null)
        {
            deckTags landmarkDeckTag = player3Dcontroller.currentLandmark.landmarkDeck.deckTag;

            if (narrativeInkKnots.getInstance().getAvailableCardAmount(landmarkDeckTag) > 0)
            {
                return buttonState.landmarkInteract;
            } else
            {
                return buttonState.landmarkEmpty;
            }
        }

        //explore decks
        List<deckTags> hitTags = player3Dcontroller.currentExploreDecks;

        for (int i = 0; i < hitTags.Count; i++)
        {
            if (narrativeInkKnots.getInstance().getAvailableCardAmount(hitTags[i]) > 0)
            {
                return buttonState.exploreInteract;
            }
        }

        if (hitTags.Count>0)
        {
            return buttonState.exploreEmpty;
        }

        return buttonState.empty;
    }

    private void updateButtonDisplay(buttonState state)
    {
        switch (state)
        {
            case buttonState.landmarkInteract:
                debugTextDisplay.text = "Enter";
                break;

            case buttonState.landmarkEmpty:
                debugTextDisplay.text = "There's no use coming here again";
                break;

            case buttonState.exploreInteract:
                debugTextDisplay.text = "Explore";
                break;

            case buttonState.exploreEmpty:
                debugTextDisplay.text = "There is nothing left to find here";
                break;

            case buttonState.empty:
                debugTextDisplay.text = "There is nothing to find here";
                break;
        }
    }
}
