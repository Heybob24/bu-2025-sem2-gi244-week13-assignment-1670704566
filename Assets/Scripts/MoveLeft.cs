using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        
        GameObject player = GameObject.Find("Player");

        bool isGameOver =
            player.GetComponent<PlayerController>().gameOver;

        if (isGameOver)
        {
            speed = 0;
        }

        transform.Translate(Vector3.left * speed * Time.deltaTime);

        
        if (transform.position.x < -15 &&
            gameObject.CompareTag("Obstacle"))
        {
            Obstacle obstacle = GetComponent<Obstacle>();

            if (obstacle != null)
            {
                obstacle.ReleaseObstacle();
            }
        }
    }
}