using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float _difficultyFactor = 1f;
    [SerializeField] EnemyData[] _enemyPool;
    [SerializeField] float _timerBetweenEnemies;

    [SerializeField] int _enemyCount = 1;

    List<SplineContainer> _availableSplines;
    float _timeToSpawn;

    private void Start()
    {
        _availableSplines = SplineManager.instance.Splines;
    }

    private void Update()
    {
        if(Time.time > _timeToSpawn)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        _timeToSpawn = Time.time + 10f;

        var enemyType = PickRandomEnemy();
        var spline = PickRandomSpline();

       StartCoroutine(WaveSpawn(enemyType, spline));

    }

    IEnumerator WaveSpawn(EnemyData enemyData, SplineContainer spline)
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            var Enemy = Instantiate(enemyData._enemy, transform.position, Quaternion.Euler(enemyData._rotation));
            Enemy.AssignSpline(spline, SpeedCalulate());
            Enemy.name = "bluejay" + i;

            yield return new WaitForSeconds(_timerBetweenEnemies);
        }
    }


    private float SpeedCalulate()
    {
        return 1f;
    }

    private EnemyData PickRandomEnemy()
    {
        return _enemyPool[UnityEngine.Random.Range(0, _enemyPool.Length)];
    }

    private SplineContainer PickRandomSpline()
    {
        SplineContainer container = _availableSplines[UnityEngine.Random.Range(0, SplineManager.instance.Splines.Count)];

        return container;
    }
}
