using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.SceneManagement;
public enum GameState : int
{
   Start = 0,
   Over = 1
}

public class GlobalGameState : MonoBehaviour
{
    #region SINGLETON

    public static GlobalGameState Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    #endregion

    [SerializeField] private List<GameStateEvent> gameStateEvents = new List<GameStateEvent>();


    private event Action<GameState> OnStateEnter;
    private GameState gameState;

    private void Start()
    {
        ScoreSystem.ResetScore();
    }

    private void OnEnable()
    {
        OnStateEnter += GlobalGameState_OnStateEnter;
    }


    private void OnDisable()
    {
        OnStateEnter -= GlobalGameState_OnStateEnter;

    }


    private void GlobalGameState_OnStateEnter(GameState state)
    {
        for (int i = 0; i < gameStateEvents.Count; i++)
        {
            if(gameStateEvents[i].CurrentState == state)
            {
                StartCoroutine(gameStateEvents[i].Invoke());
            }
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    #region STATE CHANGERS

    public void ChangeState(GameState newState)
    {
        gameState = newState;
        OnStateEnter?.Invoke(gameState);
    }

    public void ChangeState(int stateNumber)
    {
        gameState = (GameState)stateNumber;
        OnStateEnter?.Invoke(gameState);
    }

    #endregion

}


[Serializable]
public class GameStateEvent
{
    [SerializeField] private GameState currentState;
    [SerializeField] private float timeToInvoke;
    [SerializeField] private UnityEvent OnCurrentState;


    public GameState CurrentState { get => currentState; }


    public IEnumerator Invoke()
    {
        yield return new WaitForSeconds(timeToInvoke);
        OnCurrentState?.Invoke();
    }
}