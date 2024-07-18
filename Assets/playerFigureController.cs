using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static narrativeInkKnots;

public class playerFigureController : MonoBehaviour
{

    public landmarkController currentLandmark = null;
    public List<deckTags> currentExploreDecks = null;

    private void Update()
    {
        //whether or not the deck actually has cards is checked in exploreButton
        //This is so that "not being in contact with anything" is different from "everything in contact is empty"
        currentLandmark = setCurrentLandmark();
        currentExploreDecks = getCurrentExploreDecks();

    }

    public void moveTo(Vector3 destination)
    {
        transform.position = destination;
    }

    private landmarkController setCurrentLandmark()
    {
        Vector3 rayStartLocation = new Vector3(transform.position.x, 10f, transform.position.z);

        if (Physics.Raycast(rayStartLocation, Vector3.down, out RaycastHit hitCollider, 10f, LayerMask.GetMask("landmarks")))
        {
            return hitCollider.collider.GetComponent<landmarkController>();
        } else
        {
            return null;
        }
    }

    private List<deckTags> getCurrentExploreDecks()
    {
        Vector3 rayStartLocation = new Vector3(transform.position.x, 10f, transform.position.z);
        RaycastHit[] hitColliders = Physics.RaycastAll(rayStartLocation, Vector3.down, 10f, LayerMask.GetMask("exploreAreas"));

        List<deckTags> hitTags = new List<deckTags>();

        for (int i = 0; i < hitColliders.Length; i++)
        {
            deckTags[] areaDeckTags = hitColliders[i].collider.GetComponent<areaTag>().areaDeckTags;

            for (int j = 0; j < areaDeckTags.Length; j++)
            {
                //remove duplicate tags
                if (hitTags.Contains(areaDeckTags[j])) continue;

                hitTags.Add(areaDeckTags[j]);
            }
        }

        return hitTags;
    }
}
