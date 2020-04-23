using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class VideoSliderControl : SliderControl
{
    public VideoPlayer videoPlayer;
    public static long FirstFrame = 6;

    public override void OnEndDrag(PointerEventData eventData)
    {
        try
        {
            StartCoroutine(UpdateVideo());
        }
        catch { }
    }

    public override void OnDrag(PointerEventData eventData)
    {
        videoPlayer.frame = (long)slider.value;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        try
        {
            StartCoroutine(UpdateVideo());
        }
        catch { }
    }

    private IEnumerator UpdateVideo()
    {
        isSliderControl = true;
        long frame = (long)slider.value;
        if (frame < FirstFrame)
        {
            frame = FirstFrame;
        }
        if (frame > (long)videoPlayer.frameCount)
        {
            frame = (long)videoPlayer.frameCount;
        }

        videoPlayer.frame = frame;
        while (videoPlayer.frame != frame)
        {
            yield return null;
        }
        isSliderControl = false;
    }
}

