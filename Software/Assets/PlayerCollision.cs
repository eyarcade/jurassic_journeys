using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.onPlay.AddListener(ActivatePlayer);
    }

    private void ActivatePlayer()
    {
        gameObject.SetActive(true);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Obstacle")
        {
            gameObject.SetActive(false);
            GameManager.instance.GameOver();
        }
    }
}
