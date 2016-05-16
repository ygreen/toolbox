using UnityEngione;
using UnityEditor;

public class BundleBuilder : Editor
{
    [MenuItem("Assets/Build Asset Bundles")]
    static void BuildAllAssetBundles()
    {
        BuildPipeline.BuildAssetBundles("AssetBundles");
    }
}