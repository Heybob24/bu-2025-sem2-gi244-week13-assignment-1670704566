using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [HideInInspector]
    public int obstacleType;

    [HideInInspector]
    public ObstacleObjectPool pool;

    void Update()
    {
        
        if (transform.position.x < -20f)
        {
            ReleaseObstacle();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            PlayerController player =
                other.GetComponent<PlayerController>();

            if (player != null)
            {
                player.gameOver = true;
            }

            
            ReleaseObstacle();
        }
    }

    public void ReleaseObstacle()
    {
        if (pool != null)
        {
            pool.Release(gameObject, obstacleType);
        }
    }
}