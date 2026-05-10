using UnityEngine;

[CreateAssetMenu(menuName = "Football/Character")]
public class CharacterData : ScriptableObject {
    public string characterName;
    public Sprite portrait;
    public GameObject prefab;
    public RuntimeAnimatorController animController;
    public CharacterStats stats;
}