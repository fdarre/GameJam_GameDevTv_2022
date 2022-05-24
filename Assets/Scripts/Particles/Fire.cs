using System;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private GameObject particlePrefab;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform particleStartPosition;

    private void Start()
    {
        InstantiateParticle();
    }

    public void InstantiateParticle()
    {
        Instantiate<GameObject>(particlePrefab, particleStartPosition.position, Quaternion.identity, parent);
    }
}
