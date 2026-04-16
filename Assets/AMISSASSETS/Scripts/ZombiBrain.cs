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
        //sonido muerte
        source.PlayOneShot(sonidoMuerte);
        //animacion muerte

        //Efecto muerte
        activaEfectoMuerte();

        //desactivar
        anim.SetTrigger("Muerto");
        
    }

    public void activaEfectoMuerte()
    {
        goopFX.SetActive(true);
        Invoke("desactivaEfectoMuerte", 1f);

    }
    public void desactivaEfectoMuerte()
    {
        goopFX.SetActive(false);

    }
    
    
}
