using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxLives = 3;
    [SerializeField] private float delayBetweenHits = 2f;
    [SerializeField] private GameObject ghost;
    [SerializeField] private TextMeshProUGUI playerLivesUIText;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _currentLives = maxLives;
        _nextVulnerableStatus = Time.time;
        playerLivesUIText.text = maxLives.ToString();
    }
    
    private void Update()
    {
        if (_currentLives <= 0 && _isAlive)
        {
            TurnGhost();
            UIManager.Instance.LoadGameOverScreen();
        }
    }
    
    public void GetHit()
    {
        if (Time.time >= _nextVulnerableStatus)
        {
            _animator.SetTrigger(Hit);
            _currentLives--;
            playerLivesUIText.text = _currentLives.ToString();
            _nextVulnerableStatus = Time.time + delayBetweenHits;
        }
    }

    private void TurnGhost()
    {
        _isAlive = false;
        Destroy(this.gameObject, 0.5f);
        Instantiate(ghost, this.transform.position + Vector3.up, Quaternion.identity);
    }

    private int _currentLives;
    private float _nextVulnerableStatus;
    private bool _canGetHit;
    private bool _isAlive = true;
    private Animator _animator;
    private static readonly int Hit = Animator.StringToHash("Hit");
}
