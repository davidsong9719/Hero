using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class visualSettings : MonoBehaviour
{
    [Header("Card Settings")]
    [SerializeField] float cardThicknessReference;
    [SerializeField] Color unhighlightedTextReference;
    [SerializeField] Color highlightedTextReference;

    public static float cardThickness { private set; get; }
    public static Color unhighlightedText { private set; get; }
    public static Color highlightedText { private set; get; }

    private void Awake()
    {
        cardThickness = cardThicknessReference;
        unhighlightedText = unhighlightedTextReference;
        highlightedText = highlightedTextReference;
    }


    /*
     * USELESS, CHANGING PIVOT AT RUNTIME DOES HAS NO AFFECT ON ANCHORED POSITION VALUE
     * 
    static public Vector3 anchoredPositionAtPivot(RectTransform rectTransfrom, Vector2 targetPivot)
    {
        Vector2 originalPivot = rectTransfrom.pivot;

        rectTransfrom.pivot = targetPivot;
        Vector3 targetAnchoredPosition = rectTransfrom.anchoredPosition3D;
        rectTransfrom.pivot = originalPivot;

        return targetAnchoredPosition;
    }
    */
}
