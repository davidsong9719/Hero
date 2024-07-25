using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class visualSettings : MonoBehaviour
{
    private static visualSettings instance;

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

        cardThickness = cardThicknessReference;
        unhighlightedText = unhighlightedTextReference;
        highlightedText = highlightedTextReference;
    }

    public static visualSettings getInstance()
    {
        return instance;
    }

    [Header("Narrative Card Settings")]
    [SerializeField] float cardThicknessReference;
    [SerializeField] Color unhighlightedTextReference;
    [SerializeField] Color highlightedTextReference;

    [Header("Combat Card Settings")]
    [SerializeField] Color _defaultValueColor;
    [SerializeField] Color _negativeValueColor;
    [SerializeField] Color _positiveValueColor;

    public Color defaultValueColor
    {
        get => _defaultValueColor;
    }

    public Color negativeValueColor
    {
        get => _negativeValueColor;
    }

    public Color positiveValueColor
    {
        get => _positiveValueColor;
    }

    public static float cardThickness { private set; get; }
    public static Color unhighlightedText { private set; get; }
    public static Color highlightedText { private set; get; }

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
