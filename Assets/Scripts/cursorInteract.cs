using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorInteract : MonoBehaviour
{
    private Collider lastFrameCursorOver;
    private Collider currentCursorOver;
    private RaycastHit lastFrameHitData;
    private RaycastHit currentHitData;
    [SerializeField] Vector2 deckYSE;
    [SerializeField] Transform narrativeDisplayReference;
    [SerializeField] Transform narrativeCard;

    // Update is called once per frame
    void Update()
    {
        checkCursorPosition();
    }

    private void LateUpdate()
    {
        lastFrameCursorOver = currentCursorOver;
        lastFrameHitData = currentHitData;
    }

    private void checkCursorPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool hasHit = false;

        hasHit = Physics.Raycast(ray, out currentHitData);

        if (!hasHit)
        {
            currentCursorOver = null;
        } else if (currentHitData.collider.tag == null)
        {
            currentCursorOver = null;
        } else
        {
            currentCursorOver = currentHitData.collider;
        }

        if (currentCursorOver == lastFrameCursorOver) //CURSOR HOVER
        {
            cursorHover();

        }
        else //CURSOR CHANGE
        {
            cursorExit();
            cursorEnter();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            cursorClick();
        }
    }

    private void cursorEnter()
    {
        if (currentCursorOver == null) return;
        if (currentHitData.collider.tag == null) return;

        switch (currentHitData.collider.tag)
        {
            case "Deck":
                if (narrativeManager.instance.isCardDisplaying) return;
                raiseDeck();
                break;
        }
    }

    private void cursorExit()
    {
        if (lastFrameCursorOver == null) return;
        if (lastFrameHitData.collider.tag == null) return;

        switch (lastFrameHitData.collider.tag)
        {
            case "Deck":
                if (narrativeManager.instance.isCardDisplaying) return;
                lowerDeckExit();
                break;
        }
    }

    private void cursorHover()
    {
        if (currentCursorOver == null) return;
        if (currentHitData.collider.tag == null) return;

        switch (currentHitData.collider.tag)
        {
            default:
                break;
        }
    }

    private void cursorClick()
    {
        if (currentCursorOver == null) return;
        if (currentHitData.collider.tag == null) return;
        switch (currentHitData.collider.tag)
        {
            case "Deck":
                narrativeManager.instance.drawCard(currentHitData.collider.GetComponent<mapDeck>());
                lowerDeckClick();
                break;
        }
    }

    private void raiseDeck()
    {
        Transform deckTransform = currentHitData.collider.gameObject.transform;
        deckTransform.position = new Vector3(deckTransform.position.x, deckYSE.y, deckTransform.position.z);
    }

    private void lowerDeckExit()
    {
        Transform deckTransform = lastFrameHitData.collider.gameObject.transform;
        deckTransform.position = new Vector3(deckTransform.position.x, deckYSE.x, deckTransform.position.z);
    }

    private void lowerDeckClick()
    {
        Transform deckTransform = currentHitData.collider.gameObject.transform;
        deckTransform.position = new Vector3(deckTransform.position.x, deckYSE.x, deckTransform.position.z);
    }
}
