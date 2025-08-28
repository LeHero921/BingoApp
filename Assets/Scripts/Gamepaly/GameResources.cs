using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Board
{
    public Board(string n, string l, List<Field> f)
    {
        BoardName = n;
        LinkedList = l;
        fields = f;
    }

    public string BoardName;
    public string LinkedList;
    public bool isCompleted;
    public List<Field> fields;
}

[System.Serializable]
public class WordList {
    public string ListID;
    public List<string> ListEntries;
}

[System.Serializable]
public class Field {
        public Vector2 field_position;
        public string field_entry;
        public bool field_completed;
}