using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteConsoleToFile : MonoBehaviour
{
    private void OnEnable()
    {
        Application.logMessageReceived += Log;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= Log;
    }

    public void Log(string logString, string stackTrace, LogType type)
    {
        string filePath =
            System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/GameLogs";
        
        System.IO.Directory.CreateDirectory(filePath);

        string fileName = filePath + "/log.txt";
      //  file = new System.IO.StreamWriter(fileName, true);

        System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, true);
        
        try
        {
          
            file.WriteLine("[" + System.DateTime.Now.ToString("d : t") + "]" + logString + "\n"+ stackTrace);
        }
        catch(System.IO.IOException e)
        {
            Application.logMessageReceived -= Log;
            Debug.LogError(e);
        }
        catch(System.Exception e)
        {
            Application.logMessageReceived -= Log;
            Debug.LogError(e);
        }
        finally
        {
            if (file != null)
            {
                file.Close();
            }
        }
    }
}
