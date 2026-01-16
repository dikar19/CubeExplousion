using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRadius = 0.3f;
    [SerializeField] private float chanceMultiplier = 0.5f;

    public Cube Spawn(Cube parent, Vector3 origin)
    {
        if (parent == null || parent.cubePrefab == null)
            return null;

        Vector3 spawnPos = origin + Random.insideUnitSphere * spawnRadius;

        Cube cube = Instantiate(
            parent.cubePrefab,
            spawnPos,
            Random.rotation
        );

        cube.transform.localScale = parent.transform.localScale * parent.scaleMultiplier;

        if (cube.TryGetComponent(out Renderer renderer))
            renderer.material.color = Random.ColorHSV();

        cube.splitChance = parent.splitChance * chanceMultiplier;

        return cube;
    }
}
