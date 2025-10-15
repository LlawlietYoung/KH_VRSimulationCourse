using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum CourseMode
{
    Demonstration,
    Teaching,
    Exercise,
    Evaluating
}
public class CourseManager : MonoBehaviour
{
    public static CourseManager instance {  get; private set; }

    public CourseListObj courses;
    public int currentmajorid = 0;
    public int currentcourseid = 0;
    [HideInInspector]
    public CourseItem currentitem
    {
        get
        {
            if (courses.majorItems[currentmajorid].courseItems.Count == 0) return null;
            return courses.majorItems[currentmajorid].courseItems[currentcourseid];
        }
    }
    public MajorItem currentMajor => courses.majorItems[currentmajorid];
    public CourseMode currentMode = CourseMode.Teaching;
    private void Awake()
    {
        instance = this;
    }
    public void OpenCourse(int courseId)
    {
        currentcourseid = courseId;
        SceneManager.LoadScene(currentitem.SceneName);
    }
}
