using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMain : MonoBehavior
{
    public string bundleURL;
    public RawImage questionImage;
    public RawImage[] answerImage;

    AssetBundle assetBundle;
    int correctAnswer;

    public void LoadQuestion ()
    {
        if (!assetBundle)
        {

        }
    }

    IEnumerator LoadAssetBundle (int questionNumber)
    {
        WWW www = new WWW(bundleURL);
        yield return www;
        assetBundle = www.assetBundle;
        LoadQuestion(questionNumber);
    }
}
