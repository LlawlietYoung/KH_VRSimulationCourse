using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter02_Node01 : CourseNodeController
{
    public ShangchongGroupController controller;
    public override void StartNode()
    {
        base.StartNode();
        controller.StartStep1();
        controller.onFinished01 += (r, c) =>
        {
            Debug.Log("上冲安装第一步结束");
            Appendhandle(c);
            Finish(r);
        };
        Prepared = true;
    }
}
