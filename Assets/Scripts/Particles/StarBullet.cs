using System;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class StarBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Start()
    {
        _playerTransformForwardZ = GameObject.FindGameObjectWithTag("Player").transform.forward.z;
    }

    private void Update()
    {
        _transform.Translate(new Vector3(_playerTransformForwardZ * bulletSpeed * Time.deltaTime, 0, 0));
    }

    private Transform _transform;
    private float _playerTransformForwardZ;
}
