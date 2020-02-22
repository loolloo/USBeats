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
	public SoloTrack[] timeStamps;
}
