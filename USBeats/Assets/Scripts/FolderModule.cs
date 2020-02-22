using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FolderModule : MonoBehaviour
{
    public KeyCode inputKey;

    [Header("Manager Elements")]
    public bool createMode = false;
    public float noteSpeed;
    public TrackManager manager;
    public int moduleIndex;

    [Header("UI Elements")]
    [SerializeField] Transform noteSpawn;
    [SerializeField] NoteTrigger noteTrigger;
    [SerializeField] Slider folderSize;

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
