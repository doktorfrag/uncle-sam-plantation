using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour{

    private static T _instance;

    public static T instance
    {
        get
        {
            //first check to see if instance does not already exist
            if (_instance == null)
            {
                //try to find instance in scene
                _instance = GameObject.FindObjectOfType<T>();

                if(_instance == null)
                {
                    //can't find object; create it
                    GameObject singleton = new GameObject(typeof(T).Name);
                    _instance = singleton.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    public virtual void Awake()
    {
        if(_instance == null)
        {
            //create singleton instance and ensure its persistence
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
        
    }
}
