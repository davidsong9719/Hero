using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miscFunctions : MonoBehaviour
{
    public static List<T> copyList<T>(List<T> list)
    {
        List<T> newList = new List<T>();

        for (int i =0; i< list.Count; i++)
        {
            newList.Add(list[i]);
        }
        return newList;
    }


    /// <summary>
    /// Creates a new randomized list from given list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static List<T> randomizeList<T>(List<T> list)
    {
        List<T> newList = new List<T>();

        while (list.Count > 0)
        {
            int randomIndex = Random.Range(0, list.Count);
            newList.Add(list[randomIndex]);
            list.RemoveAt(randomIndex);
        }

        return newList;
    }

    public static string createColorTaggedString(Color color, string text)
    {
        return createStartingColorTag(color) + text + createEndingColorTag();
    }

    public static string createStartingColorTag(Color tagColor)
    {
        return "<color=#" + ColorUtility.ToHtmlStringRGBA(tagColor) + ">";
    }

    public static string createEndingColorTag()
    {
        return "</color>";
    }
    /*
     * Singleton Template
     * 
        if (instance != null && instance != this)
        {
            Debug.LogWarning("There were multiple objects attempting to be assigned as the singleton instance");
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    */
}
