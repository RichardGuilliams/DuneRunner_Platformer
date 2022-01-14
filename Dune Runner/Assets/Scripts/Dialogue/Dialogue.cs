using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public List<string> dialogueA;
    public List<string> dialogueB;
    public List<string> dialogueC;
    public List<string> dialogueD;
    public Dialogue choice1;
    public Dialogue choice2;
    public Dialogue choice3;
    public Dialogue choice4;

    public void Start()
    {
        choice1 = choice1.GetComponent<Dialogue>();
        choice2 = choice2.GetComponent<Dialogue>();
        choice3 = choice3.GetComponent<Dialogue>();
        choice4 = choice4.GetComponent<Dialogue>();
    }

}
