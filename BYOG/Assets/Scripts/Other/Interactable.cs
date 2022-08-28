using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public enum Type { Door,Note,Portal,OnTrigger}

    public Type _Type;

    public Transform Tracker;

    [Foldout("Door", true)]
    [SerializeField] private Animator DoorAnimator;

    [Foldout("Note", true)]
    [SerializeField, TextArea(10,50)] public string NoteText;

    [Foldout("Portal", true)]
    [SerializeField,Scene] public string SceneToLoad;

    [Foldout("Trigger", true)]
    [SerializeField] public UnityEvent Event;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") Event.Invoke();
       
    }



}
