using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum FileType
{
    Unknown,
    Video,
    Image
}
public class Media
{
    public FileType type { get; set; }
    public string filepath { get; set; }
    public Texture2D texture { get; set; }
    public AudioClip audioClip { get; set; }
}
public class ScrollContentPanel : MonoBehaviour
{
    public RoleCardMediaplayer roleitemprefab;
    private List<RoleCardMediaplayer> _images = new List<RoleCardMediaplayer>();
    [HideInInspector]
    public float switch_time = 0.5f;

    private int current = 0;
    public int Current
    {
        get { return current; }
        set
        {
            Debug.Log(value);
            Debug.Log(current);
            if (current == value) return;
            //if (current == 0 || current == _images.Count - 1) return;
            Debug.Log(111111);
            if (value > current && current != _images.Count - 1)
            {
                _images[current].GetComponent<CanvasGroup>().DOFade(0, switch_time);
                _images[current].GetComponent< RectTransform>().DOScale(Vector2.one / 2f, switch_time);
                _images[current].GetComponent<RectTransform>().DOLocalMoveX(-_images[current].GetComponent<RectTransform>().sizeDelta.x, switch_time);
                if (_images[current].display.NoDefaultDisplay == true) _images[current].display.Player.Rewind(true);
                else
                {
                    if (_images[current].audioSource.clip != null) _images[current].audioSource.Stop();
                }
                current = value;
                _images[current].GetComponent<RectTransform>().localPosition = new Vector3(_images[current].GetComponent<RectTransform>().sizeDelta.x, _images[current].GetComponent<RectTransform>().localPosition.y);
                _images[current].GetComponent<RectTransform>().DOLocalMoveX(0, switch_time);
                _images[current].GetComponent<CanvasGroup>().DOFade(1, switch_time);
                _images[current].GetComponent<RectTransform>().DOScale(Vector2.one, switch_time);
                if (_images[current].display.NoDefaultDisplay == true) _images[current].display.Player.Play();
                else
                {
                    if(_images[current].audioSource.clip != null) _images[current].audioSource.Play();
                }
            }
            else if (value < current && current != 0)
            {
                _images[current].GetComponent<CanvasGroup>().DOFade(0, switch_time);
                _images[current].GetComponent<RectTransform>().DOScale(Vector2.one / 2f, switch_time);
                _images[current].GetComponent<RectTransform>().DOLocalMoveX(_images[current].GetComponent<RectTransform>().sizeDelta.x, switch_time);
                if (_images[current].display.NoDefaultDisplay == true) _images[current].display.Player.Rewind(true);
                else
                {
                    if (_images[current].audioSource.clip != null) _images[current].audioSource.Stop();
                }
                current = value;
                _images[current].GetComponent<RectTransform>().localPosition = new Vector3(-_images[current].GetComponent<RectTransform>().sizeDelta.x, _images[current].GetComponent<RectTransform>().localPosition.y);
                _images[current].GetComponent<RectTransform>().DOLocalMoveX(0, switch_time);
                _images[current].GetComponent<CanvasGroup>().DOFade(1, switch_time);
                _images[current].GetComponent<RectTransform>().DOScale(Vector2.one, switch_time);
                if (_images[current].display.NoDefaultDisplay == true) _images[current].display.Player.Play();
                else
                {
                    if (_images[current].audioSource.clip != null) _images[current].audioSource.Play();
                }
            }
        }
    }
    private float timer = 0;
    public void Add(Media media)
    {
        RoleCardMediaplayer roleCardMediaplayer = Instantiate(roleitemprefab, transform);
        _images.Add(roleCardMediaplayer);
        if(_images.Count > 1)
        {
            roleCardMediaplayer.GetComponent<CanvasGroup>().alpha = 0;
            roleCardMediaplayer.GetComponent<RectTransform>().localScale = Vector3.one / 2f;
        }
        switch (media.type)
        {
            case FileType.Unknown:
                break;
            case FileType.Video:
                roleCardMediaplayer.display.NoDefaultDisplay = true;
                roleCardMediaplayer.display.Player.OpenMedia(RenderHeads.Media.AVProVideo.MediaPathType.RelativeToStreamingAssetsFolder, media.filepath, _images.Count == 1);
                break;
            case FileType.Image:
                roleCardMediaplayer.display.NoDefaultDisplay = false;
                roleCardMediaplayer.display.DefaultTexture = media.texture;
                if(media.audioClip != null)
                {
                    roleCardMediaplayer.audioSource.clip = media.audioClip;
                }
                break;
            default:
                break;
        }
    }
    public void Clear()
    {
        foreach (var item in _images)
        {
            Destroy(item.gameObject);
        }
        _images.Clear();
        current = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Current++;
            timer = 0;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Current--;
            timer = 0;
        }
    }
}
