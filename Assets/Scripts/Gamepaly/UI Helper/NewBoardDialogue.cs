using System.Collections.Generic;
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

    string newName;
    string selectionID;

    public void InitUI()
    {
        SaveFile s = SaveManager.Instance.LoadGame();
        for (int i = 0; i < s.lists.Count; i++)
        {
            listSelector.AddOptions(s.lists[i].ListEntries);
        }

        saveButton.onClick.AddListener(OnSaveButton);
        nameInput.onValueChanged.AddListener(OnNameInput);
        listSelector.onValueChanged.AddListener(OnListSelection);
    }

    void OnSaveButton()
    {
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
        for (int i = 0; i < 9; i++)
        {
            newFields.Add();
        }
        return null;
    }

    public void SaveBoard()
    {
        newBoard = new Board(newName, selectionID, GenerateBoardFields());
        GameplayManager.Instance.NewBoard(newBoard);
    }
}
