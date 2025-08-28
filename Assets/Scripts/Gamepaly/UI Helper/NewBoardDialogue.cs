using TMPro;
using UnityEngine;

public class NewBoardDialogue : MonoBehaviour
{
    public Board newBoard;

    public TMP_InputField nameInput;
    public TMP_Dropdown listSelector;
    
    public void SaveBoard()
    {
        GameplayManager.Instance.NewBoard(newBoard);
    }
}
