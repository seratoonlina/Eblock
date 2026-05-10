using UnityEngine;

[CreateAssetMenu(menuName = "Football/CharacterStats")]
public class CharacterStats : ScriptableObject {
    public float speed = 5f;
    public float jumpForce = 20f;
    public float stamina = 150f;
    public float heading = 70f;
    public float longPass = 70f;
    public float shortPass = 35f;
    public float finishing = 85f;
}