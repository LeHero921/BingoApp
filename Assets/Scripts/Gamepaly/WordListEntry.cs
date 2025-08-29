using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WordListEntry : MonoBehaviour
{
    public GameObject EntryObj => gameObject;
    public TextMeshProUGUI NameText;
    // public Button EditButton;
    public WordList list;

    public Button DeleteButton;
    public event UnityAction<WordListEntry> DeleteButtonClicked;

    private void Start() {
        DeleteButton.onClick.AddListener(DeleteButtonAction);
    }

    private void DeleteButtonAction()
    {
        DeleteButtonClicked(this);
    }
}
