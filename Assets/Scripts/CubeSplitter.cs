using UnityEngine;

public class CubeSplitter : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private CubeSpawner spawner;
    [SerializeField] private CubeExploder exploder;
    [SerializeField] private int minSpawnCount = 2;
    [SerializeField] private int maxSpawnCount = 6;

    private void Awake()
    {
        if (inputReader == null)
            inputReader = FindFirstObjectByType<InputReader>();
        if (spawner == null)
            spawner = FindFirstObjectByType<CubeSpawner>();
        if (exploder == null)
            exploder = FindFirstObjectByType<CubeExploder>();
    }

    private void OnEnable()
    {
        if (inputReader != null)
            inputReader.CubeHit += HandleCubeHit;
    }

    private void OnDisable()
    {
        if (inputReader != null)
            inputReader.CubeHit -= HandleCubeHit;
    }

    private void HandleCubeHit(Cube cube)
    {
        int count = Random.Range(minSpawnCount, maxSpawnCount + 1);
        Vector3 origin = cube.transform.position;

        if (cube == null || spawner == null || exploder == null)
            return;

        if (cube.transform.localScale.x <= cube.minScale)
        {
            Destroy(cube.gameObject);
            return;
        }

        if (Random.value > cube.splitChance)
        {
            Destroy(cube.gameObject);
            return;
        }

        for (int i = 0; i < count; i++)
        {
            Cube child = spawner.Spawn(cube, origin);
            if (child == null)
                continue;

            exploder.Explode(child.GetComponent<Rigidbody>(), origin);
        }

        Destroy(cube.gameObject);
    }
}
