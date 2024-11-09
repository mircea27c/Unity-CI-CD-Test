using UnityEditor;
using UnityEngine;
using UnityEditor.Build.Reporting;

public class BuildScript
{
    [MenuItem("Build/BuildiOS")]
    public static void Build()
    {
        var buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = GetScenesInBuildSettings();
        buildPlayerOptions.locationPathName = "Builds/iosBuild";
        buildPlayerOptions.target = BuildTarget.iOS;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded) Debug.Log("Build succeeded: " + summary.totalSize + " bytes");

        if (summary.result == BuildResult.Failed) Debug.Log("Build failed");
    }

    private static string[] GetScenesInBuildSettings()
    {
        int sceneCount = EditorBuildSettings.scenes.Length;
        string[] scenes = new string[sceneCount];

        for (int i = 0; i < sceneCount; i++)
        {
            scenes[i] = EditorBuildSettings.scenes[i].path;
        }

        return scenes;
    }
}