using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorManager : MonoBehaviour
{
    private static cursorManager instance;
    //===
    private clickable3dBehavior lastFrameCursorOver;
    private clickable3dBehavior currentCursorOver;

    // Update is called once per frame
    void Update()
    {
        checkCursorPosition();
    }

    private void LateUpdate()
    {
        lastFrameCursorOver = currentCursorOver;
    }

    private void checkCursorPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;
        bool hasHit = false;

        hasHit = Physics.Raycast(ray, out hitData);

        if (!hasHit)
        {
            currentCursorOver = null;
        }
        else if (hitData.collider.GetComponent<clickable3dBehavior>() == null)
        {
            currentCursorOver = null;
        }
        else
        {
            currentCursorOver = hitData.collider.GetComponent<clickable3dBehavior>();
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
        currentCursorOver.onCursorEnter();
    }

    private void cursorExit()
    {
        if (lastFrameCursorOver == null) return;
        lastFrameCursorOver.onCursorExit();
    }

    private void cursorHover()
    {
        if (currentCursorOver == null) return;
        currentCursorOver.onCursorHover();
    }

    private void cursorClick()
    {
        if (currentCursorOver == null) return;
        currentCursorOver.onCursorClick();
    }
}
