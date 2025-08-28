using UnityEngine;

public class BoardsList_Helper : MonoBehaviour
{
    public GameObject ListEntry;
    public NewBoardDialogue AddDialogue;

    public void CreateBoard()
    {
        AddDialogue.InitUI();
        AddDialogue.uI_Object.OpenUI();
    }
}
