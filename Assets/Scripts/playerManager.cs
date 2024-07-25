using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    private static playerManager instance;
    [SerializeField] private weapon playerWeapon;
    private List<combatCard> playerCombatCards = new List<combatCard>();
    private int health, maxHealth, speed, defense, damage;

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

    public static playerManager getInstance()
    {
        return instance;
    }

    public void influenceHealth(int amount)
    {
        print("Player health increased by: " + amount + ".");
    }

    public void influenceWealth(int amount)
    {
        print("Player wealth increased by: " + amount + ".");
    }

    public void gainItem(string itemName)
    {
        print("Player has gained " + itemName);
    }

    public void loseCardChoice(int amount)
    {
        print("Player will choose to discard " + amount + " card(s) permanently");
    }

    /// <summary>
    /// Passes a list of all player cards by value (not reference!)
    /// </summary>
    /// <returns></returns>
    public List<combatCard> getPlayerDeck()
    {
        return getAllCombatCardsInDeck();
    }

    private List<combatCard> getAllCombatCardsInDeck()
    {
        List<combatCard> newList = new List<combatCard>();

        for (int i = 0; i < playerWeapon.cards.Length; i++)
        {
            newList.Add(playerWeapon.cards[i]);
        }

        for (int i = 0; i < playerCombatCards.Count; i++)
        {
            newList.Add(playerCombatCards[i]);
        }

        return newList;
    }
}
