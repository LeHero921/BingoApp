using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Board
{
    public string BoardName;
    public string LinkedListID;
    public bool isCompleted;
    public List<Field> fields;

    [System.Serializable]
    public class Field {
        public Vector2 field_position;
        public string field_entry;
        public bool field_completed;
    }
}

[System.Serializable]
public class WordList {
    public string ListID;
    public List<string> ListEntries;
}