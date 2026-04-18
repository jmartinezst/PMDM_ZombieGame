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
private bool estaVivo;

private NavMeshAgent agente;


    void Awake()
    {      
        anim = animGO.GetComponent<Animator>();
        source= GetComponent<AudioSource>();
        modoAtaque = GetComponent<Zombi_Ataque>();
        modoPatrulla = GetComponent<Zombi_Patrulla>();
        agente = GetComponent<NavMeshAgent>();
    }



    void Start()
    {
        StartCoroutine("DetectionRoutine");
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
            // SphereCast o CheckSphere para ver si el jugador está cerca
            bool detectarJugador = Physics.CheckSphere(transform.position, 5f, playerLayer);

            if (detectarJugador)
            {
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
        GetComponent<Zombi_Patrulla>().detenerAgente();
        //sonido muerte
        source.PlayOneShot(sonidoMuerte);
        //animacion muerte
        anim.SetBool("estaVivo",false);
        //Efecto muerte
        activaEfectoMuerte();
   
    }

    public void restaurar()
    {
        GetComponent<Zombi_Patrulla>().reanudarAgente();
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
    
    
}
