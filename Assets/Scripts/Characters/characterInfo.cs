using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable object/Character Info")]
public class characterInfo : ScriptableObject
{
    public combatCard[] combatDeck;
    public weapon weaponInfo;

    [HideInInspector] public int health;
    public int maxHealth;

    public int speed;
    [HideInInspector] public int speedCounter;

    public int defense;
    public int damage;

    [HideInInspector] public bool isDead = false;

    [HideInInspector] public List<combatCard> drawPile = new List<combatCard>();
    [HideInInspector] public List<combatCard> handCards = new List<combatCard>();
    [HideInInspector] public List<combatCard> discardPile = new List<combatCard>();

    private void Awake()
    {
        health = maxHealth;
    }

    public void startCombatReset()
    {
        speedCounter = 0;
        drawPile = getDeck();
    }

    public void affectHealth(int amount)
    {
        health += amount;
        
        if (health > maxHealth) health = maxHealth;
        if (health < 0) die();
    }

    private void die()
    {
        isDead = true;
    }

    public void affectDefense(int amount)
    {

    }

    public void incrementSpeed()
    {
        speedCounter++;
        if (speedCounter == speed)
        {
            speed = 0;
        }
    }

    public bool canCharacterAct()
    {
        if (speed == 0)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Returns a list of all player cards and weapon cards by value (not reference!)
    /// </summary>
    /// <returns></returns>
    public List<combatCard> getDeck()
    {
        return getAllCombatCardsInDeck();
    }

    private List<combatCard> getAllCombatCardsInDeck()
    {
        List<combatCard> newList = new List<combatCard>();

        for (int i = 0; i < weaponInfo.cards.Length; i++)
        {
            newList.Add(weaponInfo.cards[i]);
        }

        for (int i = 0; i < combatDeck.Length; i++)
        {
            newList.Add(combatDeck[i]);
        }

        return newList;
    }

    public combatCard drawCard()
    {
        combatCard drawnCard = drawPile[0];
        drawPile.RemoveAt(0);

        if (drawPile.Count == 0)
        {
            //move discardPile to drawPile
            while (discardPile.Count > 0)
            {
                drawPile.Add(discardPile[0]);
                discardPile.RemoveAt(0);
            }
            shuffleDrawPile();
        }

        return drawnCard;
    }

    private void shuffleDrawPile()
    {
        List<combatCard> shuffledPile = new List<combatCard>();

        while (drawPile.Count > 0)
        {
            int randomIndex = Random.Range(0, drawPile.Count);
            shuffledPile.Add(drawPile[randomIndex]);
            drawPile.RemoveAt(randomIndex);
        }

        drawPile = shuffledPile;
    }
}