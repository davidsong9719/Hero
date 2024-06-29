using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    private static playerManager instance;

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
        print("Player health increased by: " + amount +".");
    }

    public void gainItem(string itemName)
    {
        print("Player has gained " + itemName);
    }

    public void loseCardChoice(int amount)
    {
        print("Player will choose to discard " + amount + " card(s) permanently");
    }

}
