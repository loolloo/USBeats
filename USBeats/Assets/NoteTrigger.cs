using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTrigger : MonoBehaviour
{
    public Note registeredNote = null;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Note noteComponent = collider.gameObject.GetComponent<Note>();

        if (noteComponent) {
            registeredNote = noteComponent;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        Note noteComponent = collider.gameObject.GetComponent<Note>();

        if (noteComponent) {
            registeredNote = null;
        }
    }
}
