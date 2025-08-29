using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BoardEntry : MonoBehaviour
{
    public GameObject EntryObj => gameObject;
    public TextMeshProUGUI NameText;
    public Board board;

    public Button DeleteButton;
    public Button PlayButton;
    public event UnityAction<BoardEntry> DeleteButtonClicked;
    public event UnityAction<BoardEntry> PlayButtonClicked;

    private void Start() {
        DeleteButton.onClick.AddListener(DeleteButtonAction);
        PlayButton.onClick.AddListener(PlayButtonAction);
    }

    private void PlayButtonAction()
    {
        PlayButtonClicked(this);
    }

    private void DeleteButtonAction()
    {
        DeleteButtonClicked(this);
    }
}
