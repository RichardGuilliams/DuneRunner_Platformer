using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Dialogue text;
    private Dialogue lastDialogue;
    public enum Choices
    {
        A,
        B,
        C,
        D,
        E
    }

    public Choices choice;


    public bool IsDialogueLoaded()
    {
        if (text != null) return true;
        return false;
    }
    public void Next()
    {
        switch (choice)
        {
            case Choices.A:

                break;
            case Choices.B:

                break;
            case Choices.C:

                break;
            case Choices.D:

                break;

            case Choices.E:

                break;
        }
    }
    public void LoadDialogue(Dialogue dialogue)
    {
        text = dialogue;
        DisplayDialogue();
    }

    public void DisplayDialogue()
    {
            Debug.Log(text.dialogueA);
            Debug.Log(text.dialogueB);
            Debug.Log(text.dialogueC);
            Debug.Log(text.dialogueD);
    }
}
