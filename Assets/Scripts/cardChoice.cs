using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class cardChoice : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    //attack to choice text gameObject;
    public TextMeshProUGUI choiceText { get; private set;}
    public Choice inkChoice;

    private void Awake()
    {
        choiceText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        choiceText.color = visualSettings.unhighlightedText;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        choiceText.color = visualSettings.highlightedText;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        choiceText.color = visualSettings.unhighlightedText;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        narrativeCardController.getInstance().chooseChoice(inkChoice);
    }



}
