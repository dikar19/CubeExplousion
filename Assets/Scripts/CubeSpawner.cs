using UnityEngine;

public static class CubeSpawner
{
    public static void Spawn(Cube parent, Vector3 origin)
    {
        Vector3 spawnPos = origin + Random.insideUnitSphere * 0.3f;

        GameObject cubeObj = Object.Instantiate(
            parent.cubePrefab,
            spawnPos,
            Random.rotation
        );

        cubeObj.transform.localScale = parent.transform.localScale * parent.scaleMultiplier;
        cubeObj.GetComponent<Renderer>().material.color = Random.ColorHSV();

        Cube cube = cubeObj.GetComponent<Cube>();
        cube.splitChance = parent.splitChance * 0.5f;

        Rigidbody rb = cubeObj.GetComponent<Rigidbody>();
        rb.AddExplosionForce(300f, origin, 2f);
    }
}
