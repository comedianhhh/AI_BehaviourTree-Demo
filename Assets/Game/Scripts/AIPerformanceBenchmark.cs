using UnityEngine;
using UnityEngine.Profiling;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Performance benchmarking tool for AI Behaviour Tree Demo
/// Demonstrates quantifiable metrics and performance analysis
/// Part of "Beyond Classroom" portfolio showcase
/// </summary>
public class AIPerformanceBenchmark : MonoBehaviour
{
    [Header("Benchmark Configuration")]
    public int maxAgents = 100;
    public int testDurationSeconds = 30;
    public bool autoRunBenchmark = false;
    
    [Header("Performance Metrics")]
    [SerializeField] private float averageFrameTime;
    [SerializeField] private float averageFPS;
    [SerializeField] private int activeAgents;
    [SerializeField] private long memoryUsageMB;
    
    [Header("AI Agent Prefab")]
    public GameObject aiAgentPrefab;
    public Transform spawnArea;
    
    private List<GameObject> spawnedAgents = new List<GameObject>();
    private PerformanceMetrics metrics = new PerformanceMetrics();
    private bool isBenchmarkRunning = false;
    
    [System.Serializable]
    public class PerformanceMetrics
    {
        public float totalFrameTime;
        public int frameCount;
        public float minFPS = float.MaxValue;
        public float maxFPS = 0f;
        public long startMemory;
        public long currentMemory;
        
        public float AverageFrameTime => frameCount > 0 ? totalFrameTime / frameCount : 0f;
        public float AverageFPS => AverageFrameTime > 0 ? 1f / AverageFrameTime : 0f;
        public long MemoryDelta => currentMemory - startMemory;
    }
    
    void Start()
    {
        if (autoRunBenchmark)
        {
            StartBenchmark();
        }
    }
    
    void Update()
    {
        if (isBenchmarkRunning)
        {
            RecordFrameMetrics();
            UpdateUIMetrics();
        }
        
        // Keyboard shortcuts for testing
        if (Input.GetKeyDown(KeyCode.B))
            StartBenchmark();
        if (Input.GetKeyDown(KeyCode.S))
            StopBenchmark();
        if (Input.GetKeyDown(KeyCode.R))
            GenerateReport();
    }
    
    [ContextMenu("Start Benchmark")]
    public void StartBenchmark()
    {
        Debug.Log("Starting AI Performance Benchmark...");
        
        // Reset metrics
        metrics = new PerformanceMetrics();
        metrics.startMemory = Profiler.GetTotalAllocatedMemory(false);
        
        // Clear existing agents
        ClearAgents();
        
        // Start spawning agents
        isBenchmarkRunning = true;
        InvokeRepeating(nameof(SpawnAgentBatch), 0f, 2f);
        Invoke(nameof(StopBenchmark), testDurationSeconds);
    }
    
    [ContextMenu("Stop Benchmark")]
    public void StopBenchmark()
    {
        Debug.Log("Stopping AI Performance Benchmark...");
        
        isBenchmarkRunning = false;
        CancelInvoke();
        
        GenerateReport();
    }
    
    private void SpawnAgentBatch()
    {
        if (spawnedAgents.Count >= maxAgents)
        {
            CancelInvoke(nameof(SpawnAgentBatch));
            return;
        }
        
        // Spawn 5 agents at a time
        for (int i = 0; i < 5 && spawnedAgents.Count < maxAgents; i++)
        {
            SpawnAgent();
        }
        
        Debug.Log($"Spawned agents: {spawnedAgents.Count}/{maxAgents}");
    }
    
    private void SpawnAgent()
    {
        if (aiAgentPrefab == null || spawnArea == null) return;
        
        Vector3 randomPosition = GetRandomSpawnPosition();
        GameObject agent = Instantiate(aiAgentPrefab, randomPosition, Quaternion.identity);
        
        // Ensure agent has required components
        if (agent.GetComponent<MinerBob>() == null)
        {
            agent.AddComponent<MinerBob>();
        }
        
        spawnedAgents.Add(agent);
    }
    
