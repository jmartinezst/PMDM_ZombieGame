using UnityEngine;

public class PlayerInventario : MonoBehaviour
{
   int herramientasRecogidas = 0;



   public void sumaHerramientaRecogida()
    {
        herramientasRecogidas +=1;
    }

    public int getHerramientasRecogidas()
    {
        return herramientasRecogidas;
    }
}
