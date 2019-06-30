using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class TestWindow : EditorWindow {
    [MenuItem ("Test/Test")]
    static void Open () {
        var window = CreateInstance<TestWindow> ();
        window.position = new Rect (100, 100, 500, 500);
        window.ShowPopup ();
    }

    Texture2D tex;
    Texture2D nachi;

    void Awake () {
        tex = GrabScreenSwatch (new Rect (0, 0, 2000, 2000));
        nachi = EditorGUIUtility.Load ("nachi.png") as Texture2D;
    }

    Texture2D t;

    int cnt = 0;

    bool flag = true;

    void OnGUI () {
        if (position.width > 0) {
            GUI.DrawTexture (new Rect (0, 0, (int) position.width, (int) position.height), tex);

            float targwidth = 500;
            float targheight = 500;
            float scale = Mathf.Min (targwidth / nachi.width, targheight / nachi.height);
            float newwidth = nachi.width * scale;
            float newheight = nachi.height * scale;
            GUI.DrawTexture (new Rect (0, 0, newwidth, newheight), nachi);
        }
        var e = Event.current;
        if (e.type == EventType.KeyDown && e.keyCode == KeyCode.Q) {
            this.Close ();
        }
    }

    async void Update () {
        if (cnt % 1000 == 1 && flag) {
            flag = false;

            var a = position;
            var oldpos = position;
            a.width = 0;
            a.height = 0;
            position = a;

            await TimeSpan.FromSeconds (0.002);

            tex = GrabScreenSwatch (oldpos);

            position = oldpos;
            flag = true;
        }
        if (flag) {
            cnt++;
        }
    }

    public static Texture2D GrabScreenSwatch (Rect rect) {
        int width = (int) rect.width;
        int height = (int) rect.height;
        int x = (int) rect.x;
        int y = (int) rect.y;
        Vector2 position = new Vector2 (x, y);

        Color[] pixels = InternalEditorUtility.ReadScreenPixel (position, width, height);

        Texture2D texture = new Texture2D (width, height);
        texture.SetPixels (pixels);
        texture.Apply ();

        return texture;
    }
}
