using System;
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
        _currentLives = maxLives;
        _nextVulnerableStatus = Time.time;
        playerLivesUIText.text = maxLives.ToString();
    }
    
    private void Update()
    {
        if (_currentLives <= 0 && _isAlive)
        {
            TurnGhost();
            //@todo: Game over screen
        }
    }

    public void GetHit()
    {
        if (Time.time >= _nextVulnerableStatus)
        {
            _currentLives--;
            playerLivesUIText.text = _currentLives.ToString();
            Debug.Log("current lives are " + _currentLives);
            _nextVulnerableStatus = Time.time + delayBetweenHits;
        }
    }

    private void TurnGhost()
    {
        //Turn Ghost
        _isAlive = false;
        Destroy(this.gameObject, 0.5f);
        Instantiate(ghost, this.transform.position + Vector3.up, Quaternion.identity);
        //@todo: animation

        //@todo: Game over screen
    }

    private int _currentLives;
    private float _nextVulnerableStatus;
    private bool _canGetHit;
    private bool _isAlive = true;
}
