using UnityEditor;
using UnityEngine;

public static class Example {
    [InitializeOnLoadMethod]
    private static void Init () {
        //EditorApplication.CallbackFunction update = null;
        // ここで好きな色を設定する
        //update = () => {
        // var textColor = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
        // var backgroundColor = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
        var textColor = Color.black;
        var backgroundColor = new Color32 (224, 128, 0, 255);

        Shader.SetGlobalColor ("_textColor", textColor);
        Shader.SetGlobalColor ("_backgroundColor", backgroundColor);
        //};

        //EditorApplication.update += update;
    }
}
