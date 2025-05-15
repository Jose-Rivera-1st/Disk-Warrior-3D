using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public int shooterPlayer; 
    private LivesManager livesManager;

    void Start()
    {
        livesManager = FindFirstObjectByType<LivesManager>();
    }

    private void OnTriggerEnter(Collider other)
    {

    Debug.Log("Bullet hit: " + other.name);

        if (shooterPlayer == 1 && other.CompareTag("Player2"))
        {
            livesManager.DamagePlayer(2);
            Destroy(gameObject);
        }
        else if (shooterPlayer == 2 && other.CompareTag("Player1"))
        {
            livesManager.DamagePlayer(1);
            Destroy(gameObject);
        }
    }
}