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
    public event UnityAction<BoardEntry> DeleteButtonClicked;

    private void Start() {
        DeleteButton.onClick.AddListener(DeleteButtonAction);
    }

    private void DeleteButtonAction()
    {
        DeleteButtonClicked(this);
    }
}
