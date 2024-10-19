using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ConnectSpreadSheet : MonoBehaviour {
    const string SHEET_ID = "1mKod1tGrep3iaoGwzNWlhr3eXm219c6WMLTfgp0QE5s";
    private string[] SHEET_NAME = {"Story1","Story2"};

    // void Start(){
    //     ReLoadGoogleSheet(1);
    // }

IEnumerator Method(string _SHEET_NAME, System.Action<List<string>> callback){
    UnityWebRequest request = UnityWebRequest.Get("https://docs.google.com/spreadsheets/d/"+SHEET_ID+"/gviz/tq?tqx=out:csv&sheet="+_SHEET_NAME);
    yield return request.SendWebRequest();

    if(request.isHttpError || request.isNetworkError) {
        Debug.Log(request.error);
    }
    else{
        // CSVデータを取得して表示
        string csvData = request.downloadHandler.text;
        string[] rows = csvData.Split('\n');

        List<string> rowData = new List<string>();

        // 各行をカンマで分割して列データを表示
        foreach (string row in rows) {
            rowData.Add(row);
        }
        callback(rowData);
    }
}
    public void ReLoadGoogleSheet(int sheetnum, System.Action<List<string>> callback) {
        StartCoroutine(Method(SHEET_NAME[sheetnum],callback));     
    }   
}
