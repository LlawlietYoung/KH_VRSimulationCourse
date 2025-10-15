using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CourseListObj", menuName = "ScriptableObjects/CourseListObj", order = 1)]
public class CourseListObj : ScriptableObject
{
    [SerializeField]
    public List<MajorItem> majorItems = new List<MajorItem>();
}
