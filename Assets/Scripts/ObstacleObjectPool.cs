using System.Collections.Generic;
using UnityEngine;

public class ObstacleObjectPool : MonoBehaviour
{
    public GameObject ObstacleBarrelPrefab;
    public GameObject ObstacleBarrierPrefab;
    public GameObject ObstacleStoneWallPrefab;

    public int poolSize = 10;

    private List<GameObject> ObstacleBarrelPool;
    private List<GameObject> ObstacleBarrierPool;
    private List<GameObject> ObstacleStoneWallPool;

    void Awake()
    {
        ObstacleBarrelPool = new List<GameObject>();
        ObstacleBarrierPool = new List<GameObject>();
        ObstacleStoneWallPool = new List<GameObject>();

        
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(ObstacleBarrelPrefab);

            obj.SetActive(false);

            ObstacleBarrelPool.Add(obj);
        }

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(ObstacleBarrierPrefab);

            obj.SetActive(false);

            ObstacleBarrierPool.Add(obj);
        }

        
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(ObstacleStoneWallPrefab);

            obj.SetActive(false);

            ObstacleStoneWallPool.Add(obj);
        }
    }

    public GameObject Acquire(int obstacleType)
    {
        List<GameObject> selectedPool = GetPool(obstacleType);

        if (selectedPool == null)
        {
            return null;
        }

        for (int i = 0; i < selectedPool.Count; i++)
        {
            if (!selectedPool[i].activeInHierarchy)
            {
                return selectedPool[i];
            }
        }

        
        GameObject prefab = GetPrefab(obstacleType);

        GameObject newObj = Instantiate(prefab);

        newObj.SetActive(false);

        selectedPool.Add(newObj);

        return newObj;
    }

    public void Release(GameObject obstacle, int obstacleType)
{
    obstacle.SetActive(false);
}

    List<GameObject> GetPool(int obstacleType)
    {
        switch (obstacleType)
        {
            case 0:
                return ObstacleBarrelPool;

            case 1:
                return ObstacleBarrierPool;

            case 2:
                return ObstacleStoneWallPool;

            default:
                return null;
        }
    }

    GameObject GetPrefab(int obstacleType)
    {
        switch (obstacleType)
        {
            case 0:
                return ObstacleBarrelPrefab;

            case 1:
                return ObstacleBarrierPrefab;

            case 2:
                return ObstacleStoneWallPrefab;

            default:
                return null;
        }
    }
}