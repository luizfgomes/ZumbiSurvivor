using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    [SerializeField] private PlayerStatus _playerStatus;
    [SerializeField] private Transform stackRoot;
    [SerializeField] private float verticalOffset = 0.4f;
    [SerializeField] private int maxStack = 10;
    [SerializeField] private float followSmoothTime = 0.2f;
    [SerializeField] private Vector3 scaleReduction = new Vector3(0.8f, 0.8f, 0.8f);

    [Header("Wiggle Settings")]
    [SerializeField] private float wiggleAmplitude = 0.025f;
    [SerializeField] private float wiggleFrequency = 2f;     // menor = mais suave

    private class StackedEnemy
    {
        public Transform transform;
        public Vector3 velocity = Vector3.zero;
    }

    private List<StackedEnemy> stackedEnemies = new();

    private void Start ()
    {
        EventBus.RaiseOnStackEnemy();
    }

    private void LateUpdate ()
    {
        float time = Time.time;

        for ( int i = 0; i < stackedEnemies.Count; i++ )
        {
            Transform targetTransform = (i == 0)
                ? stackRoot
                : stackedEnemies [i - 1].transform;

            Vector3 baseOffset = Vector3.up * verticalOffset;

            float wiggle = Mathf.Sin(time * wiggleFrequency + i * 0.3f) * wiggleAmplitude;
            Vector3 wiggleOffset = new Vector3(0, wiggle, 0);

            Vector3 targetPosition = targetTransform.position + baseOffset + wiggleOffset;

            stackedEnemies [i].transform.position = Vector3.SmoothDamp(
                stackedEnemies [i].transform.position,
                targetPosition,
                ref stackedEnemies [i].velocity,
                followSmoothTime
            );

            stackedEnemies [i].transform.rotation = Quaternion.identity;
        }
    }

    public void AddToStack ( Transform enemyTransform )
    {
        if ( stackedEnemies.Count >= maxStack )
            return;

        _playerStatus.CurrentStack++;
        EventBus.RaiseOnStackEnemy();
        enemyTransform.localScale = Vector3.Scale(enemyTransform.localScale, scaleReduction);
        enemyTransform.SetParent(null);
        stackedEnemies.Add(new StackedEnemy { transform = enemyTransform });
    }

    public void ReleaseStackToZone ( Vector3 zoneTargetPosition )
    {
        StartCoroutine(ReleaseStackRoutine(zoneTargetPosition));
    }

    private void Update ()
    {
        Debug.Log(stackedEnemies.Count.ToString());
    }

    private IEnumerator ReleaseStackRoutine ( Vector3 zoneTargetPosition )
    {
        float delayBetween = 0.1f;
        List<StackedEnemy> toRelease = new List<StackedEnemy>(stackedEnemies);
        stackedEnemies.Clear();

        for ( int i = 0; i < toRelease.Count; i++ )
        {
            StartCoroutine(MoveAndDestroy(toRelease [i].transform, zoneTargetPosition));
            yield return new WaitForSeconds(delayBetween);
            _playerStatus.CurrentStack--;
            EventBus.RaiseOnStackEnemy();
            EventBus.RaiseOnTradeEnemy();
        }
    }

    private IEnumerator MoveAndDestroy ( Transform enemy, Vector3 targetPosition )
    {
        Vector3 velocity = Vector3.zero;
        float smoothTime = followSmoothTime;
        float shrinkDuration = 0.4f;
        float totalTime = 0f;
        Vector3 startScale = enemy.localScale;

        while ( Vector3.Distance(enemy.position, targetPosition) > 0.05f )
        {
            enemy.position = Vector3.SmoothDamp(
                enemy.position,
                targetPosition,
                ref velocity,
                smoothTime
            );

            totalTime += Time.deltaTime;
            float t = totalTime / shrinkDuration;

            enemy.localScale = Vector3.Lerp(startScale, Vector3.zero, t);

            yield return null;
        }

        Destroy(enemy.gameObject);
    }
}
