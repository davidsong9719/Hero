using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatSystem : MonoBehaviour
{
    private string currentState; //player-choose, opponent-choose, increment speed
    private combatVisualManager visualManager;

    private int currentCharacterIndex;
    private List<characterInfo> currentCharacters = new List<characterInfo>(); //0 is reserved for player character
    private characterInfo playerInfo => playerManager.getInstance().playerInfo;

    [SerializeField] private int playerHandAmount;
    [SerializeField] float speedIncrementDelay;

    private void Awake()
    {
        visualManager = GetComponent<combatVisualManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            startCombat(new List<characterInfo>());
        }
    }
    public void startCombat(List<characterInfo> enemies)
    {
        currentCharacters.Clear();
        currentCharacters.Add(playerInfo);
        playerInfo.startCombatReset();

        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].startCombatReset();
            currentCharacters.Add(enemies[i]); 
        }
        
        currentCharacterIndex = currentCharacters.Count - 1;
        //StartCoroutine(progressTurns());
        startPlayerTurn();
    }

    IEnumerator progressTurns()
    {
        currentState = "increment speed";
        yield return new WaitForSeconds(speedIncrementDelay);

        while (true)
        {
            currentCharacterIndex++;
            if (currentCharacterIndex == currentCharacters.Count)
            {
                currentCharacterIndex = 0;
            }
            currentCharacters[currentCharacterIndex].incrementSpeed();

            //update speed ui here

            if (currentCharacters[currentCharacterIndex].canCharacterAct())
            {
                yield return new WaitForSeconds(speedIncrementDelay / 2);

                if (currentCharacterIndex == 0)
                {
                    startPlayerTurn();
                } else
                {
                    startNPCTurn();
                }
                break;
            }

            yield return new WaitForSeconds(speedIncrementDelay);
        }
    }

    //===Player Turn===
    private void startPlayerTurn()
    {
        currentState = "player-choose";
        //uiScript.hasSelectedCard = false;

        for (int i = 0; i < playerHandAmount; i++)
        {
            drawCard();
        }
    }

    private void drawCard()
    {
        visualManager.spawnCard(playerInfo.drawCard());
    }

    //===NPC TURN===
    private void startNPCTurn()
    {

    }
}
