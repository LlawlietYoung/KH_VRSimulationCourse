using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chapter01_zhongmoanzhuang : CourseChapterControllerBase
{
    public GameObject shebei;
    public override void StartChapter()
    {
        base.StartChapter();
        shebei.SetActive(true);
        Prepared = true;
    }
}
