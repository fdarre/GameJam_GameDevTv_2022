using Scene;
using UnityEngine;

namespace Collectibles
{
    public class Feather : MonoBehaviour
    {
        #region Collisions

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                Destroy(gameObject);
                SceneController.Instance.CompleteLevel(2f);
            }
        }

        #endregion
    }
}

