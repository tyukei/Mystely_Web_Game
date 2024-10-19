using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameView view;
    [SerializeField] private Button btnStart;

    // Story
    private ConnectSpreadSheet connectSpreadSheet;
    [SerializeField] private Button btnNextStory;
    [SerializeField] private Button btnRestart;
    

    private StoryModel storyModel = new StoryModel();

    void Start()
    {

        btnStart.onClick.AddListener(GameStart);
        btnNextStory.onClick.AddListener(NextStory);
        btnRestart.onClick.AddListener(GameRestart);

        // Story
        SetStory();
    }

    void GameStart(){
        Story firstStory = storyModel.GetContent(1);
        view.SetStart(false);
        Debug.Log(firstStory.CharacterNumber);
        view.SetStory(true, firstStory.Content, int.Parse(firstStory.CharacterNumber));
    }

    void NextStory(){
        Story nextStory = storyModel.NextContent();
        view.SetStory(true, nextStory.Content, int.Parse(nextStory.CharacterNumber));
    }

    void GameRestart(){
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    void SetStory(){
        if(connectSpreadSheet == null){
            connectSpreadSheet = GetComponent<ConnectSpreadSheet>();
        }
        connectSpreadSheet.ReLoadGoogleSheet(0, loadedTexts => {
            foreach (var rowStory in loadedTexts)
            {
                storyModel.AddStories(rowStory);
            }
        });
    }
}
