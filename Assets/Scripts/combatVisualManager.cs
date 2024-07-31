using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class combatVisualManager : MonoBehaviour
{
    //===SINGLETON===
    private static combatVisualManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogWarning("There were multiple objects attempting to be assigned as the singleton instance");
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

    }

    public static combatVisualManager getInstance()
    {
        return instance;
    }



    public GameObject attackCardPrefab;
    public GameObject defendCardPrefab;
    public GameObject effectCardPrefab;

    [SerializeField] Transform drawDeckTransform;
    [SerializeField] Transform discardDeckTransform;
    [SerializeField] Transform playerHandCenter;

    public bool isCardFollowingCursor;

    [SerializeField] float dockedCardSpacing;
    public float cardMoveSpeed;
    public AnimationCurve cardMoveCurve;

    [SerializeField] Transform cardParent; //for organization in inspector hierachy;

    private List<combatCardHandler> activeCards = new List<combatCardHandler>();
    private List<combatCardHandler> dockedCards = new List<combatCardHandler>();

    public void spawnCard(combatCard cardInfo)
    {
        GameObject newCard = null;
        switch(cardInfo.type)
        {
            case combatCard.cardType.Attack:
                newCard = Instantiate(attackCardPrefab, cardParent);
                break;

            case combatCard.cardType.Defend:
                newCard = Instantiate(defendCardPrefab, cardParent);
                break;

            case combatCard.cardType.Effect:
                newCard = Instantiate(effectCardPrefab, cardParent);
                break;

            default:
                Debug.LogError("No prefab associated with card type:" + cardInfo.type);
                break;
        }

        combatCardHandler cardHandler = newCard.GetComponent<combatCardHandler>();
        cardHandler.visualManager = this;
        cardHandler.setCardInfo(cardInfo);
        cardHandler.setState("docked");
        cardHandler.setPosition(drawDeckTransform.position);

        activeCards.Add(cardHandler);
        dockedCards.Add(cardHandler);

        orderCards();
    }

    public void orderCards()
    {
        for(int i = 0; i < dockedCards.Count; i++)
        {
            float dockWidth = dockedCardSpacing * (((float)dockedCards.Count - 1) / 2f);

            float currentCardTargetX = playerHandCenter.position.x - dockWidth + dockedCardSpacing * i;
            dockedCards[i].setTarget(new Vector3(currentCardTargetX, playerHandCenter.position.y, playerHandCenter.position.z));
            dockedCards[i].transform.SetSiblingIndex(i);
        }
    }

    public int getDockedCardIndex(combatCardHandler cardHandler)
    {
        return dockedCards.IndexOf(cardHandler);
    }

    public void removeFromDockedCardList(combatCardHandler cardHandler)
    {
        dockedCards.Remove(cardHandler);
    }

    public void playCard(combatCardHandler playedCard)
    {
    
    }
}
