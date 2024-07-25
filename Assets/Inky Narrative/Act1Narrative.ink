INCLUDE globalNarrativeToolkit.ink
->TavernCelebration
===INDEX===
//road
TheFork0
MysteriousHole
TravelingMerchant
WorstMoment
Cows
AbandonedVillage
DemonSummon
Thievery
Sorcerer
Vampire0
HiddenMessage0
TheStranger0

//market
GoodDeed
MarketCrowd
MarketSadness
Samples
VendorMob
Hungry
AlleywayAmbush
PillagedVillage
RockSurprise
DrunkenDispute0
TheChampionship0

//tavern
TavernIntro
TavernRowdy
TavernDrunk
TavernOther
TavernCloakedFigures
TavernFight
TavernCelebration
TavernMeal
TavernContest
TavernRecipe
TavernWindow

//any
NiceDay
Trip
Ants
Overslept
Stargaze
DozedOff

//forest
Scared
Slimed
AncientWeapon
Stuck
Bracelet

//multiple
Fountain
Pickpocketed
Raccoon
Snooze
Temple
OvergrownTree
RansackedCamp
Downpour
->END

===TravelingMerchant===
#title:A Traveling Merchant 
#time:day
#location:road
…Oho? What’s this! A traveling merchant! A whimsical little guy as well! A short man with a massive beard and the aura of a jester hops up to you. He is offering a sample potion! For free! He grumbles when he realized you are too poor for to buy a full potion. The silly guy tries to sneak off with the sample but it’s too late, it’s already been offered. He slinks away sadly.
Gain [Jester's Sample]: /+1 to chosen stat for next battle, applies to one player.
~gainItem("Jester's Sample")
->END

===GoodDeed===
#title:Good Deeds
#time:day
#location:market
…You continue on your travels, zoning out until a lady stumbles in front of you. She hurries away, but you see that she’s dropped her coin pouch. 
+[Take it] 
You use it to buy some food. 
\+2 health 
~affectHealth(1)
->END

+[Chase after her] 
You hand back her money, but she accuses you of stealing it. After she finishes yelling up a storm, she scowls, spins on her heels and walks off in a huff. No good deed goes unpunished it seems.
->END

===Slimed===
#title:Slimed
#time:day
#location:forest
Something slimy drips onto you. You look around to try and find the source… 
\+gross
->END

===Fountain===
#title:A Miracle
#time:day
#location:road, forest
You take a step forward and fall right through the ground. 
+[A trap?]
Lucky for you, you just happened to fall into the fountain of youth. The riches you will receive for discovering this. You wonder what you will spend it on.
Replenish all health
~affectHealth(99999)
->END

===Pickpocketed===
#title:Remember?
#time:day
#location:road, market
You think you were pickpocketed last night, the nerve. Someone will pay for this. But for now, you must find out what was stolen.   
+[Check your bag] You shuffle through your bag, throwing everything on to the ground. All of your possessions seems to be accounted for? Unbeknownst to you, one of your relics rolled away while you were busy making a mess.  
Choose one card to permanently discard
~loseCardChoice(1)  
->END

+[Try to remember] You try your best to recall everything that led up to the pickpocketing, but all you end up thinking about is how stressful life has been recently.
Depressing... But you manage remember that you weren't actually pickpocketed.
->END

===NiceDay===
#title:Nice Day
#time:day
#location:any
What a nice day today. You feel strangely happy. You’re excited by what’s to come.
\+2 health
~affectHealth(2)
->END

===Trip===
#title:Worst Mistake
#time:day
#location:any
You trip and fall.
\+embarrassment 
-1 health
~affectHealth(-1)
->END

===Overslept===
#title:Sleepy
#time:day
#location:any
Sunlight pours into your eyes as you awaken. You’ve overslept! It’s noon already? You hurry up and get ready, your party definitely won’t be happy about this. You hurry on with your adventure…
\+late
->END

===Ants===
#title:Ants in a Line
#time:day
#location:any
…You get distracted. Where were you? What? You are too focused on watching a line of ants crawl towards a crumb. 
->END

===MarketCrowd===
#title:Market Chaos
#time:day
#location:market
The marketplace is becoming hectic yet again. Someone bumps into you. You turn around and they are lost amongst the crowd. 
Choose one card to permanently discard
~loseCardChoice(1)
->END

===MarketSadness===
#title:Retail Sadness
#time:day
#location:market
You find yourself browsing in the marketplace for things you cannot afford. What pretty scarves, what delicious fruits. You head back towards the wilderness, away from the warmth of the stalls…
\+sad
->END

===Samples===
#title:Samples Galore
#time:day
#location:market
You continue on your walk when suddenly you remember. There is a festival being held at the marketplace today. You know what that means— free food! Not really, most is paid, but you can steal the free samples! 
+[You head to the buzzing festival] Oh boy do you have a feast! You try drinks from all over, snacks from across the world! You sing and dance with your friends all throughout the night.
\+5 health
~affectHealth(5)
->END

===WorstMoment===
#title:Laughing Stock
#time:day
#location:road
Walking up the steps of an old pathway, you trip and roll all the way down to the bottom of the hill. A group of children laughs as you try to brush it off... 
\+shattered confidence 
-1 health
~affectHealth(-1)
->END

===Cows===
#title:The Countryside
#time:day
#location:road
You pass by a small hut with clothes hanging outside to dry. There's a few cows grazing in the pasture behind.
\+aww
->END

===VendorMob===
#title:Flash Sale
#time:day
#location:market
A nearby vendor yells for your attention and shows you what seems to be a free snack sample. You take one step, and suddenly, you're mobbed by merchants in every direction! In-between informing all of them that you're completely broke, you manage to sneak a few samples in your mouth. 
\+1 health
Best to leave before a thief comes along...
~affectHealth(1)
->END

===Raccoon===
#title:A Good Morning
#time:day
#location:road, forest
Something is rustling outside. Who’s there? Something claws at your tent. It wants to be let in. 

+[Take a peek outside] You scan your surroundings but you see nothing. Until you look down. A mere raccoon with its beady eyes looks up at you. You give it a little pet and a treat and send it on its way.
->END

+[Hide] Coward. You wait, frozen in fear. The creature eventually stops. It seems to have left for now, you are safe.
You check for lost or broken items and continue about your day…
->END

===Snooze===
#title:Quick Snooze
#time:day
#location:road, forest
You know what? You’re too tired for this. You can go back here tomorrow. You want sleep. You head back to camp and snooze.
\+1 health
~affectHealth(1)
->END

===AbandonedVillage===
#title:Downpour
#time:day
#location:road
It pours outside, you hurry to find shelter from the rain. You head to the nearest village and knock on every door you see, begging to be let in. No one responds. After what feels like a lifetime of this, you remember that this village has been long abandoned. The doors aren’t locked.
\+soaked
->END

===Stargaze===
#title:Stargazer
#time:night
#location:any
You pause and admire the stars. It's nice to take a break every once in a while.
\+1 health
~affectHealth(1)
->END

===Scared===
#title:A Crow
#time:day
#location:forest
It is eerily silent. A crow in the distance caws. You jump from the noise. All your other party members laugh at you.
\+shame +cowardly

You clear your throat and try your best to continue on…
->END

===Temple===
#title:A Temple
#time:day
#location:forest, road
You stumble across an abandoned temple. Opening the door, you find a lone monster dancing a jig. Upon seeing you, it quickly grabs it's weapon and stands guard. There is no getting past it without a fight. 
[fight an enemy]
->END

===Hungry===
#title:Desperate Measures
#time:day
#location:market
You see the bustling marketplace in the distance. Your camp supplies are running low, so you take a look. An uncanny looking owner beckons you over to his stall, where he sells a wide assortment of foods from all over. Your stomach grumbles. Your wallet stresses. You then notice the price… "$500", thats $500 more than you have.

+[Steal the food] Bad move, the storeowner… melts? The marketplace is immediately thrown into chaos the once human rebuilds into a cursed creature. You’ve angered it.
[fight an enemy] +5 health upon victory
Gain [food]: +1 health for next battle.
~gainItem("Food")
->END

+[Leave] The storeowner’s face falls. Almost literally, but it seems you must remain hungry another day.
-morale +hungry
->END

===OvergrownTree===
#title:The Tree
#time:day
#location:road, forest
You step under an overgrown tree for a quick break. As your eyes start to close, you notice the shadows swirling oddly. You roll out of pure instinct. The grass where you laid mere moments ago lays the claws of a furious monster. It's oddly defensive about this tree.

+[Fight it] Empowered by some strange force, this monster appears much stronger than you thought it was. 
[fight an enemy] +2 attack for the enemy
From its corpse you spot a little branch sticking out. Maybe this was what was making it stronger.
Gain [Twisted Branch]: +2 attack and -1 health for the next two encounters.
~gainItem("Twisted Branch")
->END

+[Leave it alone] Best not to be a rude guest.
->END

===AlleywayAmbush===
#title:Cloaked Figure
#time:day
#location:market
You take a peek down a random alleyway and spot a cloaked figure. It gestures for you to come closer.

+[Go towards it] As you walk fully into the shadows, the figure throws it's cloak into the ground, revealing a monster!
[fight an enemy]
->END

+[Ignore it] You try to ignore the weirdo in the alleyway until moments later when something strikes you leg, hard. You turn around and see it's the same thing from before, only now fully revealed in the daylight!
[fight an enemy] with -1 speed and health for the active player
->END

===RansackedCamp===
#title:Ransacked
#time:day
#location:forest, road
You decide to head back to camp, only to find it’s been completely ransacked? Who- no, what did this? This isn’t the work of another person, the claw marks left on the last shreds of your tents tell you that much. You hope it’s just a raccoon. Or something equally as measly. It is not.
[fight an enemy]
->END

===PillagedVillage===
#title:Heroic Entrance
#time:day
#location:market
You are stopped in your path when you hear screaming in the distance. Out of curiosity, you take a look. Pushing through the running crowds, you are faced with several monsters pillaging the village. Villagers beg for your help.

+[Help] You ready your weapon. One of the creatures turn to face you and laugh.
[fight an enemy]
The remaining monsters run away in fear. The villagers thank you, and give you the little they have left. 
Gain [Old Charm]: -1 to all enemy stats for one encounter.
~gainItem("Old Charm")
->END
+[Leave] Not your problem. The villagers cry in despair.
->END

===Downpour===
#title:The odds
#time:day
#location:road, forest
It starts to rain as you walk. Then it starts to pour. In front of you lays a skeleton, and you start to picture how cool it would look if it was struck by lightning. Lightning immediately hits it. Instead of the fried corpse you thought would remain, the lightning has reanimated it. The creature crawls towards you.
[fight an enemy]
->END

===DozedOff===
#title:Life-saving sportsmanship
#time:day
#location:any
You startle awake when you feel something tap you. You’ve dozed off mid battle, yet your opponent has waited patiently while you slept. Time to finish this.
\+1 health 
~affectHealth(1)
    
//(BREAK)fight:Random/Random


You, proud and victorious, walk off prepared to face anything...
\+ego
#exitFunction:nextCard/AncientWeapon
->END

===RockSurprise===
#title:Challenger
#time:day
#location:market
"Watch Out!" you hear somebody yell. You turn around as fast as you can before a rock hits you square in the nose. The villager, who you assume was the one that gave you the warning, points towards an furious monster. 
 -1 health
 ~affectHealth(-1)
[fight an Enemy]
->END

===DemonSummon===
#title:Visitor
#time:day
#location:road
You waltz on without a care into a small town. The town has been friendly and inviting, offering you food and shelter. Still, your instincts tell you to be wary. You see no reason to fear them, but your gut is rarely wrong. You decide to slip into the towns church to investigate. Muffled chanting comes from the back room. With a sudden flash of blood red light, you are faced with a monster. What demon has this cult summoned?
[fight an enemy]
The once welcoming town has become hostile. They don’t like when outsiders meddle with their business. You get kicked back out into the wild.
->END

===Thievery===
#title:Dirt Road Robbery
#time:day
#location:road
You continue to trudge on. It’s getting late. But there! In the distance! You spot a camp! Someone else’s, but you don’t see anyone there. The campers must’ve left for a bit, but they’ll probably be back soon. So what do you do? Loot them, obviously.
\+[Thief’s Dagger]: once every encounter, sneak attack and negate defense.
~gainItem("Thief's Dagger")
->END

===AncientWeapon===
#title:Ancient Opportunity
#time:day
#location:forest
You see an ancient weapon. It seems heavily guarded. You worry about traps.  

+[Take it] Gain \[Sharpened Arrow\]: +1 attack.
\-2 health for active player
~affectHealth(1)
~gainItem("Sharpened Arrow")
->END
+[Leave it] It probably wasn't worth it anyways
->END

===Stuck===
#title:Stuck
#time:day
#location:forest
You find a cave tight enough to give the most courageous soul crippling claustrophobia. You, not out of bravery but rather out of unintelligence, decide to squeeze in because you see something shiny. You are lucky that your party members are there to pull you out when you get stuck. 
\+[Shiny Gem]: Heal one player by 3 health once every battle.
~gainItem("Shiny Gem")
->END

===Bracelet===
#title:Looter
#time:day
#location:forest, road
Pebbles crunch beneath your feet as you trudge through the ruins. There is a hand sticking out the center of a destroyed building. It holds a bracelet with protective runes etched on its beads. How ironic.
Gain [Bracelet of Protection?]: -1 health, +1 defense every round
~gainItem("Bracelet of Protection")
->END

===Sorcerer===
#title:The Oracle
#time:day
#location:road
You get suddenly snatched into a tent while passing through a small town!  An old, towering sorcerer leans over you and grabs your hands. ""Have my orb,"" she says, after inspecting your palms, "it'll be more of use for you than me."   

+[Accept] Gain \[Orb of Sacrifices\]: At any point, players can choose to transfer 2 points of health into the orb. On it's use, the Orb deals +1 damage for each transfer. Exploding into fine shards, it cannot be used again.
~gainItem("Orb of Sacrifices")
->END

+[Refuse] She whispers into your ear, "you won't be alive long enough to use it anyways," before kicking you out.
->END

===Vampire0===
#title:Vampire's Dilemma
#time:day
#location:road
The sun is setting. There is a barn nearby and not a human in sight, A cow couldn't be that bad of a roommate, so you head in. To your surprise, someone is already there. Pale as a ghost, with teeth sharp as knives, it's a vampire! But you are safe, for this one declares himself a vegan! Or so you thought. "Humans don't count!" the vampire says. He then lunges to bite you.

+[Let him bite you] The poor thing looks so starved. You somehow pity him.
\-self preservation skills -1 health for one player
~affectHealth(-1)
~isVampiric = true
->END
+[Kill him] You just happen to have a wooden stake for this exact moment.
~isVampiric = false
->END

===DrunkenDispute0===
#title:Drunken Dispute
#time:day
#location:market
Your journey has been disrupted. Annoying bickering pierces your ears. What a pain. Following the sounds in hopes you can get them to shut up, you reach a tavern, one that will empty soon no doubt. Inside, a drunk man is arguing with a bartender. "It was.. nasty!! A s-scam!!" He slurs his words. The bartender looks at him with condescending, yet pitying eyes. "The 12 prior orders suggest otherwise." The drunken man angers, demanding a refund. You notice his cup is still full.

+[Side with the drunk man] Despite his tantrum, he barely touched his drink. Normal stores would offer a refund.
Plus, that bartender seems pretentious. You don't like him.
~sidedWithBartender = false
->END

+[Side with the bartender] What an annoying customer, this is practically harassment. He should be kicked out, it is not difficult to do as all his punches miss.
~sidedWithBartender = true
->END

===HiddenMessage0===
#title:Hidden Message
#time:day
#location:road, forest
You decide to visit the riverbank beside your camp. You find that it has become your safe haven whenever you need a moment of calm. Birds sing above you. Waves ripple below you. Dipping your feet into the cool water, you feel something lightly tap you from below the current. Looking down, you notice a small bottle. Littering? Someone wasn't taught manners. You pop open the cork and look inside. A tiny scroll sits in the bottom. Unraveling it reveals a hastily scribbled note. Whoever wrote this was in a rush. Or has bad handwriting. It reads  "... ends ... the ... end". How cryptic. The shadow in the corner of your eye has disappeared.
Gain [message in a bottle] - You do not know what this means, yet.
~gainItem("Message in a Bottle")
->END

===TheFork0===
#title:Fork in the Road
#time:day
#location:road
There's a fork in the road, with no indication of which path leads to where. You scan the horizon for any possible information, but the paths disappear inside two forests on opposite sides of the valley.
However, you do spot that the forest on the right is oddly shrouded in darkness, while the one on the left is somehow glowing.

+[Light Path]
Your compass spins wildly as you step inside the glowing forest. As you get deeper in, the trees around you become brighter and brighter until you can barely keep your eyes open. Suddenly, everything goes dark. You feel around for a few minutes, making sure your life isn't in danger, before sprinting down the path until you emerge out into the open plains again.
~forkChoice = "light"
    ->END
+[Dark Path]
Nothing eventful happens despite the ominous appearance of the forest. However, you do get the sense here and there that something is following you.
~forkChoice = "dark"
    ->END
    
===TheStranger0===
#title:The Stranger
#time:day
#location:road
You're resting in a peaceful small town when you hear a loud bang right down the street. Still being on break, you try to shift your attention back to the drink in your hand. Your travels have been so hard after all. And unfortunately, it's not about to get easier. Your drink shatters into a million pieces when you hear another loud bang right next to your head.
"En garde, degenerate!" A crazy person shoves their face right up to yours. Blue hair fills your vision. You shove them back out of instinct, but they dash away to bother someone else before you get to curse them out.
->END

===TheChampionship0===
#title:The Championship?
#time:day
#location:market
As you browse the market of things you can't afford, a voice startles you. “Come on friend, buddy, bestie, $2 is insane!” The price tag says $100, so this guy seems to have wrangled a 98% discount. Being nosey, you head over. By the look of the man, it would’ve been easier for him to steal the food, but his negotiation skills are impressive. A tiny baby chick sits comfortably in the nook of his neck. He jumps when he sees you, scaring the bird. The necklace he wears is a magical one, and definitely powerful. Strange. “Pal! Help me out here?” Despite your empty pockets, his face still lights up. He rushes to pull out a crumpled flyer from his pocket and proudly displays it to you. It’s an ad for a tournament. The reward is $1 million— you almost faint at the sum. “You seem tough! This could help!” He beams. Seems like he’s forgotten about the stall. You snag the flyer and walk off. “Wha- my flyer! Where are you going? Can I come?” His voice fades into the distance as you drool over the reward. Still, your mood is somehow lightened. Continuing on...
->END

===MysteriousHole===
#title:Mysterious Hole
#time:day
#location:road
You come across a large hole in the middle of your path. It's deep enough that you can't tell exactly where the bottom is, even on a cloudless day. You remember hearing a trick about dropping a coin to determine how deep something is. Being broke, you find a nearby pebble and chuck it down...
After a long, long time of waiting for a sound from the bottom, you spot the same rock rapidly flying up directly towards you. 
+[Catch!]
Gain [Magnetic Pebble]: Usable in one encounter, deals 1 damage.
You skirt around the hole...
~gainItem("Magnetic Pebble")
->END

===Act1End===
#title:The End of Act I
Music blares, crowds roar. You seem to have come across a large event. In front of you sits a massive colosseum, it's a wonder how you missed that. You were probably too busy staring at the $1 million reward posted on the flyer for this tournament. This is your way in, the key. "You're here too!" A tall man towers behind you with a cheery smile. Your eye catches on his glowing necklace. You feel as if you recognize the necklace. And him too, but the necklace is more interesting. The small chick that sits on his shoulder chirps in recognition, it almost escaped your notice. Ah well, they must not be important if you forgot. The problem is that he seems to remember you. "We never exchanged names!” Thank the gods. “I'm Artho!” The bird, who has now moved to the top of his head, chirps in anger of being ignored. “-and this is Pip! It's a pleasure to see you again :)" Despite the registration being full, Artho somehow still manages to weasel you in. The man is kind to you, you probably saved him at one point or something. Fighting all these monsters, everything blurs together. He leads you into the colosseum, showing you around, but the only thing on your mind is the reward still echoing in your head. Don't lose your focus, heroes, you still have ways to go.
->END


