//using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public enum DebugType
{
    Normal,
    Warning,
    Error
}
//[TypeInfoBox("课程驱动器")]
public class CourseEngine : MonoBehaviour
{
    public static CourseEngine Instance { get; private set; }

    public CourseMainUICanvas mainUICanvas;
    public DebugUICanvas debugUICanvas;
    public CourseResultUICanvas resultUICanvas;
    public ExitCanvas exitCanvas;


    public HighlightManager highlightManager;

    //[ListDrawerSettings(ListElementLabelName = "Name")]
    public CourseModel model;

    public InputActionReference exitaction;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        InitEngine();
    }

    private void InitEngine()
    {
        switch (CourseManager.instance.currentMode)
        {
            case CourseMode.Demonstration:

                break;
            case CourseMode.Teaching:
            case CourseMode.Exercise:
            case CourseMode.Evaluating:
                StartCoroutine(CourseFlow());
                break;
            default:
                break;
        }
    }

    private IEnumerator CourseFlow()
    {
        int nodecount = 0;
        for (int i = 0; i < model.chapters.Count; i++)
        {
            nodecount += model.chapters[i].nodes.Count;
        }
        float stepscore = 100f / nodecount;
        //当课程开始时候调用一些准备工作
        model.OnCourseStart.Invoke();

        mainUICanvas.ShowContent(model.CourseName);

        //等待准备工作完成
        //yield return new WaitUntil(() => model.Prepared);
        yield return new WaitUntil(() => mainUICanvas.close);
        yield return new WaitForSeconds(0.5f);
        //遍历每个章节
        for (int i = 0; i < model.chapters.Count; i++)
        {
            CourseChapter chapter = model.chapters[i];
            mainUICanvas.ShowContent(chapter.ChapterTitle);
            //当本章节开始前做一些准备工作
            //chapter.OnChapterStart.Invoke();
            //章节控制器初始化
            chapter.controller.StartChapter();
            //等待准备工作完成
            yield return new WaitUntil(() => chapter.controller.Prepared);
            yield return new WaitUntil(() => mainUICanvas.close);
            yield return new WaitForSeconds(0.5f);
            //遍历本章节所有节点
            for (int j = 0; j < chapter.nodes.Count; j++)
            {
                CourseNode node = chapter.nodes[j];
                //本节点开始前做一些准备工作
                //node.OnNodeStart.Invoke();
                mainUICanvas.ShowContent(node.Content);
                //节点控制器初始化
                node.controller.StartNode();
                //等待准备工作完成
                yield return new WaitUntil(() => node.controller.Prepared);
                yield return new WaitUntil(() => mainUICanvas.close);
                yield return new WaitUntil(() => node.controller.Finished);
                node.result = node.controller.result;
                node.handlecontent = node.controller.handlecontent.ToString();
                node.score = node.controller.result ? stepscore : 0;
                //node.OnNodeFinish.Invoke();
                yield return new WaitForSeconds(1);
            }
            //chapter.OnChapterFinish.Invoke();
        }
        model.OnCourseFinish.Invoke();
        resultUICanvas.Open();
    }

    public void Debug(string message , DebugType debugType)
    {
        switch (debugType)
        {
            case DebugType.Normal:
                debugUICanvas.NormalInfo(message);
                break;
            case DebugType.Warning:
                debugUICanvas.WarningInfo(message);
                break;
            case DebugType.Error:
                debugUICanvas.ErrorInfo(message);
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        if(exitaction.action.IsPressed())
        {
            print("退出课程");
            exitCanvas.gameObject.SetActive(true);
        }
    }
}
