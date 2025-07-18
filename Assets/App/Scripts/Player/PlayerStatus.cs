using UnityEngine;
using System.Collections;

namespace Player
{
    public class PlayerStatus : MonoBehaviour
    {
        [SerializeField] private CharData _charData;
        private PlayerData _playerData;
        private int _currentMoney;
        private int _currentStack;
        private int _maxStack;

        public PlayerData PlayerData
        {
            get => _playerData;
            set => _playerData = value;
        }

        public int CurrentMoney
        {
            get => _currentMoney;
            set => _currentMoney = value;
        }

        public int CurrentStack
        {
            get => _currentStack;
            set => _currentStack = value;
        }

        public int MaxStack
        {
            get => _maxStack;
            set => _maxStack = value;
        }

        public void Start ()
        {
            _currentMoney = 0;
            _currentStack = 0;
            _maxStack = 5;
        }

        public void Awake ()
        {
            _playerData = new PlayerData(_charData);
        }
    }

    public class PlayerData
    {
        public float maxHealth = 0;
        public float moveSpeed = 0;
        public float attackDamage = 0;
        public float rotationSpeed = 0;
        public bool isAlive = true;

        public AudioClip hitSfx;
        public GameObject deathVfx;

        public PlayerData ( CharData source )
        {
            maxHealth = source.maxHealth;
            moveSpeed = source.moveSpeed;
            attackDamage = source.attackDamage;
            rotationSpeed = source.rotationSpeed;
            isAlive = source.isAlive;


            hitSfx = source.hitSfx;
            deathVfx = source.deathVfx;
        }
    }
}