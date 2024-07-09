using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorManager : MonoBehaviour
{
    private static cursorManager instance;
    //===
    private clickable3dBehavior lastFrameCursorOver;
    private clickable3dBehavior currentCursorOver;
    private RaycastHit lastFrameHit;
    private RaycastHit currentHit;

    // Update is called once per frame
    void Update()
    {
        checkCursorPosition();
    }

    private void LateUpdate()
    {
        lastFrameCursorOver = currentCursorOver;
        lastFrameHit = currentHit;
    }

    private void checkCursorPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool hasHit = false;

        hasHit = Physics.Raycast(ray, out RaycastHit hitData);

        if (!hasHit)
        {
            currentCursorOver = null;
            currentHit = new RaycastHit();
        }
        else if (hitData.collider.GetComponent<clickable3dBehavior>() == null)
        {
            currentCursorOver = null;
            currentHit = new RaycastHit();
        }
        else
        {
            currentCursorOver = hitData.collider.GetComponent<clickable3dBehavior>();
            currentHit = hitData;
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
        currentCursorOver.onCursorEnter(currentHit);
    }

    private void cursorExit()
    {
        if (lastFrameCursorOver == null) return;
        lastFrameCursorOver.onCursorExit(lastFrameHit);
    }

    private void cursorHover()
    {
        if (currentCursorOver == null) return;
        currentCursorOver.onCursorHover(currentHit);
    }

    private void cursorClick()
    {
        if (currentCursorOver == null) return;
        currentCursorOver.onCursorClick(currentHit);
    }
}
