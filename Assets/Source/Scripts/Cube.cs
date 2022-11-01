using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    private Color cubeColor;

    public void Init(Color cubeColor)
    {
        this.cubeColor = cubeColor;
    }

    private void Start()
    {
        GetComponent<MeshRenderer>().material.color = cubeColor;
    }
}
