using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapInteract : clickable3dBehavior
{
    [SerializeField] GameObject targetDisplay;
    [SerializeField] playerFigureController playerController;

    public override void onCursorEnter(RaycastHit rayInfo)
    {
        if (!mapManager.getInstance().isMapInteractable) return;

        targetDisplay.SetActive(true);
        moveTargetDisplay(rayInfo.point);
    }
    public override void onCursorExit(RaycastHit rayInfo)
    {
        if (!mapManager.getInstance().isMapInteractable) return;
        targetDisplay.SetActive(false);
    }

    public override void onCursorHover(RaycastHit rayInfo)
    {
        if (!mapManager.getInstance().isMapInteractable) return;

        targetDisplay.SetActive(true);
        moveTargetDisplay(rayInfo.point);
    }

    private void moveTargetDisplay(Vector3 displayPosition)
    {
        targetDisplay.transform.position = displayPosition;
    }

    public override void onCursorClick(RaycastHit rayInfo)
    {
        if (!mapManager.getInstance().isMapInteractable) return;

        playerController.moveTo(targetDisplay.transform.position);
    }
}
