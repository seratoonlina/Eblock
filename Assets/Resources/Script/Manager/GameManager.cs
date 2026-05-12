using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {
    [SerializeField] private MatchSession session;
    [SerializeField] private Transform[] spawnPoints;

    private void Start() {
        foreach (var selection in session.players) {
            SpawnPlayer(selection);
        }
    }

    private void SpawnPlayer(PlayerSelection selection) {
        var go = Instantiate(
            selection.character.prefab,
            spawnPoints[selection.playerIndex].position,
            Quaternion.identity
        );

        // Assign input
        var input = go.GetComponent<PlayerController>();
        input.SetControllerIndex(selection.controllerIndex);

        // Assign animator
        var animator = go.GetComponent<Animator>();
        animator.runtimeAnimatorController = selection.character.animController;
    }
}