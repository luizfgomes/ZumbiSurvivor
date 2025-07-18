using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
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

    private void LateUpdate ()
    {
        float time = Time.time;

        for ( int i = 0; i < stackedEnemies.Count; i++ )
        {
            Transform targetTransform = (i == 0)
                ? stackRoot
                : stackedEnemies [i - 1].transform;

            Vector3 baseOffset = Vector3.up * verticalOffset;

            // Wiggle vertical apenas no eixo Y
            float wiggle = Mathf.Sin(time * wiggleFrequency + i * 0.3f) * wiggleAmplitude;
            Vector3 wiggleOffset = new Vector3(0, wiggle, 0);

            Vector3 targetPosition = targetTransform.position + baseOffset + wiggleOffset;

            stackedEnemies [i].transform.position = Vector3.SmoothDamp(
                stackedEnemies [i].transform.position,
                targetPosition,
                ref stackedEnemies [i].velocity,
                followSmoothTime
            );

            // Fixar rotação
            stackedEnemies [i].transform.rotation = Quaternion.identity;
        }
    }

    public void AddToStack ( Transform enemyTransform )
    {
        if ( stackedEnemies.Count >= maxStack )
            return;

        enemyTransform.localScale = Vector3.Scale(enemyTransform.localScale, scaleReduction);
        enemyTransform.SetParent(null);
        stackedEnemies.Add(new StackedEnemy { transform = enemyTransform });
    }
}
