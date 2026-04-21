using System.Collections;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ZombiBrain : MonoBehaviour
{


Animator anim;
public GameObject animGO;

Zombi_Patrulla modoPatrulla;
Zombi_Ataque modoAtaque;
public LayerMask playerLayer;

AudioSource source;
public AudioClip sonidoMuerte;
public AudioClip sonidoAtaque;
public GameObject goopFX;
private bool estaVivo=true;

public GameObject recogibleCorazon;

private NavMeshAgent agente;


    void Awake()
    {      
        anim = animGO.GetComponent<Animator>();
        source= GetComponent<AudioSource>();
        modoAtaque = GetComponent<Zombi_Ataque>();
        modoPatrulla = GetComponent<Zombi_Patrulla>();
        agente = GetComponent<NavMeshAgent>();
    }



    void OnEnable()
    {   
        StartCoroutine(DetectionRoutine());
    }

    void OnDisable()
    {
        StopAllCoroutines(); 
    } 
    void Update()
    {
        if(agente.velocity != Vector3.zero)
        {
            anim.SetBool("estaAndando", true);
        }
        else
        {
            anim.SetBool("estaAndando", false);
        }
    }


   IEnumerator DetectionRoutine()
    {
        while (estaVivo)
        {
            Debug.Log("Rutina start");

            // SphereCast o CheckSphere para ver si el jugador está cerca
            bool detectarJugador = Physics.CheckSphere(transform.position, 20f, playerLayer);

            if (detectarJugador)
            {
                Debug.Log("detectado player por sfera zombi");
                // Cambiar a Persecución
                modoPatrulla.enabled = false;
                modoAtaque.enabled = true;
            }
            else
            {
                // Volver a Patrulla
                modoAtaque.enabled = false;
                modoPatrulla.enabled = true;
            }

            yield return new WaitForSeconds(2f);
        }
    }
    public void morir()
    {
        //detener movimiento
        GetComponent<NavMeshAgent>().speed=0;
        //sonido muerte
        source.PlayOneShot(sonidoMuerte);
        //animacion muerte
        anim.SetBool("estaVivo",false);
        //Efecto muerte
        activaEfectoMuerte();

        InstanciaCorazon();
   
    }

    public void restaurar()
    {
      Zombi_Patrulla patrol=   GetComponent<Zombi_Patrulla>();
      patrol.enabled =true;
      patrol.reanudarAgente();
      
        anim.SetBool("estaVivo",true);
    }

    public void activaEfectoMuerte()
    {
        goopFX.SetActive(true);
        Invoke("desactivaEfectoMuerte", 1f);

    }
    public void desactivaEfectoMuerte()
    {
        goopFX.SetActive(false);
        ZombiPool.Instance.GuardarZombi(this.gameObject);
    }

    public void InstanciaCorazon()
    {
        GameObject clon = Instantiate(recogibleCorazon);
        clon.transform.position = transform.position;
        clon.SetActive(true);
    }
    
    
}
