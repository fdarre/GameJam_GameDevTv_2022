using UnityEngine;
using UI;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        #region Serialized in Inspector

        [SerializeField] private int maxLives = 3;
        [SerializeField] private float delayBetweenHits = 2f;
        [SerializeField] private AudioClip hitSoundFx;
        [SerializeField] private AudioClip deathSoundFx;
        [SerializeField] private GameObject ghostPrefab;
        [SerializeField] private PlayerLives playerLiveComponent;
        

        #endregion
        
        #region Public Methods

        public void GetHit()
        {
            if (Time.time >= _nextVulnerableStatus)
            {
                _animator.SetTrigger(Hit);
                _audioSource.PlayOneShot(hitSoundFx);
                _currentLives--;
                playerLiveComponent.SetPlayerLives(_currentLives);
                _nextVulnerableStatus = Time.time + delayBetweenHits;
            }
        }

        #endregion

        #region Init

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _audioSource = GetComponentInChildren<AudioSource>();
            _currentLives = maxLives;
            _nextVulnerableStatus = Time.time;
            
        }

        private void Start()
        {
            playerLiveComponent.SetPlayerLives(maxLives);
        }

        #endregion

        #region Update

        private void Update()
        {
            if (_currentLives <= 0 && _isAlive)
            {
                _audioSource.PlayOneShot(deathSoundFx);
                TurnGhost();
                UIManager.Instance.LoadGameOverScreen();
            }
        }

        #endregion

        #region Private Methods

        private void TurnGhost()
        {
            _isAlive = false;
            Destroy(this.gameObject, 0.5f);
            Instantiate(ghostPrefab, this.transform.position + Vector3.up, Quaternion.identity);
        }

        #endregion

        #region Private Variables
        
        private static readonly int Hit = Animator.StringToHash("Hit");
        private int _currentLives;
        private float _nextVulnerableStatus;
        private bool _canGetHit;
        private bool _isAlive = true;
        private Animator _animator;
        private AudioSource _audioSource;

        #endregion
    }
}
