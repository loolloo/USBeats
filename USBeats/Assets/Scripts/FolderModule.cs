using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FolderModule : MonoBehaviour
{
    public bool createMode = false;
    public KeyCode inputKey;
    public Transform noteSpawn;

    float currentSize;
    float maxSize;
    public float noteSpeed;

    public TrackManager manager;
    public int moduleIndex;

    [Header("UI Elements")]
    Slider sizeJauge;
    [SerializeField]
    NoteTrigger noteTrigger;

    [Header("Debug")]
    GameObject _notePrefab;

    void Update()
    {
        if (Input.GetKeyDown(inputKey))
            Press();
    }

    void Press()
    {
        if (createMode) {
            AddNote();
        } else {
            CatchNote();
        }
    }

    void AddNote()
    {
        manager.AddTimeStamps(moduleIndex);
    }

    public void SpawnNote(GameObject notePrefab, float delay)
    {
        GameObject note = Instantiate(notePrefab, noteSpawn);
        Note noteScript = note.GetComponent<Note>();

        noteScript.speed = noteSpeed;
        note.transform.position = noteSpawn.position + new Vector3(0, 1, 0) * noteSpeed * delay;
        Debug.Log("Spawn note");
    }

    void CatchNote()
    {
        if (noteTrigger.registeredNote) {
            noteTrigger.registeredNote.OnCatch();
            Debug.Log("Catch Node");
        } else {
            Debug.Log("No Note Catched");
        }
    }
}
