using TMPro;
using UnityEngine;

public class BoardEntry : MonoBehaviour
{
    public TextMeshProUGUI NameText;
    public Board board;

    public void DeleteEntry()
    {
        GameplayManager.Instance.RemoveBoard(board);
    }
}
