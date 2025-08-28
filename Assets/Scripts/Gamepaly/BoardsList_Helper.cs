using UnityEngine;

public class BoardsList_Helper : MonoBehaviour
{
    public GameObject ListEntry;
    public UI_Object AddDialogue;

    public void CreateBoard()
    {
        AddDialogue.OpenUI();
    }
}
