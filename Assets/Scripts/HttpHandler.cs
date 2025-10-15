using BestHTTP;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
public class ResponData
{
    public int Code {  get; set; }
    public string Message { get; set; }
    public Data Data { get; set; }
}
public class Data
{
    public List<CourseItem> courseLists { get; set; }
}
[Serializable]
public class MajorItem
{
    public string majorName;
    public List<CourseItem> courseItems = new List<CourseItem>();
}
[Serializable]
public class CourseItem
{
    public string ID;
    public string Name;
    public string SceneName;
    public Sprite sp_icon;
    //相对StreamingAssets文件夹的路径
    public string pptpath;
    public List<AudioClip> audioClips = new List<AudioClip>();
    public List<string> videolist = new List<string>();
}
public enum MajorType
{
    NewEnergyAutomobile = 1,
    PharmaceuticalMajor
}
public static class HttpHandler
{
    private static string adominurl = "https:kh.vr.com";
    private const string api_getcourselist = "api/getcourselist";
    private const string api_uploadgrade = "api/uploadgrade";
    public static void GetCourseList(string studentid,Action<bool,List<CourseItem>> onResult)
    {
        string url = Path.Combine(adominurl,api_getcourselist);
        HTTPRequest request = new HTTPRequest(new Uri(url),HTTPMethods.Get,(_req,_res)=>
        {
            if(_res.IsSuccess)
            {
                try
                {
                    ResponData responData = JsonConvert.DeserializeObject<ResponData>(_res.DataAsText);
                    if(responData.Code == 0)
                    {
                        onResult?.Invoke(true, responData.Data.courseLists);
                    }
                    else
                    {
                        onResult?.Invoke(false, null);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                    onResult?.Invoke(false, null);
                }
            }
            else onResult?.Invoke(false, null);
        });
        request.AddField("StudentID", studentid);
        request.Send();
    }

    public static void UploadGrade(string studentid,Action<bool> onResult)
    {
        string url = Path.Combine(adominurl,api_uploadgrade);
        HTTPRequest request = new HTTPRequest(new Uri(url), HTTPMethods.Post, (_req, _res) =>
        {
            if (_res.IsSuccess)
            {
                try
                {
                    ResponData data = JsonConvert.DeserializeObject<ResponData>(_res.DataAsText);
                    onResult?.Invoke(data.Code == 0);
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                    onResult?.Invoke(false);
                }
            }
            else
            {
                onResult?.Invoke(false);
            }
        });
        request.AddField("StudentID", studentid);
        request.Send();
    }
}
