using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapInteract : clickable3dBehavior
{
    [SerializeField] GameObject targetDisplay;

    public override void onCursorEnter(RaycastHit rayInfo)
    {
        targetDisplay.SetActive(true);
        moveTargetDisplay(rayInfo.point);
    }
    public override void onCursorExit(RaycastHit rayInfo)
    {
        targetDisplay.SetActive(false);
    }

    public override void onCursorHover(RaycastHit rayInfo)
    {
        moveTargetDisplay(rayInfo.point);
    }

    private void moveTargetDisplay(Vector3 displayPosition)
    {
        targetDisplay.transform.position = displayPosition;
    }
}
