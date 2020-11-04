using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class Settings
{
    public int speed;
    public int health;
    public string fullname;
    public string base64Texture;
}

public class WorkWithSettings : MonoBehaviour
{
    [MenuItem("Tools/Apply settings")]
    public static void ApplySettings()
    {
        const string uri = "https://dminsky.com/settings.zip";
        var outPath = Path.Combine(Application.persistentDataPath, "settings.zip");
        Debug.Log(outPath);
        
        LoadSettings(uri, outPath);
    }
    
    
    private static void LoadSettings(string uri, string outPath)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        uwr.downloadHandler = new DownloadHandlerFile(outPath);
        var asyncOp = uwr.SendWebRequest();
        asyncOp.completed += (a) =>
        {
            if (uwr.isHttpError || uwr.isNetworkError)
            {
                Debug.Log("Network error is coming...");
                Debug.Log("Network error is here!!!");
            }
            else
            {
                if (!File.Exists(outPath))
                {
                    File.WriteAllBytes(outPath, uwr.downloadHandler.data);
                }
                
                var filePath = UnzipFile(outPath);
                var settings = GetSettingsObject(filePath);
        
                int speed = GetSpeedSetting(settings);
                Player1Movement.charSpeed = speed;
                SetTexture(settings);
            }
        };
    }

    private static string UnzipFile(string path)
    {
        var unzipFilePath = Path.Combine(Application.persistentDataPath, "settings.json");
        if (!File.Exists(unzipFilePath))
        {
            ZipFile.ExtractToDirectory(path, Application.persistentDataPath);
        }

        return unzipFilePath;
    }

    private static Settings GetSettingsObject(string filePath)
    {
        var jsonObj = File.ReadAllText(filePath);
        return JsonUtility.FromJson<Settings>(jsonObj);
    }

    private static int GetSpeedSetting(Settings settings)
    {
        return settings != null ? settings.speed : 10;
    }

    private static void SetTexture(Settings settings)
    {
        if (settings.base64Texture == null)
        {
            Debug.Log("Here no a valid texture");
            return;
        }
        
        byte[] textureData = Convert.FromBase64String(settings.base64Texture);
        Texture2D myTexture = new Texture2D(1, 1);
        myTexture.LoadImage(textureData);
                
        var myMaterial = GameObject.Find("Plane").GetComponent<MeshRenderer>().sharedMaterial;
        myMaterial.SetTexture("_BumpMap", myTexture);
        myMaterial.EnableKeyword("_NORMALMAP");
    }
}
