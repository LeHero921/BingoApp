using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewListDialogue : MonoBehaviour
{
    [Header("Entry Instantiation")]
    public GameObject listEntryObj;
    public Transform scrolViewDestination;
    [Header("UI")]
    public UI_Object uI_Object;
    public Button saveButton;
    public Button addEntryButton;
    public TMP_InputField nameInput;
    [Header("Data")]
    public WordList newList;
    public List<WorldListSubEntry> SubEntries;

    private string newName;

    public void InitUI()
    {
        SubEntries = new List<WorldListSubEntry>();
        nameInput.onValueChanged.AddListener(OnNameInput);
        addEntryButton.onClick.AddListener(OnAddEntryButton);
        saveButton.onClick.AddListener(SaveList);
        SubEntries.Add(Instantiate(listEntryObj, scrolViewDestination).GetComponent<WorldListSubEntry>());
    }

    private void OnAddEntryButton()
    {
        SubEntries.Add(Instantiate(listEntryObj, scrolViewDestination).GetComponent<WorldListSubEntry>());
    }

    private void OnNameInput(string name)
    {
        newName = name;
    }

    public void SaveList()
    {
        List<string> entries = new List<string>();
        foreach (var e in SubEntries)
        {
            entries.Add(e.entryDataInput.text);
        }
        newList = new WordList(newName, entries);
        GameplayManager.Instance.NewList(newList);
    }

    private void Update() {
        if (SubEntries.Count !>= 9 && nameInput.text != null)
        {
            saveButton.interactable = true;
        }else
        {
            saveButton.interactable = false;
        }
    }
}
