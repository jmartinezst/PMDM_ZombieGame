using System.Collections;
using UnityEngine;

public class AnimationManager : MonoBehaviour
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



[ContextMenu("ANDA")]
    public void andar()
    {
        anim.SetBool("estaAndando",true);
    }
[ContextMenu("PARA")]
    public void parar()
    {
        anim.SetBool("estaAndando",false);
    }


   [ContextMenu("VIVE")]
    public void revivir()
    {
         anim.SetBool("estaVivo",true);
    }
    [ContextMenu("MUERE")]
    public void morir()
    {
        anim.SetBool("estaVivo",false);
    }


[ContextMenu("SUFRE")]
     public void sufrir()
    {
        StartCoroutine(enciendeYApaga("sufriendo"));
    }
    [ContextMenu("ATACA1")]
    public void atacar1()
    {
        StartCoroutine(enciendeYApaga("atacando1"));
    }
    [ContextMenu("ATACA2")]
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
