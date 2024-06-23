using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class cardInfo : MonoBehaviour
{
    public TextMeshProUGUI titleText, topText, bottomText;
    public List<cardChoice> cardChoices;
    public RectTransform topBottomDivider;
    public Canvas canvasComponent;
    public cardButton buttonComponent;
}
