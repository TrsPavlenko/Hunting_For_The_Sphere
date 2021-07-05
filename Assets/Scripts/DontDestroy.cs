using UnityEngine;


/*
 * Скрипт заборони знищення
 */



public class DontDestroy : MonoBehaviour
{
    public static bool loaded;

    void Awake()
    {
        if (!loaded)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
        loaded = true;
    }
}
