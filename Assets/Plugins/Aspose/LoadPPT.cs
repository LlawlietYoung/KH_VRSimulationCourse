using System;
using System.Drawing.Imaging;
using System.IO;
using UnityEngine;

public class LoadPPT : MonoBehaviour
{
    public Transform content;
    private void Start ()
    {
        string pptPath = Application.streamingAssetsPath + "/01旋转压片机冲模的安装/旋转式压片机的结构与原理课件PPT.pptx";
        Load(pptPath);
    }
    public void Load (string pptPath)
    {
        Debug.Log(pptPath);
        var presentation = new Aspose.Slides.Presentation(pptPath);
        //遍历文档
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            if (i < content.childCount)
            {
                var slide = presentation.Slides[i];
                var bitmap = slide.GetThumbnail(1f, 1f);
                byte[] bytes = Bitmap2Byte(bitmap);

                var showImage = content.GetChild(i).GetComponent<UnityEngine.UI.RawImage>();
                int width = 960, height = 540;
                Texture2D texture2D = new Texture2D(width, height);
                texture2D.LoadImage(bytes);
                //Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, width, height), Vector2.zero);
                showImage.texture = texture2D;
            }
        }
    }
    public byte[] Bitmap2Byte (System.Drawing.Bitmap bitmap)
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
