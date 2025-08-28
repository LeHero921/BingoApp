using UnityEngine;

public class WordList_Helper : MonoBehaviour
{
    public GameObject ListEntry;
    public NewListDialogue AddDialogue;

    public void CreateList()
    {
        AddDialogue.InitUI();
        AddDialogue.uI_Object.OpenUI();
    }
}
