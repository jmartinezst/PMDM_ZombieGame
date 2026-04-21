using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AI;


public class PlayerHealth : MonoBehaviour
{
  
    MenuManager menuManager;
    float vidaInicial =100;
    float puntosSalud;

    public GameObject healthBarGO;
    Image barraSalud;

    AudioSource source;
    public AudioClip sonidoQueja;
    Animator anim;
    public GameObject animGO;
    


    void Awake()
    {
       
        healthBarGO = GameObject.FindGameObjectWithTag("HealthBar");
        menuManager = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<MenuManager>();
        source =  GetComponent<AudioSource>();
        anim = animGO.GetComponent<Animator>();
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
        anim.SetTrigger("golpeado");
        anim.ResetTrigger("golpeado");

        source.PlayOneShot(sonidoQueja);
        puntosSalud -= cantidad;
        actualizarBarraVida();
        if(puntosSalud <=0)
        {
            //detener agente

            GetComponent<NavMeshAgent>().speed=0;
            GetComponent<Collider>().enabled=false;
              anim.SetBool("estaVivo", false);
            Debug.Log("Has muerto");
            puntosSalud =0;
            menuManager.playerMuerto();
          
        }
    }

    public void sumarVida(int cantidad)
    {
        puntosSalud += cantidad;
        //asegurar a la vida maxima 
        if(puntosSalud > vidaInicial) puntosSalud = vidaInicial;
        actualizarBarraVida();
    }

    public void restablecerVida()
    {
        puntosSalud = vidaInicial;
        GetComponent<NavMeshAgent>().speed=3.5f;
            GetComponent<Collider>().enabled=true;
    }

    public void actualizarBarraVida()
    {
        float porcentaje = puntosSalud/vidaInicial;
        barraSalud.fillAmount = porcentaje;
    }

   


}
