using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    #region Singelton
    private static GameplayManager _instance;
    public static GameplayManager Instance => _instance;

    private void Awake() {
        if (_instance == null)
        {
            _instance = this;
        }else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public void NewList(WordList list)
    {
        SaveFile s = SaveManager.Instance.LoadGame();
        s.lists.Add(list);
        SaveManager.Instance.SaveGame(s);
    }
    public void NewBoard(Board board)
    {
        SaveFile s = SaveManager.Instance.LoadGame();
        s.boards.Add(board);
        SaveManager.Instance.SaveGame(s);
    }

    public void RemoveList(WordList list)
    {
        SaveFile s = SaveManager.Instance.LoadGame();
        s.lists.Remove(list);
        SaveManager.Instance.SaveGame(s);
    }
    public void RemoveBoard(Board board)
    {
        SaveFile s = SaveManager.Instance.LoadGame();
        s.boards.Remove(board);
        SaveManager.Instance.SaveGame(s);
    }
}
