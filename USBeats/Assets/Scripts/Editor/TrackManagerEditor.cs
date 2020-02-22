using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TrackManager))]
public class TrackManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        TrackManager trackManager = (TrackManager)target;
        
        GUILayout.Space(16);
        if (GUILayout.Button("Start Create Mode")) {
            trackManager.StartCreateMode();
        }
        if (GUILayout.Button("Start Play Mode")) {
            trackManager.StartPlayMode();
        }
    }
}
