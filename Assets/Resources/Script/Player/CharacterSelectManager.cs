using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class CharacterSelectManager : MonoBehaviour {
    [SerializeField] private MatchSession session;
    [SerializeField] private CharacterData[] availableCharacters;
    [SerializeField] private int requiredPlayers = 2;

    private void Start() {
        session.Clear();
        // Inisialisasi slot per player
        for (int i = 0; i < requiredPlayers; i++) {
            session.players.Add(new PlayerSelection {
                playerIndex = i,
                controllerIndex = i,  // nanti bisa di-remap
                character = availableCharacters[0]
            });
        }
    }

    public void SetCharacter(int playerIndex, CharacterData character) {
        session.players[playerIndex].character = character;
    }

    public void SetReady(int playerIndex, bool ready) {
        session.players[playerIndex].isReady = ready;
        CheckAllReady();
    }

    private void CheckAllReady() {
        bool allReady = session.players.All(p => p.isReady);
        if (allReady) LoadGame();
    }

    private void LoadGame() {
        SceneManager.LoadScene("GameScene");
    }
}