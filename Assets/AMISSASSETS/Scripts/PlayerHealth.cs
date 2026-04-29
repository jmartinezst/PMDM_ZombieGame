using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AI;


public class PlayerHealth : MonoBehaviour
{
  
    MenuManager menuManager;
    public float vidaInicial =100;
    float puntosSalud;

    public GameObject healthBarGO;
    Image barraSalud;

    AudioSource source;
    public AudioClip sonidoQueja;
    PlayerAnimation anim;
   
    


    void Awake()
    {
       
        healthBarGO = GameObject.FindGameObjectWithTag("HealthBar");
        menuManager = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<MenuManager>();
        source =  GetComponent<AudioSource>();
        anim = GetComponent<PlayerAnimation>();
        barraSalud = healthBarGO.GetComponent<Image>(); 
        if(barraSalud == null)
        {
            Debug.LogWarning("No detecto HealthBar");
        }
    }
    void Start()
    {
         restablecerVida();
    }

    public void restarVida(int cantidad)
    {
        anim.sufrir();

        source.PlayOneShot(sonidoQueja);
        puntosSalud -= cantidad;
        actualizarBarraVida();
        if(puntosSalud <=0)
        {
            //detener agente

            GetComponent<NavMeshAgent>().enabled=false;
            GetComponent<Collider>().enabled=false;
            anim.morir();
            Debug.Log("Has muerto");
            puntosSalud =0;
            menuManager.playerMuerto();
          
        }
    }

    public void sumarVida(int cantidad)
    {
        puntosSalud += cantidad;
        if(puntosSalud > vidaInicial)
        { 
            puntosSalud = vidaInicial;
        }
        actualizarBarraVida();
    }

    public void restablecerVida()
    {
        puntosSalud = vidaInicial;
        actualizarBarraVida();
        GetComponent<NavMeshAgent>().enabled=true;
        GetComponent<Collider>().enabled=true;
        anim.revivir();
    }

    public void actualizarBarraVida()
    {
        float porcentaje = puntosSalud/vidaInicial;
        barraSalud.fillAmount = porcentaje;
    }

   


}
