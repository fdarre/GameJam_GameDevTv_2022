using UnityEngine;

namespace Generic
{
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
                
                /*
                if (!DestroyOnLoad)
                {
                    DontDestroyOnLoad(gameObject);
                }
                */
            }
            else
            {
                Destroy(gameObject);
            }
        }

        //protected abstract bool DestroyOnLoad { get; }

        #endregion
    }
}