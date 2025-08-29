using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardsList_Helper : MonoBehaviour
{
    public GameObject ListEntry;
    public Transform ScrollViewDestination;
    public List<BoardEntry> boardEntries;
    public NewBoardDialogue AddDialogue;

    public Button CreateNewButton;

    public GameObject newBoardDialogueObj;

    private void Start() {
        InitUI();
    }

    private void OnEnable() {
        Actions.OnBoardEntryChange += UpdateUI;
        Actions.OnDialogueClose += enableCreateButton;
    }

    private void OnDisable() {
        foreach (var entry in boardEntries)
        {
            entry.DeleteButtonClicked -= DeleteButtonClicked;
        }
        Actions.OnBoardEntryChange -= UpdateUI;
        Actions.OnDialogueClose -= enableCreateButton;
    }

    public void InitUI()
    {
        boardEntries = new List<BoardEntry>();
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (boardEntries != null)
        {
            foreach (var entry in boardEntries)
            {
                entry.DeleteButtonClicked -= DeleteButtonClicked;
                Destroy(entry.gameObject);
            }
        }
        boardEntries = new List<BoardEntry>();

        SaveFile s = SaveManager.Instance.LoadGame();
        foreach (var board in s.boards)
        {
            BoardEntry newBoardEntry = Instantiate(ListEntry, ScrollViewDestination).GetComponent<BoardEntry>();
            newBoardEntry.board = board;
            newBoardEntry.NameText.text = board.BoardName;
            newBoardEntry.DeleteButtonClicked += DeleteButtonClicked;
            boardEntries.Add(newBoardEntry);
        }
    }

    public void CreateBoard()
    {
        CreateNewButton.interactable = false;
        AddDialogue = Instantiate(newBoardDialogueObj, transform).GetComponent<NewBoardDialogue>();
        AddDialogue.InitUI();
        AddDialogue.uI_Object.OpenUI();
    }
    public void RemoveBoard(BoardEntry entry)
    {
        if (entry != null)
        {
            Debug.LogWarning("Removing list entry : " + entry.board.BoardName);
            GameplayManager.Instance.RemoveBoard(entry.board);
            boardEntries.Remove(entry);
            Destroy(entry.gameObject);
            UpdateUI();
        }else
        {
            Debug.LogWarning("Entry is Null");
        }
    }

    private void DeleteButtonClicked(BoardEntry entry)
    {
        RemoveBoard(entry);
    }

    public void enableCreateButton()
    {
        CreateNewButton.interactable = true;
    }
}
