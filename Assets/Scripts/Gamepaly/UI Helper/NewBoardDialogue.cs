using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewBoardDialogue : MonoBehaviour
{
    public Board newBoard;
    public UI_Object uI_Object;
    public TMP_InputField nameInput;
    public TMP_Dropdown listSelector;
    public Button saveButton;
    public int boardSize;

    string newName;
    string selectionID;

    public void InitUI()
    {
        SaveFile s = SaveManager.Instance.LoadGame();
        for (int i = 0; i < s.lists.Count; i++)
        {
            listSelector.options.Add(new TMP_Dropdown.OptionData(s.lists[i].ListID));
        }

        saveButton.onClick.AddListener(SaveBoard);
        nameInput.onValueChanged.AddListener(OnNameInput);
        listSelector.onValueChanged.AddListener(OnListSelection);
    }

    void OnNameInput(string name)
    {
        newName = name;
    }
    void OnListSelection(int index)
    {
        selectionID = listSelector.options[index].text;
    }

    public List<Field> GenerateBoardFields()
    {
        SaveFile s = SaveManager.Instance.LoadGame();
        WordList wl = s.lists.Find(x => x.ListID == selectionID);
        List<Field> newFields = new List<Field>();

        List<string> shuffled = wl.ListEntries
            .OrderBy(_ => Random.value) // UnityEngine.Random
            .Take(9) // nur 9 Wörter
            .ToList();

        int index = 0;
        for (int x = 0; x < boardSize; x++)
        {
            for (int y = 0; y < boardSize; y++)
            {
                string newEntry = shuffled[index];
                newFields.Add(new Field(new Vector2(x,y), newEntry));
                index++;
            }
        }
        return newFields;
    }

    public void SaveBoard()
    {
        List<Field> fields = GenerateBoardFields();
        newBoard = new Board(newName, selectionID, fields);
        GameplayManager.Instance.NewBoard(newBoard);
    }
}
