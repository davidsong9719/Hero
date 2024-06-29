using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatManager : MonoBehaviour
{
	private static combatManager instance;
    public enum enemyTags
    {
        Random,
        Skeleton,
        Goblin
    }

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

    public static combatManager getInstance()
    {
        return instance;
    }

	public void setNextEnemyInfo(string enemyInfo)
    {
        print(enemyInfo);
    }
}
