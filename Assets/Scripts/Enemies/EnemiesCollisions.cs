using UnityEngine;

public class EnemiesCollisions : MonoBehaviour
{
    private void Start()
    {
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            _playerHealth.GetHit();
        }
    }
    
    private PlayerHealth _playerHealth;
}
