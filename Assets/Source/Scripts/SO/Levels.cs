using System;
using UnityEngine;

[CreateAssetMenu(fileName ="LevelData",menuName ="SO/LevelData")]
public class Levels : ScriptableObject
{
    public Level[] levels;
}

[Serializable]
public class Level
{
    public int linesCount;
    public int pointInLines;
    public float fieldWidth;
}
