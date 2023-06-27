////// GAA: modified to make it usable for the standardized app

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Networking;
//using UnityEngine.UI;
//using UnityEditor;
//using TMPro;


//using System.Runtime.Serialization.Formatters.Binary;
//using System.IO;
//using System;


//using Microsoft;
//using Microsoft.MixedReality.Toolkit.Utilities;
//using Microsoft.MixedReality.Toolkit.Input;
//using Microsoft.MixedReality.Toolkit.UI;


//using Dummiesman;


//// Jason element data
//public struct Data
//{
//    public string model1_url;
//    public string model1_name;
//    public string model2_url;
//    public string model2_name;
//    public string model3_url;
//    public string model3_name;
//    public string model4_url;
//    public string model4_name;
//    public string model5_url;
//    public string model5_name;
//    public string model6_url;
//    public string model6_name;
//    public string model7_url;
//    public string model7_name;
//}



//public class config_file_loader : MonoBehaviour
//{
//    string jsonURL = "https://drive.google.com/uc?export=download&id=1R7gXvvI-KIxEeSz3tNVxpHzTGRdSY4sS";

//    int ComponentsAdded = 0;

//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    public void OnLoadDataFromDriveClick()
//    {
//        //Run the coroutine upon pressing a button
//        StartCoroutine(GetData(jsonURL));
//        Debug.Log("starting coroutine");
//    }


//    IEnumerator GetData(string url)
//    {
//        Debug.Log("Entered into GetData");
//        UnityWebRequest request = UnityWebRequest.Get(url);


//        yield return request.Send();
//        Debug.Log("request " + request.isNetworkError);


//        if (request.isNetworkError)
//        {
//            Debug.Log("error: failed to connect to the internet");
//            //error
//            Debug.Log(request.error);
//            Debug.Log("error: failed to connect to the internet");
//        }
//        else
//        {
//            //Success
//            Debug.Log("JSON data: " + request.downloadHandler.text); // Log the JSON data

//            Data data = JsonUtility.FromJson<Data>(request.downloadHandler.text);
//            Debug.Log("model 1 name: " + data.model1_name);
//            Debug.Log("Data: " + JsonUtility.ToJson(data)); // yo 

//            // start coroutine for all 7 models
//            // Model 1
//            if (data.model1_url != "")
//            {
//                Debug.Log("starting coroutine for model 1!");
//                StartCoroutine(GetModel(data.model1_url, data.model1_name + ".obj"));
//                GameObject model1 = GameObject.Find(data.model1_name);
//                makeInteractable(model1);
//                Debug.Log("model 1 made interactable!");
//            }
//            else
//            {
//                Debug.Log("model 1 not present for coroutine");
//            }

//            // Model 2
//            if (data.model2_url != "")
//            {
//                Debug.Log("starting coroutine for model 2!");
//                StartCoroutine(GetModel(data.model2_url, data.model2_name + ".obj"));
//                GameObject model2 = GameObject.Find(data.model2_name);
//                makeInteractable(model2);
//                Debug.Log("model 2 made interactable!");
//            }
//            else
//            {
//                Debug.Log("model 2 not present for coroutine");
//            }

//            // Model 3
//            if (data.model3_url != "")
//            {
//                Debug.Log("starting coroutine for model 3!");
//                StartCoroutine(GetModel(data.model3_url, data.model3_name + ".obj"));
//                GameObject model3 = GameObject.Find(data.model3_name);
//                makeInteractable(model3);
//                Debug.Log("model 3 made interactable!");
//            }
//            else
//            {
//                Debug.Log("model 3 not present for coroutine");
//            }

//            // Model 4
//            if (data.model4_url != "")
//            {
//                Debug.Log("starting coroutine for model 4!");
//                StartCoroutine(GetModel(data.model4_url, data.model4_name + ".obj"));
//                GameObject model4 = GameObject.Find(data.model4_name);
//                makeInteractable(model4);
//                Debug.Log("model 4 made interactable!");
//            }
//            else
//            {
//                Debug.Log("model 4 not present for coroutine");
//            }

