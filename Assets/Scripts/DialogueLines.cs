using TMPro;
using UnityEngine;

public class DialogueLines : MonoBehaviour
{
    [SerializeField] string[] timelineDialogues;
    [SerializeField] TMP_Text dialogueLine;
    int currentLine = 0;

    public void loadNextLine()
    {
        ++currentLine;
        Debug.Log(timelineDialogues[currentLine] + " " + currentLine);
        dialogueLine.text = timelineDialogues[currentLine];
    }
}
