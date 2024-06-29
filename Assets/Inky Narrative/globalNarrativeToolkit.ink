EXTERNAL affectHealth(healthAmount)
===function affectHealth(healthAmount)===
~return 0

EXTERNAL gainItem(itemName)
===function gainItem(itemName)===
~return "null"

EXTERNAL loseCardChoice(cardAmount)
===function loseCardChoice(cardAmount)===
~return 0

//for cards that are affected by decisions from other knots
VAR isVampiric = false
VAR sidedWithBartender = false
VAR forkChoice = ""

//to immediately go to another card after finishing current one
//use #exitFunction:nextCard>>>knotName   on the last line of the choice or knot
//like so: #exitFunction:nextCard>>>AncientWeapon
    
//to start combat
//use (BREAK)Fight:TopHalfEnemyTag/BottomHalfEnemyTag/attack/defense/speed/health/
//or (BREAK)Fight:TopHalfEnemyTag/BottomHalfEnemyTag/
//like so: (BREAK)fight:Random/Random
//like so: (BREAK)fight:Skeleton/Goblin/10/10/2/5