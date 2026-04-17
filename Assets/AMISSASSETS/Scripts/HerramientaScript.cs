using UnityEngine;

public class HerramientaScript : MonoBehaviour
{

    AudioSource source;
    public AudioClip sonidoRecogida;

    void Awake()
    {
        source= GetComponent<AudioSource>();
    }


     void OnTriggerEnter(Collider other)
    {
     
        if(other.gameObject.tag == "Player")
        {
          
             other.gameObject.GetComponent<PlayerInventario>().sumaHerramientaRecogida();
             source.PlayOneShot(sonidoRecogida);

            this.gameObject.SetActive(false);

        }
    }
   
}
