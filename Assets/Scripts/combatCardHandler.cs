using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class combatCardHandler : clickable2dBehavior
{
    private combatCard cardInfo;
    [SerializeField] private TextMeshProUGUI descriptionComponent;

    public void setCardInfo(combatCard newCardInfo)
    {
        cardInfo = newCardInfo;
        updateCardDescription();
    }

    private void updateCardDescription()
    {
        //===generate description value===
        string newDescription = cardInfo.description;

        int cardValue = 0;
        string cardValueString = "";

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
}
