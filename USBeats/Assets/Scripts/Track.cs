using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoloTrack
{
    public List<float> stamp;
}

[CreateAssetMenu()]
public class Track : ScriptableObject
{
    public AudioClip music;
	public SoloTrack[] timeStamps;
    public int maxFolderSize;

    public void Reset()
    {
        foreach (SoloTrack soloTrack in timeStamps)
            soloTrack.stamp = new List<float>();
    }
}
