using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CanvasRoll : MonoBehaviour
{
    public ScrollRect scrollRect;
    public float velocidad = 0.05f;
    private bool ejecutando = false;

    void Awake()
    {
        if (scrollRect == null) scrollRect = GetComponent<ScrollRect>();
    }

    void OnEnable()
    {
        if(SceneManager.GetActiveScene().buildIndex ==3)
        // Reseteamos todo al activar
        ejecutando = false;
        if (scrollRect != null)
        {
            scrollRect.verticalNormalizedPosition = 1f;
            StartCoroutine(PrepararScroll());
        }
    }

    IEnumerator PrepararScroll()
    {
        // Esperamos un momento a que la UI se auto-ajuste
        yield return new WaitForEndOfFrame();
        
        // FORZAMOS el recálculo de la altura del Content
        LayoutRebuilder.ForceRebuildLayoutImmediate(scrollRect.content);
        
        yield return new WaitForSeconds(0.5f); // Pausa estética antes de empezar
        
        scrollRect.verticalNormalizedPosition = 1f; // Aseguramos que empiece arriba
        ejecutando = true;
    }

    void Update()
    {
        if (ejecutando && scrollRect != null)
        {
            scrollRect.verticalNormalizedPosition -= velocidad * Time.deltaTime;

            if (scrollRect.verticalNormalizedPosition <= 0f)
            {
                scrollRect.verticalNormalizedPosition = 0f;
                ejecutando = false;
                OnFinalizarCreditos();
            }
        }
    }

    void OnFinalizarCreditos() => Debug.Log("Créditos terminados");
}