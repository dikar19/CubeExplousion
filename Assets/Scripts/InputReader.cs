using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private int clickButton = 0;
    [SerializeField] private Camera inputCamera;

    public event Action<Cube> CubeHit;

    private void Awake()
    {
        if (inputCamera == null)
            inputCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(clickButton))
            TryClick();
    }

    private void TryClick()
    {
        if (inputCamera == null)
            return;

        Ray ray = inputCamera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out RaycastHit hit))
            return;

        if (hit.collider.TryGetComponent(out Cube cube))
            CubeHit?.Invoke(cube);
    }
}
