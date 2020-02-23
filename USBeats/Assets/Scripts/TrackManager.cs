using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    public bool running = false;
    public bool createMode = false;
    public float currentTime;

    [Header("References")]
    public Track currentTrack;
    public FolderModule[] modules;
    public USBModule usbModule;
    public GameObject notePrefab;
    AudioSource audioSource;

    void Start()
    {
        SetupModules(false);
    }

    void SetupModules(bool createMode)
    {
        for (int i = 0; i < modules.Length; i++) {
            modules[i].transform.SetSiblingIndex(i);
            modules[i].createMode = createMode;
            modules[i].manager = this;
            modules[i].moduleIndex = i;
            modules[i].maxFolderData = currentTrack.maxFolderSize;
            modules[i].RemoveNotes();
        }
    }

    public void StartCreateMode()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = currentTrack.music;
        audioSource.Play();
        running = true;
        createMode = true;
        currentTime = 0;
        currentTrack.Reset();
        SetupModules(true);
    }

    public void EndCreateMode()
    {
        createMode = false;
        running = false;
    }

    public void StartPlayMode()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = currentTrack.music;
        audioSource.Play();
    
        currentTime = 0;
        running = true;
        SetupModules(false);
        for (int i = 0; i < modules.Length; i++) {
            foreach (float stamp in currentTrack.timeStamps[i].stamp)
                modules[i].SpawnNote(notePrefab, stamp);
        }
    }

    public void DumpModule(int index, int data)
    {
        usbModule.AddData(data);
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