===TavernIntro===
#title:The Tavern
#location:tavern

{
    - currentAct == 0:
    ->prologue
    - else:
    ->act1

}
=prologue
    It’s been a long day, you need a drink. Or something to entertain you. And the tavern never fails to provide. As you lean back on your chair, beckoning the barmaid to bring you your usual, you let your eyes scan over the rest of the patrons. Your fingers drum mindlessly on the table, halting as your gaze land on two men. There they were. You watch as they bicker over mind numbing topics, such as which pant leg should be worn first. You weren’t aware there was meant to be an order. When one of the men starts to raise his voice, the other defiantly follows. And as their words start getting more slurred, their movements more unsteady, and their voices more aggressive, it doesn’t take long before one tries to throw a punch, missing terribly. The other, in an attempt to dodge the punch that would’ve never hit him anyway, ends up tripping over his own feet. The rest of the tavern grows quiet, attention all focused on the two. You smile as you take a sip of your drink. Seems like the daily entertainment has begun.
    ->END
=act1
    It’s been a long day, you need a drink. Or a distraction. Anything to make you forget for a moment. And the tavern never fails to provide. As you lean back on your chair, beckoning the barmaid to bring you a drink, you let your eyes scan over the rest of the patrons. Your fingers drum mindlessly on the table, halting as your gaze lands on two men. There they were. You watch as they bicker over mind numbing topics, such as which pant leg should be worn first. You weren’t aware there was meant to be an order. When one of the men starts to raise his voice, the other defiantly follows. And as their words start getting more slurred, their movements more unsteady, and their voices more aggressive, it doesn’t take long before one tries to throw a punch, missing terribly. The other, in an attempt to dodge the punch that would’ve never hit him anyway, ends up tripping over his own feet. The rest of the tavern grows quiet, attention all focused on the two. You smile as you take a sip of your drink, worries momentarily forgotten. Seems like the daily entertainment has begun.
    ->END
