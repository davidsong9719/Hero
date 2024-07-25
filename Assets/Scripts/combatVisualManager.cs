using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatVisualManager : MonoBehaviour
{
    private static combatVisualManager instance;

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

    public static combatVisualManager getInstance()
    {
        return instance;
    }

    public GameObject attackCardPrefab;
    public GameObject defendCardPrefab;
    public GameObject effectCardPrefab;
}
