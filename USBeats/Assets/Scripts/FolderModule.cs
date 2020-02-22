using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FolderModule : MonoBehaviour
{
    public bool createMode = false;
    public KeyCode inputKey;
    Transform noteSpawn;

    float currentSize;
    float maxSize;
    float noteSpeed;

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

    void SpawnNote(GameObject notePrefab, float delay)
    {
        GameObject note = Instantiate(notePrefab, noteSpawn);
        Rigidbody2D rb = note.GetComponent<Rigidbody2D>();

        note.transform.position = noteSpawn.position;
        rb.velocity = new Vector3(0, -noteSpeed, 0);
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
