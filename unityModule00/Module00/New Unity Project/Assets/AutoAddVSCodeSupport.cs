using UnityEditor;
using UnityEngine;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;

[InitializeOnLoad]
public class AutoAddVSCodeSupport
{
    static AddRequest request;

    static AutoAddVSCodeSupport()
    {
        AddVisualStudioEditorPackage();
    }

    static void AddVisualStudioEditorPackage()
    {
        var packageId = "com.unity.ide.visualstudio";
        request = Client.Add(packageId);
        EditorApplication.update += Progress;
    }

    static void Progress()
    {
        if (request.IsCompleted)
        {
            if (request.Status == StatusCode.Success)
                Debug.Log("Added package: " + request.Result.packageId);
            else if (request.Status >= StatusCode.Failure)
                Debug.Log(request.Error.message);

            EditorApplication.update -= Progress;
        }
    }
}

