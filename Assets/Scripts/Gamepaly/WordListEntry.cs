using UnityEngine;
using TMPro;

public class WordListEntry : MonoBehaviour
{
    public TextMeshProUGUI NameText;
    public WordList list;

    public void EditEntry()
    {
        ;
    }

    public void DeleteEntry()
    {
        GameplayManager.Instance.RemoveList(list);
    }
}
