using UnityEngine;

public class Cube : MonoBehaviour
{
    [Header("Data")]
    public GameObject cubePrefab;  
    public float splitChance = 1f; 

    [Header("Scale")]
    public float minScale = 0.2f; 
    public float scaleMultiplier = 0.5f;
}
