using UnityEngine;
using UnityEngine.AI;

public class Zombi_Ataque : MonoBehaviour
{

    private NavMeshAgent agente;
    

    public float rangoAtaque = 1.5f; // Distancia para empezar a atacar

    public float recargaAtaque = 1.5f; // Segundos entre ataques
    private float contadorRecargaActual = 0f;
    
    private Animator anim;
    private ZombiBrain brain;
    private GameObject playerTarget;

    void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        brain = GetComponent<ZombiBrain>();
        anim = brain.animGO.GetComponent<Animator>();
        playerTarget = GameObject.FindGameObjectWithTag("Player");
        
    }

   

    void Update()
    {
        if (playerTarget == null || !agente.enabled) return;

        // 1. Perseguir al jugador
        agente.destination = playerTarget.transform.position;

        // 2. Comprobar si estamos a distancia de ataque
        float distancia = Vector3.Distance(transform.position, playerTarget.transform.position);

        if (distancia <= rangoAtaque)
        {
            Atacar();
        }
    }

    void Atacar()
    {
        // Solo ataca si ha pasado el tiempo de enfriamiento (cooldown)
        if (Time.time >= contadorRecargaActual)
        {
            // Ejecutar animación de ataque (asegurate de tener el trigger "atacar" en tu Animator)
            anim.SetTrigger("atacando1");
            
            // Reproducir sonido de ataque desde el Brain
           
            //dañar al player
            playerTarget.GetComponent<PlayerHealth>().restarVida(20);

            contadorRecargaActual = Time.time + recargaAtaque;
            Debug.Log("¡Zombi atacando!");
        }
    }
  
}