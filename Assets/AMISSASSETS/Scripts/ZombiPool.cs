using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;

public class ZombiPool : MonoBehaviour
{
    public static ZombiPool Instance;

    public Transform[] tumbas;
    public GameObject[] zombis;

    void Awake()
    {
        Instance = this;
    }


    public void GuardarZombi(GameObject zombi)
    {
       zombi.SetActive(false);
       zombi.transform.position = transform.position; 
       Invoke("SacarZombi", 3f);
    }

    public void SacarZombi()
    {
        foreach (GameObject zombi in zombis)
        {
            if (!zombi.activeInHierarchy)
            {
                
                int indiceTumba = Random.Range(0, tumbas.Length); 
                
                //coger el agente del zombi y teleportarlo al spawn
                zombi.GetComponent<UnityEngine.AI.NavMeshAgent>().Warp(tumbas[indiceTumba].position); 
                //revitalizar( dar velocidad al agente y marcar vivo para animacion)                  
                zombi.GetComponent<ZombiBrain>().restaurar();
                //activar
                zombi.SetActive(true);

                return; // Salimos para no despertar a todos a la vez
            }
        }
        
    }
}