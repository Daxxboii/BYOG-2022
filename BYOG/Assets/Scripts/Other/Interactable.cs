using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

public class Interactable : MonoBehaviour
{
    public enum Type { Door,Note,Portal}

    public Type _Type;

    [Foldout("Door", true)]
    [SerializeField] private Animator DoorAnimator;

    [Foldout("Note", true)]
    [SerializeField, TextArea(10,50)] public string NoteText;

    [Foldout("Portal", true)]
    [SerializeField, Scene] public string SceneToLoad;

}
