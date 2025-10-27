using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter02_Node02 : CourseNodeController
{
    public ShangchongGroupController shanghcong;
    public override void StartNode()
    {
        base.StartNode();

        shanghcong.StartStep2();

        shanghcong.onFinished02 += (r, c) =>
        {
            Appendhandle(c);
            Finish(r);
        };
    }
}
