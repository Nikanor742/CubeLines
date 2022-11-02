using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Point : MonoBehaviour
{
    private Camera mainCamera;
    private MeshRenderer meshRenderer;

    private float prevPointPositionZ;
    private float nextPointPositionZ;
    private bool movable = true;
    private bool onHover;
    
    public void SetPrevPointPositionZ(float z)
    {
        prevPointPositionZ = z;
    }
    public void SetNextPointPositionZ(float z)
    {
        nextPointPositionZ = z;
    }
    public void SetMovableState(bool state)
    {
        movable = state;
    }

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        onHover = true;
        if(movable)
            meshRenderer.material.color = Color.yellow;
    }

    private void OnMouseUp()
    {
        onHover = false;
        if (movable)
            meshRenderer.material.color = Color.white;
    }

    private void Update()
    {
        if (movable && onHover)
        {
            Vector3 newPos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y,
                mainCamera.transform.position.y));
            newPos.y = 0;

            if(newPos.z < nextPointPositionZ && newPos.z > prevPointPositionZ)
                transform.position = newPos;
        }
    }
}
