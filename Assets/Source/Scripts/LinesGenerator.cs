using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesGenerator : MonoBehaviour
{
    [SerializeField][Range(2,8)] private float fieldWidth;
    [SerializeField] private LineConfiguration[] lines;


    private void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            float startPos = -(fieldWidth / 2);
            Vector3 linePosition = new Vector3(startPos + (i * (fieldWidth / lines.Length)), 0, 0);
            Instantiate(lines[i].LinePrefab, linePosition, Quaternion.identity).Init(
                lines[i].CubeColor,
                lines[i].LineColor,
                lines[i].MoveTime,
                lines[i].PointsHeightOffset,
                lines[i].PointsMaxRandomWidth,
                lines[i].PointsCount,
                lines[i].PointPrefab,
                lines[i].CubePrefab,
                lines[i].CollisionFX);
        }
    }
}
