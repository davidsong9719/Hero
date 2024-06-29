using Ink;
using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static cardButton;
using static playerManager;

public class narrativeInkKnots : MonoBehaviour
{
    private static narrativeInkKnots instance;
    [SerializeField] TextAsset cardTextAsset;
    private string currentKnot;
    private Story cardText;

    private Dictionary<string, Dictionary<string, string>> knotTags = new Dictionary<string, Dictionary<string, string>>();
    [Header("Card Decks")]
    public List<string> allCards;
    public List<string> roadCards, marketCards, forestCards;
    public List<string> completedCards;

    public enum deckTags
    {
        road,
        market,
        forest,
    }

    public enum breakFunctions
    {
        none,
        fight
    }
    public struct textInfo
    {
        public string title;
        public string text;
        public List<Choice> choices;
        public buttonFunction buttonFunction;
        public string nextCard;
        public breakFunctions breakFunction; 

        public textInfo(string textString, List<Choice> choiceList, string titleText, buttonFunction cardbuttonFunction, string nextKnot, breakFunctions breakFunctionInfo)
        {
            title = titleText;
            text = textString;
            choices = choiceList;
            buttonFunction = cardbuttonFunction;
            nextCard = nextKnot;
            breakFunction = breakFunctionInfo;
        }
    }

    public static narrativeInkKnots getInstance()
    {
        return instance;
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
        cardText = new Story(cardTextAsset.text);

        linkExternalFunctions();
        checkForUnincludedKnots();

        parseKnots();
    }

    private void Start()
    {
        
    }

    private void linkExternalFunctions()
    {
        cardText.BindExternalFunction("affectHealth", (int amount) => playerManager.getInstance().influenceHealth(amount));
        cardText.BindExternalFunction("gainItem", (string itemName) => playerManager.getInstance().gainItem(itemName));
        cardText.BindExternalFunction("loseCardChoice", (int amount) => playerManager.getInstance().loseCardChoice(amount));
    }

    private void parseKnots()
    {
        //Parses through every knot in the index and records their location and tags

        cardText.ChoosePathString("INDEX");

        while (cardText.canContinue)
        {
            string currentKnot = cardText.Continue();
            currentKnot = currentKnot.Replace("\n", "");

            //Parse Tags
            Dictionary<string, string> currentKnotTags = parseTags(cardText.TagsForContentAtPath(currentKnot));

            knotTags.Add(currentKnot,currentKnotTags);
            sortKnotToLocation(currentKnot, currentKnotTags["location"]);
        }

        randomizeDeckOrder();
    }

    private void checkForUnincludedKnots()
    {
        List<string> indexKnots = new List<string>();
        cardText.ChoosePathString("INDEX");

        while (cardText.canContinue)
        {
            indexKnots.Add(cardText.Continue().Replace("\n", ""));
        }

        foreach(string knot in cardText.mainContentContainer.namedOnlyContent.Keys)
        {
            if (!indexKnots.Contains(knot))
            {
                if (knot == "INDEX") continue;
                print(knot + " is not included in the index, is this intentional?");
            }
        }
    }

    private void randomizeDeckOrder()
    {
        //the current approach of randomizing the deck will most likely cause a significant backlog of inaccessible cards locked behind prerequisite cards
        //might cause events to start and end in a row near the end of the game

        roadCards = miscFunctions.randomizeList(roadCards);
        marketCards = miscFunctions.randomizeList(marketCards);
    }

    private void sortKnotToLocation(string knot, string locations)
    {
        string[] splitLocations = locations.Replace(" ", "").Split(",");

        allCards.Add(knot);

        for (int i = 0; i < splitLocations.Length; i++)
        {
            
            switch (splitLocations[i])
            {
                case "road":
                    roadCards.Add(knot);
                    break;

                case "market":
                    marketCards.Add(knot);
                    break;

                case "forest":
                    forestCards.Add(knot);
                    break;

                case "any":
                    roadCards.Add(knot);
                    marketCards.Add(knot);
                    forestCards.Add(knot);
                    break;

                default:
                    Debug.LogWarning(knot + " most likely has a misspelled location");
                    break;
            }
        }
    }

