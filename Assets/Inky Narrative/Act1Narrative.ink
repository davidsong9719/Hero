INCLUDE globalNarrativeToolkit.ink
->DozedOff

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
//any
NiceDay
Slimed
Trip
Ants
Overslept
Stargaze
DozedOff
//forest
Scared
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
#location:any
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
    
(BREAK)fight:Random:Random

You, proud and victorious, walk off prepared to face anything...
\+ego
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