using System;               // fix: List<>, Serializable
using System.Collections.Generic;  // fix: List<>
using UnityEngine;

[CreateAssetMenu(menuName = "Football/MatchSession")]
public class MatchSession : ScriptableObject {
    public List<PlayerSelection> players = new();

    public void Clear() => players.Clear();
}

[System.Serializable]
public class PlayerSelection {
    public int playerIndex;       // 0, 1, 2, ...
    public CharacterData character;
    public int controllerIndex;   // device input index
    public bool isReady;
}