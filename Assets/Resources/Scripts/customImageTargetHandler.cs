using UnityEngine;
using Vuforia;

public class CustomImageTargetHandler : MonoBehaviour
{
    // Referencia al script para obtener datos del target
    public TargetDataFetcher targetDataFetcher;

    void Start()
    {
        // Obtén el componente ObserverBehaviour del Image Target
        var observerBehaviour = GetComponent<ObserverBehaviour>();

        // Verifica que el componente exista y suscríbete al evento de cambios de estado
        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    // Método llamado cuando el estado del target cambia
    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        // Verifica si el target ha sido detectado
        if (targetStatus.Status == Status.TRACKED)
        {
            // Obtener el nombre del target directamente desde ObserverBehaviour
            string targetName = behaviour.TargetName;
            Debug.Log("Detected Target Name: " + targetName);

            // Llamar al método para obtener la información usando el nombre del target
            targetDataFetcher.FetchTargetInfo(targetName);
        }
    }
}
