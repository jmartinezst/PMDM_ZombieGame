using UnityEngine;
using UnityEngine.Events;

public class PlayerActions : MonoBehaviour
{
 
    AnimationManager anim;
    PlayerMovement playerMovement;
    public Transform spawnPoint;
    public AudioClip sonidoDisparo;
    AudioSource source;
    public GameObject muzzleFlash;


    void Awake()
    {
        anim = GetComponent<AnimationManager>();
        playerMovement = GetComponent<PlayerMovement>();
        source = GetComponent<AudioSource>();
        
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
            
            source.PlayOneShot(sonidoDisparo);

            muzzleFlash.SetActive(true);
            Invoke("DesactivarMuzzle",0.5f);

            // Al activarla, el script Bullet hará el resto
            bullet.SetActive(true);
        }
    }

    public void DesactivarMuzzle()
    {
        muzzleFlash.SetActive(false);
    }

    public void golpear()
    {
        Debug.Log("Golpeando");
        anim.atacar2();
    }


}
