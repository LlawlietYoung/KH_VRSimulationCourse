using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter01_Node01 : CourseNodeController
{
    public LuosiGroup LuosiGroup;

    public override void StartNode()
    {
        base.StartNode();
        LuosiGroup.onfinish += (result, handle) =>
        {
            handlecontent.AppendLine(handle);
            Finish(result);
        };
        Prepared = LuosiGroup.StartStep();
    }
}
