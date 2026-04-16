using UnityEngine;

public class DamageScript : MonoBehaviour
{



    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Algo entro");
        if(other.gameObject.tag == "Player")
        {
             Debug.Log("Es el player");
            other.gameObject.GetComponent<PlayerHealth>().restarVida(20);


        }
    }
}
