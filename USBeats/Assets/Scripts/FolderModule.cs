using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FolderModule : MonoBehaviour
{
    public KeyCode catchKey;
    public KeyCode dumpKey;

    [SerializeField] int folderData = 0;
    [SerializeField] int deadData = 0;
    [SerializeField] int totalData {
        get { return folderData + deadData; }
    }
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
        deadData = 0;
        folderSize.value = 0;
        capacity.text = (maxFolderData - totalData) + " Mo";
    }

    void Update()
    {
        if (Input.GetKeyDown(catchKey))
            PressCatch();
        else if (Input.GetKeyDown(dumpKey))
            PressDump();
        capacity.text = (maxFolderData - totalData) + " Mo";
        folderSize.value = (float)totalData / (float)maxFolderData;
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
        folderSize.value = (float)totalData / (float)maxFolderData;
        capacity.text = (maxFolderData - totalData) + " Mo";
    }

    void AddDeadData()
    {
        deadData += maxFolderData - totalData;
        folderSize.value = (float)totalData / (float)maxFolderData;
        capacity.text = (maxFolderData - totalData) + " Mo";
    }

    void DumpData()
    {
        manager.DumpModule(moduleIndex, folderData);
        manager.DumpBadData(moduleIndex, maxFolderData - folderData);
        manager.DumpBadData(moduleIndex, deadData);
        folderData = 0;
        deadData = 0;
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
            note = noteTrigger.registeredNote;

            if (totalData + note.noteSize <= maxFolderData) {
                // If the folder has enough space, the data will be added
                Debug.Log("Catch");
                note.OnCatch();
                AddData(note.noteSize);
            } else {
                // If the folder doesn't have enough space, fill it with unusable data
                Debug.Log("Bad catch");
                note.OnReject();
                if (totalData != maxFolderData)
                    AddDeadData();
            }
        } else {
            Debug.Log("No Note Catched");
        }
    }
}
