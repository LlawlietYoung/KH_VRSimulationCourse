using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Panel_Demonstration : PanelBase
{
    public Button btn_return;
    public ScrollContentPanel switchpanel;
    public Button btn_left, btn_right;
    public override void Init()
    {
        base.Init();
        btn_return.onClick.AddListener(() =>
        {
            Close();
            PanelManager.instance.OpenPanel<Panel_Home>();
        });
        btn_left.onClick.AddListener(() =>
        {
            switchpanel.Current--;
        });
        btn_right.onClick.AddListener(() =>
        {
            switchpanel.Current++;
        });
    }
    public override void OnOpen()
    {
        Debug.Log("打开演示模式");
        LoadPPT(CourseManager.instance.currentitem.pptpath);
        LoadVideos(CourseManager.instance.currentitem.videolist);
        Debug.Log("打开了演示模式");

    }
    public override void OnClose()
    {
        switchpanel.Clear();
    }

    private void LoadPPT(string path)
    {
        var currentcourse = CourseManager.instance.currentitem;
        Debug.Log(Path.Combine(Application.streamingAssetsPath, path));
        var presentation = new Aspose.Slides.Presentation(Path.Combine(Application.streamingAssetsPath, path));
        Debug.Log(presentation.Slides.Count);
        //遍历文档
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            byte[] bytes = Bitmap2Byte(presentation.Slides[i].GetThumbnail(1f, 1f));
            Texture2D texture2D = new Texture2D(1440, 810);
            texture2D.LoadImage(bytes);
            int a = i;
            switchpanel.Add(new Media()
            {
                type = FileType.Image,
                texture = texture2D,
                audioClip = currentcourse.audioClips[a]
            });
        }
    }
    private void LoadVideos(List<string> videos)
    {
        for (int i = 0; i < videos.Count; i++)
        {
            switchpanel.Add(new Media()
            {
                type = FileType.Video,
                filepath = videos[i]
            });
        }
    }
    public byte[] Bitmap2Byte(System.Drawing.Bitmap bitmap)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            bitmap.Save(stream, ImageFormat.Png);
            byte[] data = new byte[stream.Length];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(data, 0, Convert.ToInt32(stream.Length));
            return data;
        }
    }
}
