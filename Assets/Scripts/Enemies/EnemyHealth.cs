using UnityEngine;

namespace Enemies
{
    public class EnemyHealth : MonoBehaviour
    {
        #region Serialized in Inspector

        [SerializeField] private int maxHealth;
        [SerializeField] private AudioClip hitSoundFx;

        #endregion

        #region Public Methods

        public void TakeDamage()
        {
            _currentHealth--;
            _audioSource.PlayOneShot(hitSoundFx);
            _animator.SetTrigger(Hit);
        }

        #endregion

        #region Init

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _animator = GetComponentInChildren<Animator>();
            _currentHealth = maxHealth;
        }

        #endregion

        #region Update

        private void Update()
        {
            if (_currentHealth <= 0)
            {
                _animator.SetTrigger(Die);
                Destroy(this.gameObject, 0.3f);
            }
        }

        #endregion

        #region Private Variables
    
        private static readonly int Die = Animator.StringToHash("Die");
        private static readonly int Hit = Animator.StringToHash("Hit");
        private int _currentHealth;
        private Animator _animator;
        private AudioSource _audioSource;

        #endregion
    }
}
