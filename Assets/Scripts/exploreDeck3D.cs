using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exploreDeck3D : deck3D
{

    private void Start()
    {
        narrativeCardController.addToExploreDeck(deckTag, this);
    }

}
