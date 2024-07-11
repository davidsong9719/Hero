using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static narrativeInkKnots;

public class playerFigureController : MonoBehaviour
{
    public void moveTo(Vector3 destination)
    {
        transform.position = destination;
    }

    public List<deckTags> getCurrentExploreDecks()
    {
        Vector3 rayStartLocation = new Vector3(transform.position.x, 10f, transform.position.z);
        RaycastHit[] hitColliders = Physics.RaycastAll(rayStartLocation, Vector3.down, 10f, LayerMask.GetMask("exploreAreas"));

        List<deckTags> hitTags = new List<deckTags>();

        for (int i = 0; i < hitColliders.Length; i++)
        {
            deckTags[] areaDeckTags = hitColliders[i].collider.GetComponent<areaTag>().areaDeckTags;

            for (int j = 0; j < areaDeckTags.Length; j++)
            {
                if (hitTags.Contains(areaDeckTags[j])) continue;

                hitTags.Add(areaDeckTags[j]);
            }
        }

        return hitTags;
    }
}