===TavernRowdy===
#title:The Tavern
#location:tavern
The scene is as rowdy as usual; alcohol sloshing onto every surface, and each table louder than the next. Nothing eventful happens, but you make acquaintances with a few travelers.
->END

===TavernDrunk===
#title:A Drunk
#location:tavern

A drunken man stumbles around the room, bumping into each table before being shoved away. You watch from the corner of the tavern with great interest. 
Eventually, the man gets shoved to your table. He leans across; beer sloshes onto your finely woven shirt. 
"Hello, hello... and all that. Um... would you care to buy the poor fellow in front of you a drink?" he grins, teeth heavily stained.
+[Buy the drunk another drink]
You toss him a coin, and the drunk man grasps it tightly, "Oh thank you, thank you, may the gods bless you for the rest of your life!"
    ~affectWealth(-1)
    ->END
+[Refuse politely]
You politely refuse. For a moment, he stares at you with such intensity that you instinctively move your hand onto your weapon. But then just as fast, he smiles and wanders off to another table.
    ->END
+[Shove him to the next table]
You gently shove him like all the other patrons did before you. He shows little resistance before stumbling away.
    ->END
    
===TavernOther===
#title:Local Competition
#location:tavern
It's a slow day for the tavern today. Almost half of the tables are empty; and for the first time, the place has a manageable noise level. Surely there wasn't a ceremony today you forgot about, right?
You inquire about the lack of patrons with the barkeeper. 
She glares at you before realizing you're serious. "Another tavern's opened on the other side of town, right? Everybody and they mother's been clamoring to get in. Those fools. They don't know just how good they've got it here. Just you watch, they'll all be back in a few days."
->END

