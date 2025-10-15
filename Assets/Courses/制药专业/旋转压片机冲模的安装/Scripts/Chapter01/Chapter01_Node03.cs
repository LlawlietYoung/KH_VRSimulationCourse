using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter01_Node03 : CourseNodeController
{
    public LuosiGroup luosiGroup;
    public override void StartNode()
    {
        base.StartNode();
        luosiGroup.onfinish1 += (result, handle) =>
        {
            handlecontent.AppendLine(handle);
            Finish(result);
        };
        Prepared = true;
        this.Delay(2, () =>
        {
            luosiGroup.Ningjin();
        });
    }
}
