using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxLives = 3;
    [SerializeField] private float delayBetweenHits = 3f;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _currentLives = maxLives;
        _nextVulnerableStatus = Time.time;
    }
    
    public void GetHit()
    {
        if (Time.time >= _nextVulnerableStatus)
        {
            _currentLives--;
            //@Todo: Add UI HUD
            Debug.Log("current lives are " + _currentLives);
            _nextVulnerableStatus = Time.time + delayBetweenHits;
        }
    }

    public void TurnGhost()
    {
        //@todo: disable controls
        
        //change sprite 
        
        //@todo: animation
    }

    private int _currentLives;
    private float _nextVulnerableStatus;
    private bool _canGetHit;
    private SpriteRenderer _spriteRenderer;
}
