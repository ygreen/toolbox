using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMain : MonoBehavior
{
    public string bundleURL;
    public RawImage questionImage;
    public RawImage[] answerImages;

    AssetBundle assetBundle;
    int correctAnswer;

    public void LoadQuestion (int questNumber)
    {
        if (!assetBundle)
        {
            StartCoroutine(LoadAssetBundle(questNumber));
            return;
        }
        StartCoroutine(ShowQuest(questNumber));
    }

    IEnumerator LoadAssetBundle (int questionNumber)
    {
        WWW www = new WWW(bundleURL);
        yield return www;
        assetBundle = www.assetBundle;
        LoadQuestion(questionNumber);
    }

    IEnumerator ShowQuest (int questionNumber)
    {
        AssetBundleRequest assetTexture = assetBundle.LoadAssetAsync<Texture2D>("p" + questionNumber);
        yield return assetTexture;
        questionImage.texture = assetTexture.asset as Texture2D;

        for(int i=0; i < answerImages.Length; i++)
        {
            AssetBundleRequest assetAnswer = assetBundle.LoadAssetAsync<Texture2D>("J" + questionNumber + "-" + i);
            yield return assetTexture;
            answerImages[i].texture = assetAnswer.asset as Texture2D;
        }

        AssetBundleRequest assetCorrectAnswer = assetBundle.LoadAssetAsync<TextAsset>("Con" + questionNumber);
        yield return assetCorrectAnswer;
        correctAnswer = int.Parse((assetCorrectAnswer.asset as TextAsset).text);
    }
}
