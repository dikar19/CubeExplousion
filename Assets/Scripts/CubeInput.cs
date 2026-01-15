using UnityEngine;

public class CubeInput : MonoBehaviour
{
    private Cube cube;  
    private CubeSplitter splitter; 

    private void Awake()
    {
        cube = GetComponent<Cube>();  
        splitter = GetComponent<CubeSplitter>();  
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))  
            TryClick();  
    }

    void TryClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  

        if (Physics.Raycast(ray, out RaycastHit hit))  
        {
            if (hit.collider.gameObject == gameObject)  
                splitter.TrySplit(cube);  
        }
    }
}
