using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class SelectVideoPage : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Slider videoSlider;
    public VideoSliderControl videoSliderControl;
    public Text currentVideoTime;
    public Text totalVideoTime;

    public string filename;

    private void LateUpdate()
    {
        SyncSliderAndTime();
    }

    private void Start() {
        StartCoroutine(InitVideoPlayer());
    }

    public IEnumerator InitVideoPlayer()
    {
        while (!videoPlayer.isActiveAndEnabled)
        {
            yield return null;
        }

        videoPlayer.url = "file://" + filename;
        videoPlayer.Prepare();
        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }
        videoPlayer.Play();
        yield return null;
        videoPlayer.Pause();

        videoSlider.value = 0f;
        videoSlider.maxValue = videoPlayer.frameCount;
        totalVideoTime.text = $"{(int)Frame2Time((long)videoSlider.maxValue) / 60:D2}:{(int)Frame2Time((long)videoSlider.maxValue) % 60:D2}";
        currentVideoTime.text = "00:00";
    }

    private void SyncSliderAndTime()
    {
        if (!videoSliderControl.isSliderControl)
        {
            videoSlider.value = videoPlayer.frame;
        }

        currentVideoTime.text = $"{(int)Frame2Time((long)videoSlider.value) / 60:D2}:{(int)Frame2Time((long)videoSlider.value) % 60:D2}";
    }

    private IEnumerator SetVideo0()
    {
        videoPlayer.Pause();
        videoSliderControl.isSliderControl = true;
        videoPlayer.frame = VideoSliderControl.FirstFrame;
        videoSlider.value = VideoSliderControl.FirstFrame;
        while (videoPlayer.frame != VideoSliderControl.FirstFrame)
        {
            yield return null;
        }
        videoSliderControl.isSliderControl = false;
    }

    public float Frame2Time(long frame)
    {
        return frame / videoPlayer.frameRate;
    }
}
