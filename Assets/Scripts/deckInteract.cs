using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deckInteract : clickable3dBehavior
{
    [SerializeField] narrativeInkKnots.deckTags deckTag;
    

    public override void onCursorClick()
    {
        if (!mapManager.getInstance().isMapInteractable) return;
        if (narrativeInkKnots.getInstance().getAvailableCardAmount(deckTag) == 0) return;

        narrativeCardController.getInstance().deckInteracted(deckTag, gameObject.transform);
        mapManager.disableMapInteraction();

        //update deck size by -1
    }
}
