using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deck3D : MonoBehaviour
{
    static List<deck3D> allDecks = new List<deck3D>();
    [HideInInspector] public int currentDeckSize;

    public narrativeInkKnots.deckTags deckTag;

    private void Awake()
    {

        allDecks.Add(this);
    }

    private void OnDestroy()
    {
        allDecks.Remove(this);
    }

    public void deckInteracted()
    {
        if (!mapManager.getInstance().isMapInteractable) return;
        if (narrativeInkKnots.getInstance().getAvailableCardAmount(deckTag) == 0) return;

        narrativeCardController.getInstance().deckInteracted(deckTag, this);
    }

    public static void refreshDeckSizes()
    {
        for (int i = 0; i < allDecks.Count; i++)
        {
            allDecks[i].updateDeckSize(narrativeInkKnots.getInstance().getAvailableCardAmount(allDecks[i].deckTag));
        }
    }

    private void updateDeckSize(int newDeckSize)
    {
        currentDeckSize = newDeckSize;

        if (narrativeCardController.getInstance().currentDeck == this)
        {
            currentDeckSize--;
        }

        transform.localScale = new Vector3(transform.localScale.x, (1f/52f) * currentDeckSize, transform.localScale.z);

    }
}