    private Dictionary <string, string> parseTags(List<string> tags)
    {
        Dictionary<string, string> tagDictionary = new Dictionary<string, string>();

        for (int i = 0; i < tags.Count; i++)
        {
            string[] tagInfoPair = tags[i].Split(":");
            tagDictionary.Add(tagInfoPair[0], tagInfoPair[1]); //0 is the tag category (location), 1 is the tag information (market)
        }

        return tagDictionary;
    }

    public textInfo drawCard(deckTags deckTag)
    {
        currentKnot = getAvailableCards(deckTag)[0];
        cardText.ChoosePathString(currentKnot);

        return continueText();
    }

    public textInfo drawCard(string nextCard) //for use with next card
    { 
        cardText.ChoosePathString(nextCard);

        //throw warning if nextCard can be accessed regularly by pulling from a deck
        if (allCards.Contains(nextCard)) Debug.LogWarning(nextCard + " can be accessed from both INDEX and the nextCard function, is this intentional?");

        return continueText();
    }

    private textInfo continueText()
    {
        string text = "";
        breakFunctions breakFunction = breakFunctions.none;
        buttonFunction currentButtonFunction = buttonFunction.none;
        string nextKnot = null;

        while (true)
        {
            string lineString = "   " + cardText.Continue();

            bool doesBreakFunctionExist = parseBreakFunctions(out breakFunction);


            if (doesBreakFunctionExist) break; // break early to not include breakText

            text += lineString;
            if (!cardText.canContinue) break;
        }

        if (breakFunction == breakFunctions.fight)
        {
            currentButtonFunction = buttonFunction.enterCombat;
        } else
        {
            getCurrentButtonFunction(out nextKnot);
        }
        
        
        return new textInfo(text, cardText.currentChoices, knotTags[currentKnot]["title"], currentButtonFunction, nextKnot, breakFunction);
    }

    private bool parseBreakFunctions(out breakFunctions breakFunction)
    {
        bool breakFunctionExist = cardText.currentText.Contains("(BREAK)");
        breakFunction = breakFunctions.none;

        if (!breakFunctionExist) return false;

        string[] functionText = cardText.currentText.Replace("(BREAK)", "").Split(":");
        bool breakFunctionValid = Enum.TryParse(functionText[0], out breakFunction);

        if (!breakFunctionValid)
        {
            print(currentKnot + " Break Invalid");
            return false;
        }

        switch(breakFunction)
        {
            case breakFunctions.fight:
                combatManager.getInstance().setNextEnemyInfo(functionText[1]);
                break;
        }
            
        return true;
    }

    private buttonFunction getCurrentButtonFunction(out string nextCard)
    {
        Dictionary<string, string> currentTags = parseTags(cardText.currentTags);
        buttonFunction function = buttonFunction.none;
        nextCard = null;

        if (!currentTags.ContainsKey("exitFunction")) return function;

        //
        if (currentTags["exitFunction"] == "none")
        {
            function = buttonFunction.none;
        } else if (currentTags["exitFunction"] == "store")
        {
            function = buttonFunction.store;
        } else if (currentTags["exitFunction"].Split(">>>")[0] == "nextCard")
        {
            nextCard = currentTags["exitFunction"].Split(">>>")[1];
            function = buttonFunction.nextCard;
        }

        return function;
    }

    private List<string> getAvailableCards(deckTags deckTag)
    {
        List<string> deckCards = getDeckCards(deckTag);
        List<string> availableCards = new List<string>();

        for (int i = 0; i < deckCards.Count; i++)
        {
            if (completedCards.Contains(deckCards[i])) continue;
            //if prerequisite has not been met  continue;

            availableCards.Add(deckCards[i]);
        }

        return availableCards;

    }
    private List<string> getDeckCards(deckTags deckTag)
    {
        switch (deckTag)
        {
            case deckTags.road:
                return roadCards;

            case deckTags.market:
                return marketCards;

            case deckTags.forest:
                return forestCards;

        }

        Debug.LogError("deckTag does not have a corresponding card list");
        return null;
    }

    public textInfo chooseChoice(Choice choice)
    {
        cardText.ChooseChoiceIndex(choice.index);

        return continueText();
    }

    public void storeCard()
    {
        completedCards.Add(currentKnot);
    }

    public int getAvailableCardAmount(deckTags deckTag)
    {
        return getAvailableCards(deckTag).Count;
    }
    
}
