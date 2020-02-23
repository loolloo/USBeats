using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FolderModule : MonoBehaviour
{
    public KeyCode catchKey;
    public KeyCode dumpKey;

    int folderData = 0;
    public int maxFolderData;

    [Header("Manager Elements")]
    public bool createMode = false;
    public float noteSpeed;
    public TrackManager manager;
    public int moduleIndex;

    [Header("UI Elements")]
    [SerializeField] Transform noteSpawn;
    [SerializeField] NoteTrigger noteTrigger;
    [SerializeField] Slider folderSize;
    [SerializeField] Text capacity;

    void Start()
    {
        folderData = 0;
        folderSize.value = 0;
        capacity.text = (maxFolderData - folderData) + " Mo";
    }

    void Update()
    {
        if (Input.GetKeyDown(catchKey))
            PressCatch();
        else if (Input.GetKeyDown(dumpKey))
            PressDump();
    }

    void PressCatch()
    {
        if (createMode) {
            AddNote();
        } else {
            CatchNote();
        }
    }

    void PressDump()
    {
        if (!createMode) {
            DumpData();
        }
    }

    void AddNote()
    {
        manager.AddTimeStamps(moduleIndex);
    }

    void AddData(int data)
    {
        folderData += data;
        folderSize.value = (float)folderData / (float)maxFolderData;
        capacity.text = (maxFolderData - folderData) + " Mo";
    }

    void DumpData()
    {
        manager.DumpModule(moduleIndex, folderData);
        folderData = 0;
        folderSize.value = 0;
    }

    public void SpawnNote(GameObject notePrefab, float delay)
    {
        GameObject note = Instantiate(notePrefab, noteSpawn);
        Note noteScript = note.GetComponent<Note>();

        noteScript.speed = noteSpeed;
        note.transform.position = noteTrigger.transform.position + new Vector3(0, 1, 0) * noteSpeed * delay;
    }

    public void RemoveNotes()
    {
        List<GameObject> toDestroy = new List<GameObject>();

        for (int i = 0; i < noteSpawn.childCount; i++) {
            toDestroy.Add(noteSpawn.GetChild(i).gameObject);
        }
        foreach (GameObject obj in toDestroy)
            DestroyImmediate(obj);
    }

    void CatchNote()
    {
        Note note;

        noteTrigger.onCatch?.Invoke();
        if (noteTrigger.registeredNote) {
            Debug.Log("Catch");
            note = noteTrigger.registeredNote;
            note.OnCatch();
            AddData(note.noteSize);
        } else {
            Debug.Log("No Note Catched");
        }
    }
}
