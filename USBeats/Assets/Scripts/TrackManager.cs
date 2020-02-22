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

    AudioSource audioSource;

    public void StartCreateMode()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = currentTrack.music;
        audioSource.Play();
        running = true;
        createMode = true;
        currentTime = 0;
        currentTrack.Reset();
        for (int i = 0; i < modules.Length; i++) {
            modules[i].createMode = true;
            modules[i].manager = this;
            modules[i].moduleIndex = i;
        }
    }

    public void EndCreateMode()
    {
        createMode = false;
        running = false;
    }

    public void AddTimeStamps(int index)
    {
        Debug.Log("Add to module (" + index + "):" + currentTime.ToString());
        currentTrack.timeStamps[index].stamp.Add(currentTime);
    }

    void Update()
    {
        if (running)
            currentTime += Time.deltaTime;
        if (createMode && audioSource) {
            if (!audioSource.isPlaying)
                EndCreateMode();
        }
    }
}
