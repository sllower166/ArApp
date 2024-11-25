using UnityEngine;
using TMPro; // Si usas TextMeshPro

public class DataDisplayer : MonoBehaviour
{
    public TextMeshProUGUI textDisplay; // Asigna aquí el componente de texto del Canvas
    public Transform object3D; // El objeto 3D asociado al Image Target

    // Método para actualizar la información
    public void UpdateData(string data)
    {

        textDisplay.text = data;

    }
}
