using UnityEngine;

public class ColorUpdater : MonoBehaviour
{
    // Objetos principales R, S, T (contenedores)
    public GameObject objectR;
    public GameObject objectS;
    public GameObject objectT;

    // Método para actualizar los colores de los objetos internos
    public void UpdateObjectColors(float distanceR, float distanceS, float distanceT)
    {
        // Cambiar colores de los primeros tres objetos dentro de R, S y T
        UpdateInternalObjectColors(objectR, distanceR);
        UpdateInternalObjectColors(objectS, distanceS);
        UpdateInternalObjectColors(objectT, distanceT);
    }

    // Método para cambiar el color de los primeros tres objetos internos dentro de un contenedor
    private void UpdateInternalObjectColors(GameObject parentObject, float distance)
    {
        // Obtenemos los objetos hijos del contenedor (asumimos que los primeros tres son los que deben cambiar de color)
        Transform[] internalObjects = parentObject.GetComponentsInChildren<Transform>();

        // Asegurarse de que haya al menos tres objetos internos para modificar
        int limit = Mathf.Min(3, internalObjects.Length);

        // Cambiar el color de los primeros tres objetos internos basados en la distancia
        for (int i = 1; i < limit + 1; i++) // Comenzamos desde 1 para evitar el propio contenedor
        {
            Renderer objRenderer = internalObjects[i].GetComponent<Renderer>();
            if (objRenderer != null)
            {
                // Establecer el color predeterminado (verde)
                Color color = Color.green;

                // Cambiar el color según la distancia
                if (distance >= 31 && distance <= 50)
                {
                    // Rojo solo para el primer objeto
                    if (i == 1)
                        color = Color.red;
                }
                else if (distance >= 51 && distance <= 70)
                {
                    // Rojo para los dos primeros objetos
                    if (i == 1 || i == 2)
                        color = Color.red;
                }
                else if (distance > 71)
                {
                    // Rojo para los tres objetos
                    color = Color.red;
                }

                // Aplicar el color al material del objeto
                objRenderer.material.color = color;
            }
        }
    }
}
