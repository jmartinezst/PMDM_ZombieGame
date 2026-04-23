using UnityEngine;

public class RecogibleSalud : MonoBehaviour
{



    void OnTriggerEnter(Collider other)
    {     
        if(other.gameObject.tag == "Player")
        {         
            other.gameObject.GetComponent<PlayerHealth>().sumarVida(20);
            Destroy(this.gameObject);
        }
    }
}