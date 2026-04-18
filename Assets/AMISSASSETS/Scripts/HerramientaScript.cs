using UnityEngine;

public class HerramientaScript : MonoBehaviour
{

    AudioSource source;
    public AudioClip sonidoRecogida;

    public GameObject modeloLlave;

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
             modeloLlave.SetActive(false);
             Invoke("Apagar",1f);
            

        }
    }
    public void Apagar()
    {
        this.gameObject.SetActive(false);
    }
   
}
