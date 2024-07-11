using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static narrativeInkKnots;

public class exploreButton : clickable2dBehavior
{
    [SerializeField] public playerFigureController playerMapIcon; 

    public override void OnPointerClick(PointerEventData pointerEventData)
    {
        if (!mapManager.getInstance().isMapInteractable) return;

        List<deckTags> hitTags = playerMapIcon.getCurrentExploreDecks();
        narrativeCardController.getInstance().deckInteracted(hitTags);
    }
}
