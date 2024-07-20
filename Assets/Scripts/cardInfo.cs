using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class cardInfo : MonoBehaviour
{
    public TextMeshProUGUI titleText, topText, bottomText;
    public List<cardChoice> cardChoices;
    public RectTransform topBottomDivider;
    public Canvas canvasComponent;
    public cardButton buttonComponent;
    public Image timeDisplay;

    private void Start()
    {
        if (mapManager.getInstance().isDay())
        {
            timeDisplay.color = Color.yellow;
        } else
        {
            timeDisplay.color = Color.gray;
        }
    }
}
