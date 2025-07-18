using UnityEngine;
using System.Collections;

namespace Enemy
{
    public class EnemyStatus : MonoBehaviour
    {
        [SerializeField] private CharData _charData;
        private EnemyData _enemyData;
        private float _setTimer = 1.0f;
        private bool _isCollectable;
        private IEnumerator coroutine;

        public EnemyData EnemyData
        {
            get => _enemyData;
            set => _enemyData = value;
        }

        public bool IsCollectable => _isCollectable;

        public void Awake ()
        {
            _enemyData = new EnemyData(_charData);
        }

        public void TurnEnemyToCollectable ()
        {
            coroutine = TurnEnemyStatus(_setTimer);
            StartCoroutine(coroutine);
        }

        private IEnumerator TurnEnemyStatus (float value)
        {
            yield return new WaitForSeconds(value);
            _isCollectable = true;
        }
    }

    public class EnemyData
    {
        public float maxHealth = 0;
        public float moveSpeed = 0;
        public float attackDamage = 0;
        public float rotationSpeed = 0;
        public bool isAlive = true;

        public AudioClip hitSfx;
        public GameObject deathVfx;

        public EnemyData ( CharData source )
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