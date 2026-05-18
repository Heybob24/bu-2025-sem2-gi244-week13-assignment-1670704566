using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    [Header("Pool")]
    public ObstacleObjectPool obstaclePool;

    [Header("Spawn Point")]
    public Transform spawnPoint;

    [Header("Spawn Setting")]
    public float spawnInterval = 2f;

    [Header("Obstacle Types")]
    public int obstacleTypeCount = 3;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnObstacle();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnObstacle()
    {
        
        int randomType = Random.Range(0, obstacleTypeCount);

        
        GameObject obstacle = obstaclePool.Acquire(randomType);

        if (obstacle == null) return;

        obstacle.transform.position = spawnPoint.position;
        obstacle.transform.rotation = Quaternion.identity;

        obstacle.SetActive(true);

    
        Obstacle obstacleScript = obstacle.GetComponent<Obstacle>();

        if (obstacleScript != null)
        {
            obstacleScript.obstacleType = randomType;
            obstacleScript.pool = obstaclePool;
        }
    }
}