using UnityEngine;

public class CubeSplitter : MonoBehaviour
{
    public void TrySplit(Cube cube)
    {
        int count = Random.Range(2, 7);
        Vector3 origin = transform.position;

        bool shouldSplit = transform.localScale.x > cube.minScale
            && Random.value <= cube.splitChance;

        if (shouldSplit)
        {
            for (int i = 0; i < count; i++)
            {
                CubeSpawner.Spawn(cube, origin);
            }
        }

        ApplyExplosion(cube, origin);
        Destroy(gameObject);
    }

    private void ApplyExplosion(Cube cube, Vector3 origin)
    {
        if (cube.explosionRadius <= 0f || cube.explosionForce <= 0f)
            return;

        Collider[] hits = Physics.OverlapSphere(
            origin,
            cube.explosionRadius,
            cube.explosionMask,
            QueryTriggerInteraction.Ignore
        );

        foreach (Collider hit in hits)
        {
            Rigidbody rb = hit.attachedRigidbody;
            if (rb == null || rb.gameObject == gameObject)
                continue;

            rb.AddExplosionForce(
                cube.explosionForce,
                origin,
                cube.explosionRadius,
                cube.explosionUpward,
                ForceMode.Impulse
            );
        }
    }
}
