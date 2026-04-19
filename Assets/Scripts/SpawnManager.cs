using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPoint;

    public ObstacleObjectPool pool; 

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, 2f);
    }

    void Spawn()
    {
        
        GameObject player = GameObject.Find("Player");
        bool isGameOver = player.GetComponent<PlayerController>().gameOver;

        if (isGameOver)
        {
            return;
        }

       
        int randomType = Random.Range(0, 3);

        
        GameObject obstacle = pool.Acquire(randomType);

        
        obstacle.transform.position = spawnPoint.position;
        obstacle.transform.rotation = Quaternion.identity;
        obstacle.GetComponent<MoveLeft>().obstacleType = randomType;
    }
}
