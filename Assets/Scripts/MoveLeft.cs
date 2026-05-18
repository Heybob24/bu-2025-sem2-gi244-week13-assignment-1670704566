using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // stop moving when game over
        GameObject player = GameObject.Find("Player");

        bool isGameOver =
            player.GetComponent<PlayerController>().gameOver;

        if (isGameOver)
        {
            speed = 0;
        }

        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // return obstacle to pool
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