    private Vector3 GetRandomSpawnPosition()
    {
        if (spawnArea == null)
            return Vector3.zero;
            
        Bounds bounds = spawnArea.GetComponent<Collider>()?.bounds ?? new Bounds(spawnArea.position, Vector3.one * 10f);
        
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            bounds.center.y,
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
    
    private void RecordFrameMetrics()
    {
        float frameTime = Time.unscaledDeltaTime;
        float currentFPS = 1f / frameTime;
        
        metrics.totalFrameTime += frameTime;
        metrics.frameCount++;
        metrics.minFPS = Mathf.Min(metrics.minFPS, currentFPS);
        metrics.maxFPS = Mathf.Max(metrics.maxFPS, currentFPS);
        metrics.currentMemory = Profiler.GetTotalAllocatedMemory(false);
    }
    
    private void UpdateUIMetrics()
    {
        averageFrameTime = metrics.AverageFrameTime * 1000f; // Convert to milliseconds
        averageFPS = metrics.AverageFPS;
        activeAgents = spawnedAgents.Count;
        memoryUsageMB = metrics.MemoryDelta / (1024 * 1024);
    }
    
    [ContextMenu("Generate Report")]
    public void GenerateReport()
    {
        StringBuilder report = new StringBuilder();
        report.AppendLine("=== AI Behaviour Tree Performance Report ===");
        report.AppendLine($"Test Duration: {testDurationSeconds} seconds");
        report.AppendLine($"Active AI Agents: {activeAgents}");
        report.AppendLine();
        
        report.AppendLine("Performance Metrics:");
        report.AppendLine($"  Average Frame Time: {averageFrameTime:F2} ms");
        report.AppendLine($"  Average FPS: {averageFPS:F1}");
        report.AppendLine($"  Min FPS: {metrics.minFPS:F1}");
        report.AppendLine($"  Max FPS: {metrics.maxFPS:F1}");
        report.AppendLine();
        
        report.AppendLine("Memory Metrics:");
        report.AppendLine($"  Memory Delta: {memoryUsageMB} MB");
        report.AppendLine($"  Per-Agent Memory: {(memoryUsageMB / (float)activeAgents):F2} MB");
        report.AppendLine();
        
        report.AppendLine("Efficiency Metrics:");
        report.AppendLine($"  Frame Time per Agent: {(averageFrameTime / activeAgents):F3} ms");
        report.AppendLine($"  Agents per Frame (60 FPS): {(16.67f / (averageFrameTime / activeAgents)):F0}");
        report.AppendLine();
        
        // Performance benchmarks
        report.AppendLine("Performance Benchmarks:");
        if (averageFPS >= 60 && activeAgents >= 50)
            report.AppendLine("  ✅ EXCELLENT: 50+ agents at 60+ FPS");
        else if (averageFPS >= 30 && activeAgents >= 25)
            report.AppendLine("  ✅ GOOD: 25+ agents at 30+ FPS");
        else if (averageFPS >= 15)
            report.AppendLine("  ⚠️ FAIR: Maintaining 15+ FPS");
        else
            report.AppendLine("  ❌ POOR: Below 15 FPS");
            
        if (memoryUsageMB < 5)
            report.AppendLine("  ✅ EXCELLENT: Memory usage under 5MB");
        else if (memoryUsageMB < 10)
            report.AppendLine("  ✅ GOOD: Memory usage under 10MB");
        else
            report.AppendLine("  ⚠️ HIGH: Consider memory optimization");
        
        Debug.Log(report.ToString());
        
        // Save to file if in editor
        #if UNITY_EDITOR
        string filePath = Application.dataPath + "/BenchmarkReport.txt";
        System.IO.File.WriteAllText(filePath, report.ToString());
        Debug.Log($"Report saved to: {filePath}");
        #endif
    }
    
    private void ClearAgents()
    {
        foreach (GameObject agent in spawnedAgents)
        {
            if (agent != null)
                DestroyImmediate(agent);
        }
        spawnedAgents.Clear();
    }
    
    void OnGUI()
    {
        if (!isBenchmarkRunning) return;
        
        GUI.Box(new Rect(10, 10, 250, 120), "AI Performance Monitor");
        
        GUILayout.BeginArea(new Rect(15, 35, 240, 100));
        GUILayout.Label($"Active Agents: {activeAgents}");
        GUILayout.Label($"Average FPS: {averageFPS:F1}");
        GUILayout.Label($"Frame Time: {averageFrameTime:F2} ms");
        GUILayout.Label($"Memory: {memoryUsageMB} MB");
        
        if (GUILayout.Button("Stop Benchmark"))
            StopBenchmark();
        GUILayout.EndArea();
    }
}