===TavernCloakedFigures===
#title:The Tavern
#location:tavern
You sit down near a window and gaze out at the silhouettes of the other buildings. You can't help but overhear the two cloaked figures behind you. 
"Have you told Colson about it yet?"
"Nah, I've been holding off... y'know how he is about justice and all that." 
"Ha...Just don't forget to remind him how important this is for us. I mean, we'll never have to do this again.  And we definitely won't have to stay in this dirty shack of a town no more!"
The two laugh. There's a brief silence before they begin speaking again, this time too quiet to be heard against the background of the tavern.
->END

===TavernFight===
#title:The Tavern
#location:tavern
You're calmly enjoying your drink when a stranger is thrown into your table, breaking it into countless different pieces. You look behind you and find the perpetrator: a drunken man barely able to stand on his own. The figure below you groans in pain and grabs at your leg for support.
Judging by the fact that the drunk man's gaze is solely focused on the patron sprawled out in front of you, it seems that your table was merely collateral damage.
+[Avoid the fight]
This conflict is none of your concern, you find a seat at another table and watch the two duke it out.
->END
+[Break up the fight]
Frustrated that your little moment of peace has been disturbed, you step between the two.
The man across from you finally acknowledges you. "Step aside nobleman, this got nothing to do with ya," he spits on the ground, "my buddy over there just needs a little lesson."
You remain still.
"Well, if you want me to go through ya, then so be it!"
[Start Combat]
->END

