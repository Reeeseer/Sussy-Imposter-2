using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    [SerializeField] public Vector3 _rotation;
    [SerializeField] public BasicEnemy _enemy;
}
