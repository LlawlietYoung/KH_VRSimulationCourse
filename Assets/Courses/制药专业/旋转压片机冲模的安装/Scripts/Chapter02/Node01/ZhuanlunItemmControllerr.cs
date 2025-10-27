using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ZhuanlunItemmControllerr : MonoBehaviour
{
    //判断是否是左手操作
    [HideInInspector]
    public bool isrighthandle = false;

    public Action<float> OnRotate;

    public GameObject HandlePanelPoint_step02_shoulunhandle;
    public ActionBasedSnapTurnProvider actionBasedSnapTurnProvider;

    //摇杆动作
    public InputActionReference HandlerAction;

    private bool canrotate = false;

    private void Update()
    {
        if(canrotate)
        {
            Vector2 axies = HandlerAction.action.ReadValue<Vector2>();
            OnRotate?.Invoke(axies.x);
            transform.Rotate(new Vector3(0, 0, axies.x * -20f));
        }
    }
    public void OnFirstSelected()
    {
        if(CourseManager.instance != null && CourseManager.instance.currentMode != CourseMode.Evaluating)
        {
            HandlePanelPoint_step02_shoulunhandle.SetActive(true);
            actionBasedSnapTurnProvider.enableTurnAround = false;
            actionBasedSnapTurnProvider.enableTurnLeftRight = false;
        }
    }

    public void OnGrabbed(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.GetComponentInParent<ActionBasedController>() && args.interactorObject.transform.GetComponentInParent<ActionBasedController>().modelParent.name.Contains("Right"))
        {
            isrighthandle = true;
        }
        else
        {
            isrighthandle = false;
        }
    }
    public void OnLoseGrabbed(SelectExitEventArgs args)
    {

    }
}
