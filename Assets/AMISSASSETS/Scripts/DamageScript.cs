using UnityEngine;

public class DamageScript : MonoBehaviour
{



    void OnTriggerEnter(Collider other)
    {     
        if(other.gameObject.tag == "Player")
        {         
            other.gameObject.GetComponent<PlayerHealth>().restarVida(20);
        }
    }
}
