using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WordList_Helper : MonoBehaviour
{
    public GameObject ListEntry;
    public Transform ScrollViewDestination;
    public List<WordListEntry> WordListEntries;
    public NewListDialogue AddDialogue;

    public Button CreateNewButton;

    public GameObject newListDialogueObj;

    private void Start() {
        InitUI();
    }

    private void OnEnable() {
        Actions.OnWordListEntryChange += UpdateUI;
        Actions.OnDialogueClose += enableCreateButton;
    }

    private void OnDisable() {
        foreach (var entry in WordListEntries)
        {
            entry.DeleteButtonClicked -= DeleteButtonClicked;
        }
        Actions.OnWordListEntryChange -= UpdateUI;
        Actions.OnDialogueClose -= enableCreateButton;
    }

    public void InitUI()
    {
        WordListEntries = new List<WordListEntry>();
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (WordListEntries != null)
        {
            foreach (var entry in WordListEntries)
            {
                entry.DeleteButtonClicked -= DeleteButtonClicked;
                Destroy(entry.gameObject);
            }
        }
        WordListEntries = new List<WordListEntry>();

        SaveFile s = SaveManager.Instance.LoadGame();
        foreach (var wList in s.lists)
        {
            WordListEntry newWordListEntry = Instantiate(ListEntry, ScrollViewDestination).GetComponent<WordListEntry>();
            newWordListEntry.list = wList;
            newWordListEntry.NameText.text = wList.ListID;
            newWordListEntry.DeleteButtonClicked += DeleteButtonClicked;
            WordListEntries.Add(newWordListEntry);
        }
        // foreach (var e in WordListEntries)
        // {
        //     e.EditButton.onClick.AddListener(EditList(e.list));
        // }
    }

    public void CreateWordList()
    {
        CreateNewButton.interactable = false;
        AddDialogue = Instantiate(newListDialogueObj, transform).GetComponent<NewListDialogue>();
        AddDialogue.InitUI();
        AddDialogue.uI_Object.OpenUI();
    }
    public void RemoveWordList(WordListEntry entry)
    {
        if (entry != null)
        {
            Debug.LogWarning("Removing list entry : " + entry.list.ListID);
            GameplayManager.Instance.RemoveList(entry.list);
            WordListEntries.Remove(entry);
            Destroy(entry.gameObject);
            UpdateUI();
        }else
        {
            Debug.LogWarning("Entry is Null");
        }
    }

    private void DeleteButtonClicked(WordListEntry entry)
    {
        RemoveWordList(entry);
    }

    public void enableCreateButton()
    {
        CreateNewButton.interactable = true;
    }

    public UnityAction EditList(WordList list)
    {
        CreateNewButton.interactable = false;
        AddDialogue = Instantiate(newListDialogueObj, transform).GetComponent<NewListDialogue>();
        AddDialogue.LoadExistingList(list);
        AddDialogue.uI_Object.OpenUI();
        return null;
    }
}
