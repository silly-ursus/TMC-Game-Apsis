using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class TakeScreenshot : MonoBehaviour
{
    private Camera cam;
    void TakeScreenshots(string fullPath)
    {
        if(cam == null) {
            cam = GetComponent<Camera>();
        }

        RenderTexture renderTexture = new RenderTexture(256, 256, 24);
        cam.targetTexture = renderTexture;
        Texture2D screenshot = new Texture2D(256, 256, TextureFormat.RGBA32, false);
        cam.Render();
        RenderTexture.active = renderTexture;
        screenshot.ReadPixels(new Rect(0, 0, 256, 256), 0, 0);
        cam.targetTexture = null;
        RenderTexture.active = null;

        if (Application.isEditor) {
            DestroyImmediate(renderTexture);
        } else {
            Destroy(renderTexture);
        }

        byte[] bytes = screenshot.EncodeToPNG();
        System.IO.File.WriteAllBytes(fullPath, bytes);
        
    #if UNITY_EDITOR
        AssetDatabase.Refresh();
    #endif
    }
}
