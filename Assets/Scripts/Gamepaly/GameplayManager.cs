using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    #region Singelton
    private static GameplayManager _instance;
    public static GameplayManager Instance => _instance;

    public UI_Object MainScreen;
    public UI_Object GameScreen;

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
        Debug.LogWarning("Adding Board");
        SaveFile s = SaveManager.Instance.LoadGame();
        s.boards.Add(board);
        SaveManager.Instance.SaveGame(s);
    }

    public void RemoveList(WordList list)
    {
        SaveFile s = SaveManager.Instance.LoadGame();
        Debug.LogError("A " + s.lists.Count);
        s.lists.RemoveAll(l => l.ListID == list.ListID);
        Debug.LogError("B " + s.lists.Count);
        SaveManager.Instance.SaveGame(s);
        Actions.OnWordListEntryChange?.Invoke();
    }
    public void RemoveBoard(Board board)
    {
        SaveFile s = SaveManager.Instance.LoadGame();
        s.boards.RemoveAll(b => b.BoardName == board.BoardName);
        SaveManager.Instance.SaveGame(s);
        Actions.OnBoardEntryChange?.Invoke();
    }

    /// <summary>
    /// direction true -> Main > Game | false -> Game > Main
    /// </summary>
    /// <param name="direction"></param>
    public void SwitchScreens(bool direction)
    {
        if (direction == true) // from Main to Game
        {
            MainScreen.CloseUI();
            GameScreen.OpenUI();
        }
        else // from Game to Main
        {
            GameScreen.CloseUI();
            MainScreen.OpenUI();
        }
    }
}
