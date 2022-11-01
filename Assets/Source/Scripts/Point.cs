using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Point : MonoBehaviour
{
    private Camera mainCamera;
    private MeshRenderer meshRenderer;

    private bool onHover;
    

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        onHover = true;
        meshRenderer.material.color = Color.yellow;
    }

    private void OnMouseUp()
    {
        onHover = false;
        meshRenderer.material.color = Color.white;
    }

    private void Update()
    {
        if (onHover)
        {
            Vector3 newPos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y,
                mainCamera.transform.position.y));
            newPos.y = 0;

            transform.position = newPos;
        }
    }
}
