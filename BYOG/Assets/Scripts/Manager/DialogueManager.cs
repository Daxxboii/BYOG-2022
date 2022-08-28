using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MyBox;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DialoguePerson;
    [SerializeField] private TextMeshProUGUI DialogueType;
    [SerializeField] private TextMeshProUGUI DialoGueContent;

    
    
    [System.Serializable]
    public struct Dialogue
    {
        public string DialoguePerson ;
        public string DialogueType;
        public string DialoGueContent;
    }

    [SerializeField]public List<Dialogue> AllDialoguesInScene;
    [ReadOnly]public int DialogueIndex;

    private void Start()
    {
        DialoguePerson.text = AllDialoguesInScene[0].DialoguePerson + ":";
        DialogueType.text = AllDialoguesInScene[0].DialogueType;
        DialoGueContent.text = AllDialoguesInScene[0].DialoGueContent;
    }

    public void NextDialogue()
    {
        DialogueIndex++;
        DialoguePerson.text = AllDialoguesInScene[DialogueIndex].DialoguePerson;
        DialogueType.text = AllDialoguesInScene[DialogueIndex].DialogueType;
        DialoGueContent.text = AllDialoguesInScene[DialogueIndex].DialoGueContent;
    }
}

