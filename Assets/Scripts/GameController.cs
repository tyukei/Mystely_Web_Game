using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameView view;
    [SerializeField] private Button btnStart;

    // Story
    private List<List<string>> storyTexts = new List<List<string>>();
    private ConnectSpreadSheet connectSpreadSheet;
    [SerializeField] private Button btnNextStory;

    [SerializeField] private Button btnRestart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        btnStart.onClick.AddListener(GameStart);
        btnRestart.onClick.AddListener(GameRestart);

        // Story
        SetStory();
    }

    void GameStart(){
        view.SetStart(false);
        view.SetStory(true);
    }

    void GameRestart(){
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    void SetStory(){
        if(connectSpreadSheet == null){
            connectSpreadSheet = GetComponent<ConnectSpreadSheet>();
        }

        List<string> texts;
        connectSpreadSheet.ReLoadGoogleSheet(0, texts => {
            storyTexts.Add(texts);  
        });
    }
}
