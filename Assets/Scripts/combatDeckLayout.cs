using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class combatDeckLayout : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] displayInfo displayContext;

    private enum displayInfo
    {
        playerDeck,
        drawPile,
        discardPile,
        exchangeDeck
    }

    private List<combatCard> cardList = new List<combatCard>();

    [Header("Setup")]
    public List<Transform> displayObject;


    private void Awake()
    {
        deleteInspectorImages();
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        refreshDisplay();
    }

    private void deleteInspectorImages()
    {
        for (int i = 0; i < displayObject.Count; i++)
        {
            if (displayObject[i].childCount > 0)
            {
                Destroy(displayObject[i].GetChild(0).gameObject);
            }
        }

    }

    private void refreshDisplay()
    {
        cardList.Clear();

        
        switch (displayContext)
        {
            case displayInfo.playerDeck:
            case displayInfo.exchangeDeck:
                cardList = playerManager.getInstance().playerInfo.getDeck();
                break;

            case displayInfo.drawPile:
                //cards = copyToCardList(combatManager.getInstance().drawPile, true);
                break;

            case displayInfo.discardPile:
                //cards = copyToCardList(combatManager.getInstance().discardPile, true);
                break;
        }

        //Generates cardList cards at displayObject positions
        for (int i = 0; i < cardList.Count; i++)
        {
            if (i >= displayObject.Count)
            {
                Debug.LogWarning("There's more cards than there are displayObjects");
                break;
            }

            generateCard(displayObject[i].transform, cardList[i]);
        }
    }

    private GameObject generateCard(Transform displayLocationTransform, combatCard cardInfo)
    {
        //===Initiate Card===
        GameObject newCard = null;

        switch (cardInfo.type)
        {
            case combatCard.cardType.Attack:
                newCard = Instantiate(combatVisualManager.getInstance().attackCardPrefab, displayLocationTransform);
                break;

            case combatCard.cardType.Defend:
                newCard = Instantiate(combatVisualManager.getInstance().defendCardPrefab, displayLocationTransform);
                break;

            case combatCard.cardType.Effect:
                newCard = Instantiate(combatVisualManager.getInstance().effectCardPrefab, displayLocationTransform);
                break;
        }

        //===Set Card Info===
        combatCardHandler cardHandler =  newCard.GetComponent<combatCardHandler>();
        cardHandler.setCardInfo(cardInfo);

        return newCard;

    }
}
