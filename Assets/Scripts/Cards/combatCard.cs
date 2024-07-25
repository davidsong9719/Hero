using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable object/Combat card")]
public class combatCard : ScriptableObject
{
    public cardType type;
    public int cardStrength;

    [Header("Effect Card Variables")]
    public string cardName;
    [TextArea(15, 20)] public string description;

    //categorize item by 3 types
    public enum cardType
    {
        Attack,
        Defend,
        Effect
    }
}