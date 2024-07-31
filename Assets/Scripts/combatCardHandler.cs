using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class combatCardHandler : clickable2dBehavior
{
    [HideInInspector] public combatVisualManager visualManager;

    private combatCard cardInfo;
    [SerializeField] private TextMeshProUGUI descriptionComponent;
    [SerializeField] private TextMeshProUGUI titleComponent;

    private float moveSpeed => visualManager.cardMoveSpeed;
    private AnimationCurve moveCurve => visualManager.cardMoveCurve;

    private string state; //docked, follow mouse, freeze

    private Vector3 targetPosition;

    public void setCardInfo(combatCard newCardInfo)
    {
        cardInfo = newCardInfo;

        updateCardDescription();
        updateCardTitle();
    }

    private void updateCardTitle()
    {
        titleComponent.text = cardInfo.cardName;
    }
    private void updateCardDescription()
    {
        //===generate description value===
        string newDescription = cardInfo.description;

        int cardValue = 0;

        if (cardInfo.type == combatCard.cardType.Defend)
        {
            cardValue = cardInfo.cardStrength + combatManager.getInstance().bonusPlayerDefend;
        }
        else if (cardInfo.type == combatCard.cardType.Attack)
        {
            cardValue = cardInfo.cardStrength + combatManager.getInstance().bonusPlayerAttack;
        }
        else if (cardInfo.type == combatCard.cardType.Effect)
        {
            cardValue = cardInfo.cardStrength;
        }

        string cardValueString = "";

        if (cardValue > cardInfo.cardStrength)
        {
            cardValueString = miscFunctions.createColorTaggedString(visualSettings.getInstance().positiveValueColor, cardValue.ToString());
        }
        else if (cardValue < cardInfo.cardStrength)
        {
            cardValueString = miscFunctions.createColorTaggedString(visualSettings.getInstance().negativeValueColor, cardValue.ToString());
        } 
        else
        {
            cardValueString = miscFunctions.createColorTaggedString(visualSettings.getInstance().defaultValueColor, cardValue.ToString());
        }

        newDescription = newDescription.Replace("$", cardValueString);

        //===set text && scale text===
        descriptionComponent.text = newDescription;

        while (true)
        {
            descriptionComponent.ForceMeshUpdate();
            if (descriptionComponent.isTextOverflowing)
            {
                descriptionComponent.fontSize--;
            }
            else
            {
                break;
            }
        }
    }

    public TextMeshProUGUI getDescriptionComponent()
    {
        return descriptionComponent;
    }

    public void setState(string newState)
    {
        state = newState;
    }

    public void setPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void setTarget(Vector3 target)
    {
        targetPosition = target;
    }


    private void moveTowardsTarget()
    {
        float distanceFromTarget = Vector3.Distance(transform.position, targetPosition);
        float moveCurveValue = moveCurve.Evaluate(distanceFromTarget/1000f);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime*moveSpeed*moveCurveValue);
    }

    private void targetMouse()
    {
        targetPosition = Input.mousePosition;
    }

    private void Update()
    {
        if (state == "follow mouse")
        {
            targetMouse();
            moveTowardsTarget();
        }

        if (state == "docked") {
            moveTowardsTarget();
        }
    }

    //===Pointer Enter===

    public override void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (state == "docked")
        {
            dockedPointerEnter();
        }
    }

    private void dockedPointerEnter()
    {
        transform.localScale = Vector3.one * 1.1f;
        transform.SetAsLastSibling();
    }

    //===Pointer Exit===

    public override void OnPointerExit(PointerEventData pointerEventData)
    {
        if (state == "docked")
        {
            dockedPointerExit();
        }
    }

    private void dockedPointerExit()
    {
        transform.localScale = Vector3.one;
        transform.SetSiblingIndex(combatVisualManager.getInstance().getDockedCardIndex(this));
    }

    //===Pointer Click===

    public override void OnPointerClick(PointerEventData pointerEventData)
    {
        if (state == "follow mouse")
        {
            playCard();
        }

        if (state == "docked")
        {
            dockedPointerClick();
        }


    }

    private void dockedPointerClick()
    {
        transform.localScale = Vector3.one;
        visualManager.removeFromDockedCardList(this);   
        visualManager.orderCards();
        state = "follow mouse";
    }

    private void playCard()
    {
        visualManager.playCard(this);
        state = "freeze";
    }

}
