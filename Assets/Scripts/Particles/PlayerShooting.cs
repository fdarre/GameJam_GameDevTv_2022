using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject particlePrefab;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform particleStartPosition;

    public void FireParticle(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            InstantiateParticle();
        }
    }

    private void InstantiateParticle()
    {
        Instantiate<GameObject>(particlePrefab, particleStartPosition.position, Quaternion.identity, parent);
    }
}
