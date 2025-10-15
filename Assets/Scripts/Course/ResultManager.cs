using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CourseResult
{
    public List<ChapterResult> chapters = new List<ChapterResult>();
}
public class ChapterResult
{
    public string title;
    public List<NodeResult> nodes = new List<NodeResult>();
}
public class NodeResult
{
    public string title;
    public string content;
    public bool result = false;
    public float score = 0;
}

public class ResultManager : MonoBehaviour
{
    public CourseResult courseResult;

    public void Init()
    {
        courseResult = new CourseResult();
        for (int i = 0; i < CourseEngine.Instance.model.chapters.Count; i++)
        {
            CourseChapter chapter = CourseEngine.Instance.model.chapters[i];
            ChapterResult chapterResult = new ChapterResult();
            chapterResult.title = (i+1) + " " + chapter.ChapterTitle;
            courseResult.chapters.Add(chapterResult);

            for (int j = 0; j < chapter.nodes.Count; j++)
            {
                NodeResult nodeResult = new NodeResult();
                nodeResult.title = (i + 1) + "." + (j + 1) + " " + chapter.nodes[j].Content;
                chapterResult.nodes.Add(nodeResult);
            }
        }
    }
}
