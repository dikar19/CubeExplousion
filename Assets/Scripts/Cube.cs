using UnityEngine;

public class Cube : MonoBehaviour
{
    [Header("Data")]
    public GameObject cubePrefab;  
    public float splitChance = 1f; 

    [Header("Scale")]
    public float minScale = 0.2f; 
    public float scaleMultiplier = 0.5f;

    [Header("Explosion")]
    public float explosionForce = 100f;
    public float explosionRadius = 2.5f;
    public float explosionUpward = 0.1f;
    public LayerMask explosionMask = 0;
}
