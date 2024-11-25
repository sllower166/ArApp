[System.Serializable]
public class SensorResponse
{
    public bool ok;
    public string message;
    public Distances distances;

    [System.Serializable]
    public class Distances
    {
        public float distancia_R;
        public float distancia_S;
        public float distancia_T;
    }
}
