using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter01_Node02 : CourseNodeController
{
    public Zhongmu zhongmu;
    public override void StartNode()
    {
        base.StartNode();
        zhongmu.onfinshed += (result, handle) =>
        {
            handlecontent.AppendLine(handle);
            Finish(result);
        };
        zhongmu.gameObject.SetActive(true);
        zhongmu.StartStep();
        Prepared = true;
    }
}
