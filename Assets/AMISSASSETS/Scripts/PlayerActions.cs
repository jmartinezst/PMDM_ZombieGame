using UnityEngine;
using UnityEngine.Events;

public class PlayerActions : MonoBehaviour
{
 
    AnimationManager anim;
    PlayerMovement playerMovement;
    public Transform spawnPoint;


    void Awake()
    {
        anim = GetComponent<AnimationManager>();
        playerMovement = GetComponent<PlayerMovement>();
        
    }

    void OnEnable()
    {
        // El Player se pega al evento del MenuManager al nacer
        MenuManager.OnAccion1.AddListener(disparar);
        MenuManager.OnAccion2.AddListener(golpear);
    }

    void OnDisable()
    {
        // Se despega al morir o cambiar de escena
        MenuManager.OnAccion1.RemoveListener(disparar);
        MenuManager.OnAccion2.RemoveListener(golpear);
    }

    public void disparar()
    {
        Debug.Log("Disparando");
        Vector3 direccion = playerMovement.getDireccion();
        anim.atacar1();

        GameObject bullet = PoolBalas.Instance.sacarBala();
        
        if (bullet != null)
        {
            // Posicionamos y rotamos la bala ANTES de activarla
            bullet.transform.position = spawnPoint.position;
            bullet.transform.rotation = spawnPoint.rotation;
            
            // Al activarla, el script Bullet hará el resto
            bullet.SetActive(true);
        }
    }

    public void golpear()
    {
        Debug.Log("Golpeando");
        anim.atacar2();
    }


}
