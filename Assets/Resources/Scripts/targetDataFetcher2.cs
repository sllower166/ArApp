using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

public class TargetDataFetcher1 : MonoBehaviour
{
    private string apiUrl = "https://arbackend-u6ka.onrender.com/api/sensors/671109ed2070d65cab7b485a";

    public void FetchTargetInfo()
    {
        GetTargetInfo();
    }

    private IEnumerator GetTargetInfo()
    {
         Debug.Log("Hola");
        UnityWebRequest request = UnityWebRequest.Get(apiUrl );
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
        Debug.Log("Error fetching data: " + sensorResponse.message);
        }
        else
        {
            Debug.LogError("Error fetching data: " + request.error);
        }
    }
}
