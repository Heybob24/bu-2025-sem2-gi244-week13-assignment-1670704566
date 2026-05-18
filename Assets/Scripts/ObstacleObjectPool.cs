using System.Collections.Generic;
using UnityEngine;

public class ObstacleObjectPool : MonoBehaviour
{
    public GameObject obstacleBarrelPrefab;
    public GameObject obstacleBarrierPrefab;
    public GameObject obstacleStoneWallPrefab;
    public int poolSize = 10;

    private List<GameObject> ObstacleBarrelPool;
    private List<GameObject> ObstacleBarrierPool;
    private List<GameObject> ObstacleStoneWallPool;

    void Awake()
    {
        obstacleBarrelPool = new List<GameObject>();
        obstacleBarrierPool = new List<GameObject>();
        obstacleStoneWallPool = new List<GameObject>();
    }

    public GameObject Acquire(int obstacleType)
    {
        return null;
    }

    
    public void Release(GameObject obstacle, int obstacleType)
    {

    }
}