===TavernCelebration===
#title:The Tavern
#location:tavern
Out of all the times you've been to the tavern, you've never seen the place quite as hectic as now. You overhear from multiple patrons that the barkeeper is selling everything at half price today in order to celebrate getting her hands on some vintage ale.
You shove through a wall of inebriated townsfolks to ask about it yourself. The barkeeper shows you a bottle of golden liquid proudly, yet cautiously. The design on the container itself is incredibly intricate. If the liquid inside wasn't the cause of all the uproar today, you would've almost thought that the craftsmanship of the bottle was the prize.
{
    - currentAct == 0:
    ->prologue
    - else:
    ->act1
}
=prologue
    The barkeeper notices your eyes. "This stuffs the good stuff, been a commodity since the Warner brewery guild fell to ruins during the Rat Wars. Ages of history to it. And I got it for free, off of a bet last night! Tell you what, you ask your folks to lay off the taxes for me this season and I'll give you a little sample. That sound like a deal?"
    +[Promise that you'll throw in a good word for her]
    The barkeeper fills a small container with the golden ale and hands it to you. "Good doing business with you."
    ~gainItem("High Quality Ale")
    ->END
    +[Decline the offer]
    The integrity of the local rule is worth more than liquor. You turn her down and ask for the half priced stuff.
    ->END

=act1
    The barkeeper notices your eyes. "This stuffs the good stuff, been a commodity since the Warner brewery guild fell to ruins during the Rat Wars. Ages of history to it. And I got it for free, off of a bet last night!
    "You know what, as condolences for all the stuff that's happened recently and all that," she clears her through awkwardly. "have a shot on the house."
    The barkeeper fills a small container with the golden ale and hands it to you. "Don't have to drink it now, but hopefully it'll bring you some comfort."
    ~gainItem("High Quality Ale")
    ->END

===TavernMeal===
#title:The Tavern
#location:tavern
You decide to eavesdrop on the people around you while you slowly work through your meal. Behind you are a pair of travelers, speaking in an accent you don't quite recognize; and to your left are a group of merchants that you recognize from the marketplace. 

{
    - currentTime == "day":
    ->day
    - currentTime == "night":
    ->night
}
=day
+[Focus on the travelers] 
You spend most of your meal trying to decipher the two traveler's accents instead of gleaming any useful information. You eventually pick up a mention of a tournament happening somewhere right before the two leave.
->END
+[Focus on the merchants]
You try and pay careful attention to anything that could be of use. However, the merchants speak in technical jargon your entire meal, and the only thing you end up understanding is that trade has been bad recently.
->END
=night
+[Focus on the travelers] 
You spend most of the evening trying to decipher the two traveler's accents instead of gleaming any useful information. You eventually pick up a mention of a tournament happening somewhere right before the two leave.
->END
+[Focus on the merchants]
You try and pay careful attention to anything that could be of use. However, the merchants speak in technical jargon the entire night, and the only thing you end up understanding is that trade has been bad recently.
->END

===TavernContest===
#title:The Tavern
#location:tavern
Today is the tavern's monthly drinking contest! The spirits are high both figuratively and literally. The winner gets all their drinks for the night paid for, as well as a bottle of ale to take home! You've partaken a few times, but have never actually gotten past the third mug. For some reason, you feel optimistic about your chances today.
+[Give it a try]
You decide to give the contest another try.
You have no recollection of the rest of the night.
~affectWealth(-5)
->END
+[Watch from the side]
You join the large audience forming around the eight brave souls who decided to participate. The contest ends up going much more intense than you expected! And after watching a southerner chug his seventh mug in a row, you're glad that you didn't join in.
->END

===TavernRecipe===
#title:The Tavern
#location:tavern
Upon entering, you are greeted with the smell of burnt meat and wood.
It seems that the barkeeper is experimenting with new recipes.
->END

===TavernWindow===
#title:The Tavern
#location:tavern
You kick shards of glass away as you take the only remaining seat. The broken window behind you snuffs your candle out at every given opportunity, to the point where you feel bad asking the barmaid to relight it.
The setup doesn't make for a comfortable meal, but it still gets the job done.
->END

