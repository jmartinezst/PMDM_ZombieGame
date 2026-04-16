using System.Collections.Generic;
using UnityEngine;

public class PoolBalas : MonoBehaviour
{
    public static PoolBalas Instance; 
    public GameObject prefabBala;
    public int poolSize = 20;
    
    private List<GameObject> poolBalas;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        poolBalas = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject clon = Instantiate(prefabBala);
            clon.SetActive(false); // Empezan dormidas
            poolBalas.Add(clon);
        }
    }

    public GameObject sacarBala()
    {
        // 1. Buscamos una bala que no esté activa
        for (int i = 0; i < poolBalas.Count; i++)
        {
            if (!poolBalas[i].activeInHierarchy)
            {
                return poolBalas[i];
            }
        }
        // 2. Opcional: Si el pool se queda corto, creamos una nueva
        GameObject newObj = Instantiate(prefabBala);
        newObj.SetActive(false);
        poolBalas.Add(newObj);
        return newObj;
    }
}