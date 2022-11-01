using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesGenerator : MonoBehaviour
{
    [SerializeField] private LineConfiguration[] lines;


    private void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            Instantiate(lines[i].LinePrefab, Vector3.zero, Quaternion.identity).Init(
                lines[i].LineColor,
                lines[i].PointsOffset,
                lines[i].PointsCount,
                lines[i].PointPrefab);
        }
    }
}
