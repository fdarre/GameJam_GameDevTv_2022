using UnityEngine;

public abstract class GenericSingleton<T> : MonoBehaviour where T : GenericSingleton<T>
{
    #region Singleton instance: static auto-property
    
    public static T Instance { get; private set; }

    #endregion
    
    #region Init

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = (T)this;
            Init();
            if (!DestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected abstract bool DestroyOnLoad { get; }

    protected abstract void Init();

    #endregion
}