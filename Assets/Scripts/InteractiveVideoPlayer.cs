using UnityEngine;

public class InteractiveVideoPlayer : MonoBehaviour
{

    public GameObject videoObject;
    public GameObject sceneObject;
    public string videoName = "";
    public bool isLooping = false;
    public UnityEngine.Video.VideoAspectRatio videoAspectRatio;
    public UnityEngine.Video.VideoRenderMode videoRenderMode;
    public RenderTexture renderTexture;

    private UnityEngine.Video.VideoPlayer videoPlayer;

    private void Start()
    {
        PlayVideo();
    }

    private void PlayVideo()
    {
        // base path for all videos
        string path = Application.dataPath + "/../" + "Videos/";

        // VideoPlayer automatically targets the camera backplane when it is added
        // to a camera object, no need to change videoPlayer.targetCamera.
        videoPlayer = videoObject.AddComponent<UnityEngine.Video.VideoPlayer>();

        // Play on awake defaults to true. Set it to false to avoid the url set
        // below to auto-start playback since we're in Start().
        videoPlayer.playOnAwake = true;

        // By default, VideoPlayers added to a camera will use the far plane.
        // Let's target the near plane instead.
        videoPlayer.renderMode = videoRenderMode;
        if (videoPlayer.renderMode == UnityEngine.Video.VideoRenderMode.RenderTexture)
        {
            videoPlayer.targetTexture = renderTexture;
        }

        // This will cause our Scene to be visible through the video being played.
        videoPlayer.targetCameraAlpha = 1.0F;

        // Set the video to play. URL supports local absolute or relative paths.
        // Here, using absolute.
        videoPlayer.url = path + videoName + ".mp4";

        // Check for looping of playback from beginning
        videoPlayer.isLooping = isLooping;

        // Check for aspect ratio of video playback
        videoPlayer.aspectRatio = videoAspectRatio;

        // When we reach the end, we stop the playback
        videoPlayer.loopPointReached += VideoEndReached;

        // Start playback. This means the VideoPlayer may have to prepare (reserve
        // resources, pre-load a few frames, etc.). To better control the delays
        // associated with this preparation one can use videoPlayer.Prepare() along with
        // its prepareCompleted event.
        videoPlayer.Play();
    }

    private void VideoEndReached(UnityEngine.Video.VideoPlayer vp)
    {
        switch (vp.isLooping)
        {
            case true:
                vp.Play();
                break;

            case false:
                StopVideo();
                break;
        }
    }

    public void StopVideo()
    {
        videoPlayer.Stop();

        sceneObject.GetComponent<AutoSceneHandler>().enabled = true;
    }

}
