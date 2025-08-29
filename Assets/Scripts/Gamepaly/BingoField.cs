using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class BingoField : MonoBehaviour
{
    #region Singelton
    private static BingoField _instance;
    public static BingoField Instance => _instance;

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

    public List<BingoFieldButton> fieldButtons;
    public TextMeshProUGUI BoardTitleText;
    public GameObject fieldObj;
    public Transform target;

    public Board currentBoard;

    private void OnEnable() {
        Actions.OnBingoFieldButtonClicked += SaveButtonStatus;
    }
    private void OnDisable() {
        Actions.OnBingoFieldButtonClicked -= SaveButtonStatus;
    }

    public void LoadField(Board board)
    {
        currentBoard = board;
        BoardTitleText.text = currentBoard.BoardName;
        fieldButtons = new List<BingoFieldButton>();
        for (int i = 0; i < board.fields.Count; i++)
        {
            fieldButtons.Add(Instantiate(fieldObj, target).GetComponent<BingoFieldButton>());
            fieldButtons[i].fieldPosition = board.fields[i].field_position;
            fieldButtons[i].clicked = currentBoard.fields[i].field_completed;
            fieldButtons[i].LoadButton(board.fields[i].field_entry);
        }
    }

    public void SaveButtonStatus()
    {
        Debug.Log("ASDF Movies");
        SaveFile s = SaveManager.Instance.LoadGame();

        // sync Buttons -> Fields
        for (int i = 0; i < currentBoard.fields.Count; i++)
        {
            currentBoard.fields[i].field_completed = fieldButtons[i].clicked;
        }

        // das richtige Board suchen
        Board savedBoard = s.boards.Find(x => x.BoardName == currentBoard.BoardName);
        if (savedBoard != null)
        {
            savedBoard.fields = currentBoard.fields; // Felder aktualisieren
        }
        else
        {
            Debug.LogWarning("Board nicht im SaveFile gefunden!");
        }

        SaveManager.Instance.SaveGame(s);
        if (CheckBingo(currentBoard) == true)
        {
            Debug.LogWarning("BINGO");
        }else
        {
            Debug.LogWarning("No Bingo yet");
        }
    }

    public bool CheckBingo(Board board)
    {
        // Horizontal
        for (int y = 0; y < 3; y++)
        {
            if (board.fields.Exists(f => f.field_position == new Vector2(0, y) && f.field_completed) &&
                board.fields.Exists(f => f.field_position == new Vector2(1, y) && f.field_completed) &&
                board.fields.Exists(f => f.field_position == new Vector2(2, y) && f.field_completed))
                return true;
        }

        // Vertikal
        for (int x = 0; x < 3; x++)
        {
            if (board.fields.Exists(f => f.field_position == new Vector2(x, 0) && f.field_completed) &&
                board.fields.Exists(f => f.field_position == new Vector2(x, 1) && f.field_completed) &&
                board.fields.Exists(f => f.field_position == new Vector2(x, 2) && f.field_completed))
                return true;
        }

        // Diagonalen
        if (board.fields.Exists(f => f.field_position == new Vector2(0, 0) && f.field_completed) &&
            board.fields.Exists(f => f.field_position == new Vector2(1, 1) && f.field_completed) &&
            board.fields.Exists(f => f.field_position == new Vector2(2, 2) && f.field_completed))
            return true;

        if (board.fields.Exists(f => f.field_position == new Vector2(2, 0) && f.field_completed) &&
            board.fields.Exists(f => f.field_position == new Vector2(1, 1) && f.field_completed) &&
            board.fields.Exists(f => f.field_position == new Vector2(0, 2) && f.field_completed))
            return true;

        return false;
    }

    public void ResetBingoField()
    {
        foreach (var field in fieldButtons)
        {
            Destroy(field.gameObject);
        }
        currentBoard = null;
    }
}
