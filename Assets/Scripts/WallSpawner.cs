using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField] Wall _wallPrefab;
    [SerializeField] float _timeBetweenWalls = 5f;
    [SerializeField] float _wallSpeed = 5f;
    [SerializeField] float _spawnPositionRange = 5f;

    float _fireTime;
    bool _canSpawn = true;

    private void Start()
    {
        _canSpawn = true;
        GameManager.Instance.OnPlayerDie += Instance_OnPlayerDie;
        GameManager.Instance.BulletHellStart += Instance_BulletHellStart;
    }

    private void Instance_BulletHellStart()
    {
        Kill();
    }

    private void Kill()
    {
        Destroy(gameObject);
    }

    private void Instance_OnPlayerDie()
    {
        _canSpawn = false;
    }

    private void Update()
    {
        if (_fireTime <= Time.time && _canSpawn)
        {
            SpawnWall();
             _fireTime = Time.time + _timeBetweenWalls;
        }

    }

    private void SpawnWall()
    {
        Debug.Log("Wall Spawned");
        Vector3 spawnPosition = FindSpawnPosition();                                                                                              
        var Wall = Instantiate(_wallPrefab, spawnPosition, Quaternion.identity);
        Wall.RB.velocity = Vector3.left * _wallSpeed;
    }

    private Vector3 FindSpawnPosition()
    {
        Vector3 spawnPosition = new Vector3(
            transform.position.x,                                                                                               //Spawn Position x
            UnityEngine.Random.Range(transform.position.y - _spawnPositionRange, transform.position.y + _spawnPositionRange),   //Spawn Position y
            transform.position.z);                                                                                              //Spawn Position z
        return spawnPosition;
    }
    private void OnDestroy()
    {
        GameManager.Instance.OnPlayerDie -= Instance_OnPlayerDie;
        GameManager.Instance.BulletHellStart -= Instance_BulletHellStart;
    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, Vector3.one);
    }

#endif
}
