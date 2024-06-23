using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapManager : MonoBehaviour
{

    public bool isMapInteractable { get; private set; } 
    
    private static mapManager instance;

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

        enableMapInteraction();
    }

    public static void enableMapInteraction()
    {
        instance.isMapInteractable=true;
    }

    public static void disableMapInteraction()
    {
        instance.isMapInteractable = false;
    }

    public static mapManager getInstance()
    {
        return instance;
    }
}
