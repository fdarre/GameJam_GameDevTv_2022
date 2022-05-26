using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _currentHealth = maxHealth;
    }

    private void Update()
    {
        if (_currentHealth <= 0)
        {
            Destroy(this.gameObject, 1f);
        }
    }

    public void TakeDamage()
    {
        _currentHealth--;
        _animator.SetTrigger(Hit);
    }

    private Animator _animator;
    private static readonly int Hit = Animator.StringToHash("Hit");
    private int _currentHealth;
}
