using UnityEngine;
using System.Collections;

namespace Enemy
{
    public class EnemyStatus : MonoBehaviour
    {
        [SerializeField] private CharData _charData;
        private float _setTimer = 1.0f;
        private bool _isCollectable;
        private IEnumerator coroutine;

        public CharData CharData
        {
            get => _charData;
            set => _charData = value;
        }

        public bool IsCollectable => _isCollectable;

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
}

