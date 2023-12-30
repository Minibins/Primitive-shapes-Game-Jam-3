using UnityEngine;
using UnityEngine.Profiling;

public static class Debugger
{
    public static int CurrentFPS => fps;
    public static int AverageFPS => avgFPS;
    public static int MinimumFPS => minFPS;
    public static int MaximumFPS => maxFPS;

    public static float CurrentFrameTimeMs => frameTimeMs;
    public static float AverageFrameTimeMs => avgFrameTimeMs;
    public static float MinimumFrameTimeMs => minFrameTimeMs;
    public static float MaximumFrameTimeMs => maxFrameTimeMs;

    public static int TotalMemoryMB => totalMemoryMB;
    public static int MonoMemoryUsageMB => monoMemoryUsageMB;
    public static int TotalMonoMemoryMB => totalMonoMemoryMB;
    public static int ReservedMemoryMb => reservedMemoryMB;
    public static int AllocatedMemoryMb => allocatedMemoryMB;

    public static int UsedGraphicsMemoryMB => usedGraphicsMemoryMB;
    public static int GraphicsMemoryMB => graphicsMemoryMB;

    
    private static int fps;
    private static int avgFPS;
    private static int minFPS;
    private static int maxFPS;
    
    private static float frameTimeMs;
    private static float avgFrameTimeMs;
    private static float totalFrameTimeMs;
    private static float minFrameTimeMs;
    private static float maxFrameTimeMs;

    private static int totalMemoryMB;
    private static int monoMemoryUsageMB;
    private static int totalMonoMemoryMB;
    private static int reservedMemoryMB;
    private static int allocatedMemoryMB;

    private static int usedGraphicsMemoryMB;
    private static int graphicsMemoryMB;

    private static int totalFPS;
    private static int frameCount;

    public static void Init()
    {
        minFPS = int.MaxValue;
        maxFPS = int.MinValue;
        minFrameTimeMs = float.MaxValue;
        maxFrameTimeMs = float.MinValue;
        totalMonoMemoryMB = SystemInfo.systemMemorySize;
        graphicsMemoryMB = SystemInfo.graphicsMemorySize;
    }

    public static void UpdateStats()
    {
        UpdateFPSStats();
        UpdateFrameTimeMs();
        UpdateMemoryUsage();
    }

    private static void UpdateMemoryUsage()
    {
        monoMemoryUsageMB = Mathf.RoundToInt(Profiler.GetMonoUsedSizeLong() / (1024f * 1024f));
        reservedMemoryMB = Mathf.RoundToInt(Profiler.GetTotalReservedMemoryLong() / (1024f * 1024f));
        allocatedMemoryMB = Mathf.RoundToInt(Profiler.GetTotalAllocatedMemoryLong() / (1024f * 1024f));
        usedGraphicsMemoryMB = Mathf.RoundToInt(Profiler.GetTotalReservedMemoryLong() / (1024f * 1024f));
        totalMemoryMB = monoMemoryUsageMB + reservedMemoryMB + allocatedMemoryMB;
    }

    private static void UpdateFrameTimeMs()
    {
        frameTimeMs = Time.unscaledDeltaTime * 1000;
        minFrameTimeMs = Mathf.Min(minFrameTimeMs, frameTimeMs);
        maxFrameTimeMs = Mathf.Max(maxFrameTimeMs, frameTimeMs);
        totalFrameTimeMs += frameTimeMs;
        avgFrameTimeMs = totalFrameTimeMs / frameCount;
    }

    private static void UpdateFPSStats()
    {
        fps = (int)(1f / Time.unscaledDeltaTime);
        frameCount++;
        totalFPS += fps;
        minFPS = Mathf.Min(minFPS, fps);
        maxFPS = Mathf.Max(maxFPS, fps);
        avgFPS = (int)(frameCount > 0 ? (float)totalFPS / frameCount : 0f);
    }
}
