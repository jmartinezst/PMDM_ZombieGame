using UnityEngine;


//Clase para evitar la destruccion entre escenas.

public class DontDestroy : MonoBehaviour
{
    public string mitag ="";

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(mitag);

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

}