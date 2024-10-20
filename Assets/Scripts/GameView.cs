using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [Header("Canvas_Static")]
    [SerializeField] private TextMeshProUGUI tmpVersion;
    [Header("Start")]
    [SerializeField] private GameObject objStart;
    [Header("Story1")]
    [SerializeField] private GameObject objStory;
    [SerializeField] private TextMeshProUGUI tmpStory;
    [SerializeField] private Sprite[] charSprites;
    [SerializeField] private Image charImage;
    [Header("Mystery")]
    [SerializeField] private GameObject objMystery;
    [Header("Explain")]
    [SerializeField] private GameObject objExplain;
    [Header("Adv")]
    [SerializeField] private GameObject objAdv;
    [Header("Story2")]
    [SerializeField] private GameObject objStory2;
    [SerializeField] private TextMeshProUGUI tmpStory2;
    [SerializeField] private Image char2Image;
    [Header("Ending")]
    [SerializeField] private GameObject objEnding;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tmpVersion.text = "version: " + Application.version;
    }

    public void SetReset(){
        objStart.SetActive(false);
        objStory.SetActive(false);
        objMystery.SetActive(false);
        objExplain.SetActive(false);
        objAdv.SetActive(false);
        objStory2.SetActive(false);
        objEnding.SetActive(false);
    }
    // Start
    public void SetStart(bool isActive){
        objStart.SetActive(isActive);
    }
    public void SetStory(bool isActive, string text, int charIndex){
        objStory.SetActive(isActive);
        tmpStory.text = text;
        charImage.sprite = charSprites[charIndex];
    }

    public void SetMystery(bool isActive){
        objMystery.SetActive(isActive);
    }
    public void SetExplain(bool isActive){
        objExplain.SetActive(isActive);
    }
    public void SetAdv(bool isActive){
        objAdv.SetActive(isActive);
    }
    public void SetStory2(bool isActive, string text, int charIndex){
        objStory2.SetActive(isActive);
        tmpStory2.text = text;
        char2Image.sprite = charSprites[charIndex];
    }
    public void SetEnding(bool isActive){
        objEnding.SetActive(isActive);
    }
}
