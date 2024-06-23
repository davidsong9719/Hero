using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class imageButton : MonoBehaviour
{
    //attack to choice text gameObject;

    public Action buttonFunction;
    private bool isDeactivated = true;

    private void Awake()
    {
    }

    private void Start()
    {
        dehighlight();
    }

    public void highlight()
    {
        if (isDeactivated) return;
    }

    public void dehighlight()
    {
        if (isDeactivated) return;
    }

    public void select()
    {
        if (isDeactivated) return;

        dehighlight();
    }

    public void deactivate()
    {
        isDeactivated = true;
    }

    public void activate()
    {
        isDeactivated = false;
    }
}
