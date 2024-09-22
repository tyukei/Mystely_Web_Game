using UnityEngine;
using TMPro;

public class GameView : MonoBehaviour
{
    [Header("Canvas_Static")]
    [SerializeField] private TextMeshProUGUI tmpVersion;
    [Header("Start")]
    [SerializeField] private GameObject objStart;
    [Header("Story1")]
    [SerializeField] private GameObject objStory;
    [Header("Mystery")]
    [SerializeField] private GameObject objMystery;
    [Header("Story2")]
    [SerializeField] private GameObject objStory2;
    [Header("Ending")]
    [SerializeField] private GameObject objEnding;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tmpVersion.text = "version: " + Application.version;
    }

    // Start
    public void SetStart(bool isActive){
        objStart.SetActive(isActive);
    }
    public void SetStory(bool isActive){
        objStory.SetActive(isActive);
    }

    public void SetMystery(bool isActive){
        objMystery.SetActive(isActive);
    }
    public void SetStory2(bool isActive){
        objStory2.SetActive(isActive);
    }
    public void SetEnding(bool isActive){
        objEnding.SetActive(isActive);
    }
}
