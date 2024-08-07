using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatManager : MonoBehaviour
{
	private static combatManager instance;
    public int bonusPlayerDefend { private set; get; }
    public int bonusPlayerAttack { private set; get; }


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
