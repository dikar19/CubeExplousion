using UnityEngine;

public class CubeExploder : MonoBehaviour
{
    [SerializeField] private float force = 300f;
    [SerializeField] private float radius = 2f;

    public void Explode(Rigidbody body, Vector3 origin)
    {
        if (body == null)
            return;

        body.AddExplosionForce(force, origin, radius);
    }
}
