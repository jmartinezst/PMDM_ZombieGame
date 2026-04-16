using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class ZombiBrain : MonoBehaviour
{


Animator anim;
public GameObject animGO;

AudioSource source;
public AudioClip sonidoMuerte;
public AudioClip sonidoAtaque;

public GameObject goopFX;


    void Awake()
    {
        
        anim = animGO.GetComponent<Animator>();
        source= GetComponent<AudioSource>();



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
