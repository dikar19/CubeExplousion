using UnityEngine;

public class CubeSplitter : MonoBehaviour
{
    public void TrySplit(Cube cube)
    {
        int count = Random.Range(2, 7);

        if (transform.localScale.x <= cube.minScale)  
        {
            Destroy(gameObject);  
            return;
        }

        if (Random.value > cube.splitChance)  
        {
            Destroy(gameObject);  
            return;
        }          

        for (int i = 0; i < count; i++)  
        {
            CubeSpawner.Spawn(cube, transform.position);  
        }

        Destroy(gameObject);  
    }
}
