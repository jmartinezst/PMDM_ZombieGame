using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public GameObject animGO;
    Animator anim;

    AudioSource source;
    public AudioClip sonidoDisparo;
    public AudioClip sonidoDolor;
    public AudioClip sonidoMuerte;


    void Awake()
    {
        anim = animGO.GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }




    public void andar()
    {
        anim.SetBool("estaAndando",true);
    }

    public void parar()
    {
        anim.SetBool("estaAndando",false);
    }

    public void revivir()
    {
         anim.SetBool("estaVivo",true);
    }
  
    public void morir()
    {
        anim.SetBool("estaVivo",false);
    }

     public void sufrir()
    {
        StartCoroutine(enciendeYApaga("golpeado"));
    }

    public void atacar1()
    {
        StartCoroutine(enciendeYApaga("atacando1"));
    }
 
    public void atacar2()
    {
        StartCoroutine(enciendeYApaga("atacando2"));
    }

    IEnumerator enciendeYApaga (string trigger)
    {
   
        anim.SetTrigger(trigger);
        yield return new WaitForSeconds(0.5f);
        anim.ResetTrigger(trigger);
    
    }
}
