using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class visualSettings : MonoBehaviour
{
    [Header("Card Settings")]
    [SerializeField] Color unhighlightedTextReference;
    [SerializeField] Color highlightedTextReference;
    public static Color unhighlightedText { private set; get; }
    public static Color highlightedText { private set; get; }
    

    [Header("Animation Curves")]
    [SerializeField] AnimationCurve easeOutCurveReference;
    [SerializeField] AnimationCurve easeOutCurveVar0Reference;
    public static AnimationCurve easeOutCurve { private set; get; }
    public static AnimationCurve easeOutCurveVar0 { private set; get; }

    private void Awake()
    {
        
        unhighlightedText = unhighlightedTextReference;
        highlightedText = highlightedTextReference;
        easeOutCurve = easeOutCurveReference;
        easeOutCurveVar0 = easeOutCurveVar0Reference;
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
