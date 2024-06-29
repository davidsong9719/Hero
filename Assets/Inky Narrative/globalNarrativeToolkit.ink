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
//use #exitFunction:nextCard.knotName
//like so: #exitFunction:nextCard.AncientWeapon