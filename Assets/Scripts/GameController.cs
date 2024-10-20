using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    //Start
    [SerializeField] private Button btnStart;

    // Story
    private ConnectSpreadSheet connectSpreadSheet;
    [SerializeField] private Button btnNextStory;

    //Mystery
    [SerializeField] private Mystery_Temple mystery_Temple;

    //Explain
    [SerializeField] private Button btnExplain;

    //Adv
    [SerializeField] private Button btnAdv;
    [SerializeField] private Button btnSkipAdv;
    const string URL = "https://daiko-ji-hp.com/jp/";

    //Story2
    [SerializeField] private Button btnNextStory2;

    //Ending
    [SerializeField] private Button btnRestart;

    //UI
    [SerializeField] private Button btnBack;
    

    private GameModel model = new GameModel();
    [SerializeField] private GameView view;

    void Start()
    {
        int currentState = model.GetState();
        SetViewByState(currentState);
        // Start
        btnStart.onClick.AddListener(GameStart);
        // Story
        btnNextStory.onClick.AddListener(NextStory);
        SetStory();
        //Explain
        btnExplain.onClick.AddListener(NextExplain);
        // Mystery
        mystery_Temple.OnAnswerChecked += HandleAnswerChecked;
        // Adv
        btnAdv.onClick.AddListener(OpenAdv);
        btnSkipAdv.onClick.AddListener(SkipAdv);
        // Story2
        btnNextStory2.onClick.AddListener(NextStory2);
        // Ending
        btnRestart.onClick.AddListener(GameRestart);
        // UI
        btnBack.onClick.AddListener(OnBack);
    }

    // Start
    void GameStart(){
        view.SetStart(false);
        Story firstStory = model.GetContent(1);
        view.SetStory(true, firstStory.Content, int.Parse(firstStory.CharacterNumber));
        model.SetNextState();
    }

    // Story
    void NextStory(){
        Story nextStory = model.NextContent();
        if(nextStory.Content == "null"){
            view.SetMystery(true);
            model.SetNextState();
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
            model.SetNextState();
        }
        else
        {
            Debug.Log("Observer: The answer is incorrect.");
        }
    }

    // Explain
    void NextExplain(){
        view.SetAdv(true);
        model.SetNextState();
    }

    // Adv
    void OpenAdv(){
        Application.OpenURL(URL);
    }
    void SkipAdv(){
        Story firstStory2 = model.GetContent2(1);
        view.SetStory2(true, firstStory2.Content, int.Parse(firstStory2.CharacterNumber));
        model.SetNextState();
    }

    // Story2
    void NextStory2(){
        Story nextStory2 = model.NextContent2();
        if(nextStory2.Content == "null"){
            view.SetEnding(true);
        }
        view.SetStory2(true, nextStory2.Content, int.Parse(nextStory2.CharacterNumber));   
        model.SetNextState();
    }

    // Ending
    void GameRestart(){
        model.SetResetState();
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
                model.AddStories(rowStory);
            }
        });
        connectSpreadSheet.ReLoadGoogleSheet(1, loadedTexts => {
            foreach (var rowStory in loadedTexts)
            {
                model.AddStories2(rowStory);
            }
        });
    }

    // UI
    void OnBack(){
        model.SetBackState();
        int currentState = model.GetState();
        SetViewByState(currentState);
    }
    private enum viewState{
            START,
            STORY,
            MYSTERY,
            EXPLAIN,
            ADV,
            STORY2,
            ENDING
    }
    public void SetViewByState(int state){
        view.SetReset();
        switch(state){
            case (int)viewState.START:
                view.SetStart(true);
                break;
            case (int)viewState.STORY:
                Story firstStory = model.GetContent(1);
                view.SetStory(true, firstStory.Content, int.Parse(firstStory.CharacterNumber));
                break;
            case (int)viewState.MYSTERY:
                view.SetMystery(true);
                break;
            case (int)viewState.EXPLAIN:
                view.SetExplain(true);
                break;
            case (int)viewState.ADV:
                view.SetAdv(true);
                break;
            case (int)viewState.STORY2:
                Story firstStory2 = model.GetContent2(1);
                view.SetStory2(true, firstStory2.Content, int.Parse(firstStory2.CharacterNumber));
                break;
            case (int)viewState.ENDING:
                view.SetEnding(true);
                break;
            default:
                view.SetStart(true);
                break;
        }
    }
}
