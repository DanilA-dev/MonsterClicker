using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text enemiesCountText;
    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private List<SimpleTweenAnimation> animations = new List<SimpleTweenAnimation>();

    private void OnEnable()
    {
        EnemySpawnerBase.OnEnemiesCountChanged += EnemySpawnerBase_OnEnemiesCountChanged;
        ScoreSystem.OnScoreChanged += ScoreSystem_OnScoreChanged;
    }


    private void OnDisable()
    {
        EnemySpawnerBase.OnEnemiesCountChanged -= EnemySpawnerBase_OnEnemiesCountChanged;
        ScoreSystem.OnScoreChanged -= ScoreSystem_OnScoreChanged;
    }


    private void Start()
    {
        foreach (var a in animations)
        {
            a.Animate();
        }
    }

    private void ScoreSystem_OnScoreChanged(int score)
    {
        scoreText.text = "Score : " + score; 
    }

    private void EnemySpawnerBase_OnEnemiesCountChanged(int count)
    {
        enemiesCountText.text = "Enemies :" + count;

        var bounceScale = new Vector3(1.2f, 1.2f, 1.2f);
        enemiesCountText.transform.DOScale(bounceScale, 0.2f).From(Vector3.one);
    }


}
