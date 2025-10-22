using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter02_Node01 : CourseNodeController
{
    public ShangchongGroupController controller;
    public override void StartNode()
    {
        base.StartNode();
        controller.onFinished += (r, c) =>
        {
            Appendhandle(c);
            Finish(r);
        };
    }
}
