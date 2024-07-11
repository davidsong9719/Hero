using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class clickable3dBehavior : MonoBehaviour
{
    protected virtual void Awake()
    {
        gameObject.layer = LayerMask.NameToLayer("clickable3d");
    }
    public virtual void onCursorClick(RaycastHit rayInfo)
    {

    }
    public virtual void onCursorEnter(RaycastHit rayInfo)
    {

    }
    public virtual void onCursorExit(RaycastHit rayInfo)
    {

    }
    public virtual void onCursorHover(RaycastHit rayInfo)
    {

    }
}
