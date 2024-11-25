using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class TargetDataFetcher : MonoBehaviour
{
    public DataDisplayer dataDisplayer;  // Para actualizar el texto
    public ColorUpdater colorUpdater;    // Para actualizar los colores de los objetos
    private string apiUrl = "https://arbackend-u6ka.onrender.com/api/sensors/";

    public void FetchTargetInfo(string targetId)
    {
        StartCoroutine(GetTargetInfo(targetId));
    }

    private IEnumerator GetTargetInfo(string targetId)
    {
        UnityWebRequest request = UnityWebRequest.Get(apiUrl + targetId);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            // Deserializa el JSON en un objeto SensorResponse
            string jsonResult = request.downloadHandler.text;
            Debug.Log("Data retrieved: " + jsonResult);

            // Deserializamos el JSON en un objeto SensorResponse
            SensorResponse sensorResponse = JsonUtility.FromJson<SensorResponse>(jsonResult);

            // Accede a las distancias
            float distanceR = sensorResponse.distances.distancia_R;
            float distanceS = sensorResponse.distances.distancia_S;
            float distanceT = sensorResponse.distances.distancia_T;

            // Actualiza la UI con el mensaje
            dataDisplayer.UpdateData(sensorResponse.message);

            // Pasa las distancias al script ColorUpdater para cambiar los colores
            colorUpdater.UpdateObjectColors(distanceR, distanceS, distanceT);
        }
        else
        {
            dataDisplayer.UpdateData("Error obteniendo información");
            Debug.LogError("Error fetching data: " + request.error);
        }
    }
}
