using TMPro;
using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
    public TextMeshProUGUI FPSCounter;
    private float pollingTime = 1f;
    private float time;
    private int frameCount;

    void Update()
    {
        time += Time.deltaTime;
        frameCount++;

        if (time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            FPSCounter.text = frameRate.ToString() + " FPS";

            time -= pollingTime;
            frameCount = 0;
        }
    }
}
