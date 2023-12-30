using UnityEngine;
using UnityEngine.UI;

public class DebugScreen : MonoBehaviour
{
    public Text
        _currentFpsText,
        _currentFrameTimeMsText,
        _totalMemoryMbText,
        _usedGraphicsMemoryMbText;


    public string _currentFpsTextColor = "green";

    public float _startUpdateAfterTime;
    public float _startTime;

    private void Start()
    {
        _startTime = Time.time;
        Debugger.Init();
    }

    private void Update()
    {
        if (Time.time - _startTime < _startUpdateAfterTime)
            return;
        Debugger.UpdateStats();

        UpdateText();
    }

    private void UpdateText()
    {
        float _currentFps = Debugger.CurrentFPS;
        float _averageFps = Debugger.AverageFPS;
        float _minimumFps = Debugger.MinimumFPS;
        float _maximumFps = Debugger.MaximumFPS;

        float _currentFrameTimeMs = Debugger.CurrentFrameTimeMs;
        float _averageFrameTimeMs = Debugger.AverageFrameTimeMs;
        float _minimumFrameTimeMs = Debugger.MinimumFrameTimeMs;
        float _maximumFrameTimeMs = Debugger.MaximumFrameTimeMs;

        float _totalMemoryMb = Debugger.TotalMemoryMB;
        float _monoMemoryMb = Debugger.TotalMonoMemoryMB;

        float _usedGraphicsMemoryMb = Debugger.UsedGraphicsMemoryMB;
        float _graphicsMemoryMb = Debugger.GraphicsMemoryMB;


        _currentFpsTextColor = _currentFps > 60 ? "green" : "red";

        _currentFpsText.text = "<color=" + _currentFpsTextColor + ">" + "FPS: " + _currentFps + "</color>" + "<color=" + _currentFpsTextColor + ">" + " [MIN: " + _minimumFps + ",</color>" + " " + "<color=" + _currentFpsTextColor + ">" + "AVG: " + _averageFps + ",</color>" + " " + "<color=" + _currentFpsTextColor + ">" + "MAX: " + _maximumFps + "]</color>";
        _currentFrameTimeMsText.text = "<color=" + _currentFpsTextColor + ">" + "Frame Time: " + _currentFrameTimeMs + "(ms) </color>" + "<color=" + _currentFpsTextColor + ">" + " [MIN: " + _minimumFrameTimeMs + "(ms), </color>" + " " + "<color=" + _currentFpsTextColor + ">" + "AVG: " + _averageFrameTimeMs + "(ms), </color>" + "<color=" + _currentFpsTextColor + ">" + " " + "MAX: " + _maximumFrameTimeMs + "(ms)]</color>";

        _totalMemoryMbText.text = "<color=" + _currentFpsTextColor + ">" + "Memory Used: " + _totalMemoryMb + "(MB) </color>" + "/ " + "<color=" + _currentFpsTextColor + ">" + _monoMemoryMb + "(MB) </color>";
        _usedGraphicsMemoryMbText.text = "<color=" + _currentFpsTextColor + ">" + "Used Graphics Memory: " + _usedGraphicsMemoryMb + "(MB) </color>" + "/ " + "<color=" + _currentFpsTextColor + ">" + _graphicsMemoryMb + "(MB) </color>";
    }
}