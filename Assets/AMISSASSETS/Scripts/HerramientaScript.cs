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
        Debug.Log("Algo entro");
        if(other.gameObject.tag == "Player")
        {
             Debug.Log("Es el player");
             other.gameObject.GetComponent<PlayerInventario>().sumaHerramientaRecogida();
             source.PlayOneShot(sonidoRecogida);

            this.gameObject.SetActive(false);

        }
    }
   
}