//            // Model 5
//            if (data.model5_url != "")
//            {
//                Debug.Log("starting coroutine for model 5!");
//                StartCoroutine(GetModel(data.model5_url, data.model5_name + ".obj"));
//                GameObject model5 = GameObject.Find(data.model5_name);
//                makeInteractable(model5);
//                Debug.Log("model 5 made interactable!");
//            }
//            else
//            {
//                Debug.Log("model 5 not present for coroutine");
//            }

//            // Model 6
//            if (data.model6_url != "")
//            {
//                Debug.Log("starting coroutine for model 6!");
//                StartCoroutine(GetModel(data.model6_url, data.model6_name + ".obj"));
//                GameObject model6 = GameObject.Find(data.model6_name);
//                makeInteractable(model6);
//                Debug.Log("model 6 made interactable!");
//            }
//            else
//            {
//                Debug.Log("model 6 not present for coroutine");
//            }

//            // Model 7
//            if (data.model7_url != "")
//            {
//                Debug.Log("starting coroutine for model 7!");
//                StartCoroutine(GetModel(data.model7_url, data.model7_name + ".obj"));
//                GameObject model7 = GameObject.Find(data.model7_name);
//                makeInteractable(model7);
//                Debug.Log("model 7 made interactable!");
//            }
//            else
//            {
//                Debug.Log("model 7 not present for coroutine");
//            }
//        }
//        request.Dispose();
//    }



//    public IEnumerator GetModel(string modelUrl, string modelName)
//    {
//        // Download the model from the URL
//        UnityWebRequest www = UnityWebRequest.Get(modelUrl);
//        yield return www.SendWebRequest();



//        if (www.result != UnityWebRequest.Result.Success)
//        {
//            Debug.LogError($"Failed to download model from {modelUrl}: {www.error}");
//            yield break;
//        }

//        Debug.Log("data downloaded");

//        // Save the downloaded file to the local directory
//        string modelPath = Path.Combine(Application.streamingAssetsPath, modelName);
//        File.WriteAllBytes(modelPath, www.downloadHandler.data);

//        // Load the model from the local directory
//        GameObject model = new OBJLoader().Load(modelPath);
//        model.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
//        model.transform.position = new Vector3(0.0f, 0.25f, 0.2f);

//    }


//    void LoadOBJ(string path)
//    {
//        //Instance model3D from streaming assets folder
//        var modelInstance = new OBJLoader().Load(path);

//        Debug.Log("Model instantiated!");
//        //set the model position and rotation
//        modelInstance.transform.position = new Vector3(0.0f, 0.0f, 0.5f);
//        modelInstance.transform.rotation = Quaternion.Euler(0, 0, 0);
//        Debug.Log("Model position and rotation set!");
//        //set the model scale
//        modelInstance.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
//        Debug.Log("Model scale set!");

//    }


//    void makeInteractable(GameObject model)
//    {
//        Debug.Log("Inside makeInteractable method with " + model);
//        Debug.Log("Components added:" + ComponentsAdded);
//        while (ComponentsAdded <= 0)
//        {
//            // Add components to each of the GameObjects loaded
//            Debug.Log("calling AddAllNeededComponents method");
//            AddAllNeededComponents(model);
//            ComponentsAdded += 1;
//            Debug.Log("Components added value: " + ComponentsAdded);

//        }
//        if (ComponentsAdded > 0) // Verify components have been added
//        {
//            Debug.Log("Components have been added to the GameObjects");

//        }
//    }

//    void AddAllNeededComponents(GameObject mymodel)
//    {
//        Debug.Log("inside the method AddAllNeededComponents");
//        mymodel.AddComponent<BoxCollider>();
//        mymodel.AddComponent<NearInteractionGrabbable>();
//        mymodel.AddComponent<ObjectManipulator>();
//        Debug.Log("model has been added box collider, near interaction grabbable and objectmanipulator");
//        // Include a valid size box collider
//        // Get the Renderer component of the GameObject
//        Renderer renderer = mymodel.GetComponent<Renderer>();
//        if (renderer == null)
//        {
//            Debug.Log("Renderer component not found on the model.Adding one");
//            mymodel.AddComponent<MeshRenderer>();
//            renderer = mymodel.GetComponent<Renderer>();
//        }

//        // Get the Box Collider component
//        BoxCollider boxCollider = mymodel.GetComponent<BoxCollider>();

//        boxCollider.size = new Vector3(200, 200, 200);

//        Debug.Log("All components added to the model");
//    }
//}
