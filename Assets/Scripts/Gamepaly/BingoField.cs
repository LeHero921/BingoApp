using System.Collections.Generic;
using UnityEngine;

public class BingoField : MonoBehaviour
{
    public List<BingoFieldButton> fieldButtons;
    public GameObject fieldObj;
    public Transform target;

    public void LoadField(Board board)
    {
        fieldButtons = new List<BingoFieldButton>();
        for (int i = 0; i < board.fields.Count; i++)
        {
            fieldButtons.Add(Instantiate(fieldObj, target).GetComponent<BingoFieldButton>());
            fieldButtons[i].buttonLabel.text = board.fields[i].field_entry;
            fieldButtons[i].fieldPosition = board.fields[i].field_position;
        }
    }

    public void CheckBingo()
    {
        //
    }
}
