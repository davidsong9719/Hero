using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class mapManager : MonoBehaviour
{
    [SerializeField] int dayLength;
    [SerializeField] int nightLength;
    [SerializeField] TextMeshProUGUI debugTimeDisplay;
    private int currentTime;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            progressTime();
        }
    }

    public static void enableMapInteraction()
    {
        instance.isMapInteractable=true;
    }

    public static void disableMapInteraction()
    {
        instance.isMapInteractable = false;
    }

    /// <summary>
    /// 0 is sunrise (start of day), dayLength variable is sunset (start of night)
    /// </summary>
    public static int getCurrentTime()
    {
        return instance.currentTime;
    }

    public bool isDay()
    {
        return currentTime < dayLength;
    }

    public static mapManager getInstance()
    {
        return instance;
    }

    public void progressTime()
    {
        currentTime++;

        if (currentTime >= dayLength+nightLength)
        {
            currentTime = 0;
        }

        if (currentTime < dayLength)
        {
            narrativeInkKnots.getInstance().setInkStoryTime("day");
            debugTimeDisplay.text = "Day (" + currentTime.ToString() + ")";
        } else
        {
            narrativeInkKnots.getInstance().setInkStoryTime("night");
            debugTimeDisplay.text = "Night (" + currentTime.ToString() + ")";
        }
    }

    
}
