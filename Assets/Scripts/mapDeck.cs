using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapDeck : MonoBehaviour
{

    public narrativeManager.deckTags deckTag;
	
	private List<string> deckCards = new List<string>();

	public void setList(List<string> cardList)
	{
		deckCards = cardList;
		//deckCards = miscFunctions.copyList(cardList);
	}

	public string getCard()
	{
		return deckCards[Random.Range(0, deckCards.Count)];
	}


}
