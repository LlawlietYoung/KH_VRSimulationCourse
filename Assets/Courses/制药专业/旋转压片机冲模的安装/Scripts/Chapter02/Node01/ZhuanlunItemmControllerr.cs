using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ZhuanlunItemmControllerr : MonoBehaviour
{
    //判断是否是左手操作
    [HideInInspector]
    public bool islefthandle = false;

    public void OnGrabbed(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.GetComponentInParent<ActionBasedController>() && args.interactorObject.transform.GetComponentInParent<ActionBasedController>().modelParent.name.Contains("Left"))
        {
            islefthandle = true;
        }
        else
        {
            islefthandle = false;
        }
    }
}
