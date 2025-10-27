using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CourseResultUICanvas : MonoBehaviour
{
    public ChapterTitleItem chapterTitleItem;
    public NodeContentItem nodecontentItem;
    public Transform content;

    public Button btn_confirm;
    public void Open()
    {
        gameObject.SetActive(true);
        //打开结果面板
        for (int i = 0; i < CourseEngine.Instance.model.chapters.Count; i++)
        {
            CourseChapter chapter = CourseEngine.Instance.model.chapters[i];
            ChapterTitleItem chapteritem = Instantiate(chapterTitleItem, content);
            chapteritem.title = (i + 1) + " " + chapter.ChapterTitle;
            for (int j = 0; j < chapter.nodes.Count; j++)
            {
                NodeContentItem nodeitem = Instantiate(nodecontentItem, content);
                nodeitem.title = (i + 1) + "," + (j + 1) + " " + chapter.nodes[j].Content;
                if(chapter.nodes[j].controller.NeedGrade)
                {
                    nodeitem.SetScore(chapter.nodes[j].score, chapter.nodes[j].result);
                    nodeitem.content = chapter.nodes[j].handlecontent;
                }
            }
        }
        btn_confirm.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Main");
        });
        GetComponent<CanvasGroup>().DOFade(1, 0.3f);

    }
}
