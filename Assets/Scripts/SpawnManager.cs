using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    [Header("Pool")]
    public ObstacleObjectPool obstaclePool;

    [Header("Spawn Point")]
    public Transform spawnPoint;
    public GameObject obstaclePrefab;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        // 1.18 stop moving left when the game is over
        GameObject player = GameObject.Find("Player");
        bool isGameOver = player.GetComponent<PlayerController>().gameOver;
        if (isGameOver)
        {
            return;
        }

        Instantiate(
            obstaclePrefab,
            spawnPoint.position,
            obstaclePrefab.transform.rotation
        );
    }
}