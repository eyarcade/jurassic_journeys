using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }


    public float currentScore = 0f;
    public Data data;
    public bool isPlaying = false;
    public UnityEvent onPlay = new UnityEvent();
    public UnityEvent onGameOver = new UnityEvent();


    private void Start()
    {
        // if we have data, then load data
        string loadedData = SaveSystem.Load("save");
        if( loadedData != null )
        {
            data = JsonUtility.FromJson<Data>(loadedData);
        }
        else
        {
            // else create new data
            data = new Data();
        }
        
        
    }


    private void Update()
    {
        if(isPlaying)
        {
            currentScore += Time.deltaTime;
        }
    }

    public void StartGame()
    {
        onPlay.Invoke();
        isPlaying = true;
        currentScore = 0f;
    }

    public void GameOver()
    {
        if(data.highscore < currentScore)
        {
            data.highscore = currentScore;
            string saveString = JsonUtility.ToJson(data);
            SaveSystem.Save("save", saveString);
        }

        isPlaying = false;

        onGameOver.Invoke();
    }

    public string PrettyScore()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }

    public string PrettyHighscore()
    {
        return Mathf.RoundToInt(data.highscore).ToString();
    }
}
