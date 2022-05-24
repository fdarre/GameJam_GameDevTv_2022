using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(gameObject);
            SceneController.Instance.CompleteLevel(2f);
        }
    }

}
