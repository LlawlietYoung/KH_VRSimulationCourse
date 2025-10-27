using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShangchongItemController : MonoBehaviour
{
    [SerializeField]
    private float miny, maxy;

    [SerializeField]
    private float correctminlimity, correctmaxlimity;
    // Start is called before the first frame update
    public bool CorrectPosition => transform.localPosition.y < correctmaxlimity && transform.localPosition.y > correctminlimity;
    //判断是否是左手操作
    [HideInInspector]
    public bool islefthandle = false;
    public bool Grabbed { get; set; }
    public string Result => islefthandle ? "最后为左手操作；" : "最后为右手操作；" + (CorrectPosition ? "放置到了正确的位置" : "没放置到正确位置");

    void Start()
    {
        
    }
    public void OnGrabbed(SelectEnterEventArgs args)
    {
        Debug.Log(args.interactorObject.transform.name);
        Debug.Log(args.interactorObject.transform.GetComponentInParent<ActionBasedController>().modelParent.name);
        if(args.interactorObject.transform.GetComponentInParent<ActionBasedController>() && args.interactorObject.transform.GetComponentInParent<ActionBasedController>().modelParent.name.Contains("Left"))
        {
            islefthandle = true;
        }
        else
        {
            islefthandle= false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Grabbed)
        {
            if (transform.localPosition.y < miny)
            {
                Vector3 vector3 = transform.localPosition;
                vector3.y = miny;
                transform.localPosition = vector3;
            }
            if (transform.localPosition.y > maxy)
            {
                Vector3 vector3 = transform.localPosition;
                vector3.y = maxy;
                transform.localPosition = vector3;
            }
        }

    }
}
