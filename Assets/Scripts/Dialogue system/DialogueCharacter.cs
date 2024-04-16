using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Dialog
{
    [SerializeField] public string _textDialog;

    [SerializeField] public List<string> _answers;
}

public class DialogueCharacter : MonoBehaviour
{
    [SerializeField] private List<Dialog> dialogList = new List<Dialog>();

    private Character _character;
    private void Start()
    {
        _character = gameObject.GetComponent<Character>();
    }


    public void StartDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogList, _character.Nickname);
    }

}
