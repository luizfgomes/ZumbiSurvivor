using UnityEngine;

[CreateAssetMenu(fileName = "CharData", menuName = "Scriptable Objects/CharData")]
public class CharData : ScriptableObject
{
    [Header("Stats")]
    public float maxHealth = 0;
    public float moveSpeed = 0;
    public float attackDamage = 0;
    public float rotationSpeed = 0;
    public bool isAlive = true;

    [Header("FX")]
    public AudioClip hitSfx;
    public GameObject deathVfx;
}
