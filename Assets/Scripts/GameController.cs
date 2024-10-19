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
    [SerializeField] private Button btnNextStory2;


    //Mystery
    [SerializeField] private Mystery_Temple mystery_Temple;

    //Explain
    [SerializeField] private Button btnExplain;

    //Adv
    [SerializeField] private Button btnAdv;
    [SerializeField] private Button btnSkipAdv;
    const string URL = "https://daiko-ji-hp.com/jp/";
    

    private GameModel gameModel = new GameModel();

    void Start()
    {

        btnStart.onClick.AddListener(GameStart);
        btnNextStory.onClick.AddListener(NextStory);
        btnRestart.onClick.AddListener(GameRestart);
        btnNextStory2.onClick.AddListener(NextStory2);

        // Story
        SetStory();

        //Explain
        btnExplain.onClick.AddListener(NextExplain);

        // Mystery
        mystery_Temple.OnAnswerChecked += HandleAnswerChecked;

        // Adv
        btnAdv.onClick.AddListener(OpenAdv);
        btnSkipAdv.onClick.AddListener(SkipAdv);
    }

    // Start
    void GameStart(){
        Story firstStory = gameModel.GetContent(1);
        view.SetStart(false);
        view.SetStory(true, firstStory.Content, int.Parse(firstStory.CharacterNumber));
    }

    // Story
    void NextStory(){
        Story nextStory = gameModel.NextContent();
        if(nextStory.Content == "null"){
            view.SetMystery(true);
        }
        view.SetStory(true, nextStory.Content, int.Parse(nextStory.CharacterNumber));
    }
   void OnDestroy()
    {
        if (mystery_Temple != null)
        {
            mystery_Temple.OnAnswerChecked -= HandleAnswerChecked;
        }
    }

    void HandleAnswerChecked(bool isCorrect)
    {
        if (isCorrect)
        {
            view.SetExplain(true);
        }
        else
        {
            Debug.Log("Observer: The answer is incorrect.");
        }
    }

    // Explain
    void NextExplain(){
        view.SetAdv(true);
    }

    // Adv
    void OpenAdv(){
        Application.OpenURL(URL);
    }
    void SkipAdv(){
        Story firstStory2 = gameModel.GetContent2(1);
        view.SetStory2(true, firstStory2.Content, int.Parse(firstStory2.CharacterNumber));
    }

    // Story2
    void NextStory2(){
        Story nextStory2 = gameModel.NextContent2();
        if(nextStory2.Content == "null"){
            view.SetEnding(true);
        }
        view.SetStory2(true, nextStory2.Content, int.Parse(nextStory2.CharacterNumber));   
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
                gameModel.AddStories(rowStory);
            }
        });
        connectSpreadSheet.ReLoadGoogleSheet(1, loadedTexts => {
            foreach (var rowStory in loadedTexts)
            {
                gameModel.AddStories2(rowStory);
            }
        });
    }
}
