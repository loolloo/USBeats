using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    public bool running = false;
    public bool createMode = false;
    public float currentTime;
    public Track currentTrack;
    public FolderModule[] modules;

    [ContextMenu("Start")]
    void StartCreateMode()
    {
        running = true;
        createMode = true;
        for (int i = 0; i < modules.Length; i++) {
            modules[i].createMode = true;
            modules[i].manager = this;
            modules[i].moduleIndex = i;
        }
    }

    public void AddTimeStamps(int index)
    {
        Debug.Log("Add:" + currentTime.ToString());
        currentTrack.timeStamps[index].stamp.Add(currentTime);
    }

    void Update()
    {
        if (running)
            currentTime += Time.deltaTime;
    }
}
