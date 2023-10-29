using Supyrb;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class LevelProgressionSystem : MonoBehaviour
{
    [SerializeField] private Levels levelsConfig;
    [SerializeField] private Sprite[] backgrounds;
    [SerializeField] private SpriteRenderer background;
    private Signal levelWinSignal;
    private Signal endPointReachedSignal;

    private int endPointReachedCount;
    private int requirementCount;

    private void Start()
    {
        endPointReachedSignal = Signals.Get<EndPointReachedSignal>();
        levelWinSignal = Signals.Get<LevelWinSIgnal>();
        endPointReachedSignal.AddListener(EndPointReached);
        background.sprite = backgrounds[Random.Range(0, backgrounds.Length)];
        int level = PlayerPrefs.GetInt("Level", 0);
        if(level == levelsConfig.levels.Length)
        {
            level = Random.Range(5, levelsConfig.levels.Length);
            PlayerPrefs.SetInt("Level", level);
        }
        Level levelData = levelsConfig.levels[level];
        LinesGenerator.Instance.GenerateLevel(levelData.linesCount, 
            levelData.pointInLines, 
            levelData.fieldWidth);
    }

    private void EndPointReached()
    {
        endPointReachedCount++;

        if (requirementCount == 0)
            requirementCount = FindObjectsOfType<Cube>().Length;

        if (endPointReachedCount == requirementCount)
            LevelWin();
    }

    private void LevelWin()
    {
        int level = PlayerPrefs.GetInt("Level", 0);
        int levelUI = PlayerPrefs.GetInt("LevelUI", 0);
        level++;
        levelUI++;
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.SetInt("LevelUI", levelUI);
        levelWinSignal?.Dispatch();
    }

    private void OnDestroy()
    {
        endPointReachedSignal.RemoveListener(EndPointReached);
    }
}
