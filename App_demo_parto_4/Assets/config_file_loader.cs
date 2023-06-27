/// GAA: modified to make it usable for the standardized app

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEditor;
using System.Text.RegularExpressions;
using TMPro;


using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Threading;


using Microsoft;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;


using Microsoft.MixedReality.SampleQRCodes;

using Dummiesman;


// Jason element data
public struct Data
{
    public bool models_interactable_individually;
    public string model1_url;
    public string model1_name;
    public string model1_material_url;
    public string model1_material_color;
    public string model2_url;
    public string model2_name;
    public string model2_material_url;
    public string model2_material_color;
    public string model3_url;
    public string model3_name;
    public string model3_material_url;
    public string model3_material_color;
    public string model4_url;
    public string model4_name;
    public string model4_material_url;
    public string model4_material_color;
    public string model5_url;
    public string model5_name;
    public string model5_material_url;
    public string model5_material_color;
    public string model6_url;
    public string model6_name;
    public string model6_material_url;
    public string model6_material_color;
    public string model7_url;
    public string model7_name;
    public string model7_material_url;
    public string model7_material_color;
    public string model8_url;
    public string model8_name;
    public string model8_material_url;
    public string model8_material_color;
}



public class config_file_loader : MonoBehaviour
{
    string jsonURL = "https://drive.google.com/uc?export=download&id=1YRk1fXuEDG94TiJxypOkU1_vffsMFOKQ";

    bool ComponentsAdded_model1 = false; 
    bool ComponentsAdded_model2 = false; 
    bool ComponentsAdded_model3 = false; 
    bool ComponentsAdded_model4 = false; 
    bool ComponentsAdded_model5 = false; 
    bool ComponentsAdded_model6 = false; 
    bool ComponentsAdded_model7 = false;
    bool ComponentsAdded_model8 = false;
    bool ComponentsAdded_parent = false;
    bool QRCodeTrackable_parent = false;

    Data data;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnLoadDataFromDriveClick()
    {
        //Run the coroutine upon pressing a button
        Debug.Log("starting coroutine");
        StartCoroutine(GetData(jsonURL));
        
    }

    void Update()
    {
        if (data.models_interactable_individually)
        {
            CallForInteractability(data);
        }
        
    }

    IEnumerator GetData(string url)
    {
        Debug.Log("Entered into GetData");
        UnityWebRequest request = UnityWebRequest.Get(url);


        yield return request.Send();
        Debug.Log("request " + request.isNetworkError);


        if (request.isNetworkError)
        {
            Debug.Log("error: failed to connect to the internet");
            //error
            Debug.Log(request.error);
            Debug.Log("error: failed to connect to the internet");
        }
        else
        {
            //Success
            Debug.Log("JSON data: " + request.downloadHandler.text); // Log the JSON data

            data = JsonUtility.FromJson<Data>(request.downloadHandler.text);
            Debug.Log("model 1 name: " + data.model1_name);
            Debug.Log("Data: " + JsonUtility.ToJson(data)); // yo 

            // start coroutine for all 7 models

            // First create parent for all 
            GameObject ParentModel = new GameObject("ModelsHolder");
            makeInteractable(ParentModel, ref ComponentsAdded_parent);
            

            // Model 1
            if (data.model1_url != "")
            {
                Debug.Log("starting coroutine for model 1!");
                if (data.model1_material_color != "")
                {
                    StartCoroutine(GetModel(data.model1_url, data.model1_name + ".obj", data.model1_material_color, ParentModel));
                    Debug.Log("Input material for model 1 is a color");
                }
               else if (data.model1_material_url != "")
                {
                    StartCoroutine(GetModel(data.model1_url, data.model1_name + ".obj", data.model1_material_url, ParentModel));
                    Debug.Log("Input material for model 1 is a url to be downloaded");
                }
            }
            else
            {
                Debug.Log("model 1 not present for coroutine");
            }

            // Model 2
            if (data.model2_url != "")
            {
                Debug.Log("starting coroutine for model 2!");
                if (data.model2_material_color != "")
                {
                    StartCoroutine(GetModel(data.model2_url, data.model2_name + ".obj", data.model2_material_color, ParentModel));
                    Debug.Log("Input material for model 1 is a color");
                }
                else if (data.model2_material_url != "")
                {
                    StartCoroutine(GetModel(data.model2_url, data.model1_name + ".obj", data.model2_material_url, ParentModel));
                    Debug.Log("Input material for model 2 is a url to be downloaded");
                }
            }
            else
            {
                Debug.Log("model 2 not present for coroutine");
            }

            // Model 3
            if (data.model3_url != "")
            {
                Debug.Log("starting coroutine for model 3!");
                if (data.model3_material_color != "")
                {
                    StartCoroutine(GetModel(data.model3_url, data.model3_name + ".obj", data.model3_material_color, ParentModel));
                    Debug.Log("Input material for model 3 is a color");
                }
                else if (data.model3_material_url != "")
                {
                    StartCoroutine(GetModel(data.model3_url, data.model3_name + ".obj", data.model3_material_url, ParentModel));
                    Debug.Log("Input material for model 3 is a url to be downloaded");
                }
            }
            else
            {
                Debug.Log("model 3 not present for coroutine");
            }

            // Model 4
            if (data.model4_url != "")
            {
                Debug.Log("starting coroutine for model 4!");
                if (data.model4_material_color != "")
                {
                    StartCoroutine(GetModel(data.model4_url, data.model4_name + ".obj", data.model4_material_color, ParentModel));
                    Debug.Log("Input material for model 4 is a color");
                }
                else if (data.model4_material_url != "")
                {
                    StartCoroutine(GetModel(data.model4_url, data.model4_name + ".obj", data.model4_material_url, ParentModel));
                    Debug.Log("Input material for model 4 is a url to be downloaded");
                }
            }
            else
            {
                Debug.Log("model 4 not present for coroutine");
            }

            // Model 5
            if (data.model5_url != "")
            {
                Debug.Log("starting coroutine for model 5!");
                if (data.model5_material_color != "")
                {
                    StartCoroutine(GetModel(data.model5_url, data.model5_name + ".obj", data.model5_material_color, ParentModel));
                    Debug.Log("Input material for model 5 is a color");
                }
                else if (data.model5_material_url != "")
                {
                    StartCoroutine(GetModel(data.model5_url, data.model5_name + ".obj", data.model5_material_url, ParentModel));
                    Debug.Log("Input material for model 5 is a url to be downloaded");
                }
            }
            else
            {
                Debug.Log("model 5 not present for coroutine");
            }

            // Model 6
            if (data.model6_url != "")
            {
                Debug.Log("starting coroutine for model 6!");
                if (data.model6_material_color != "")
                {
                    StartCoroutine(GetModel(data.model6_url, data.model6_name + ".obj", data.model6_material_color, ParentModel));
                    Debug.Log("Input material for model 6 is a color");
                }
                else if (data.model6_material_url != "")
                {
                    StartCoroutine(GetModel(data.model6_url, data.model6_name + ".obj", data.model6_material_url, ParentModel));
                    Debug.Log("Input material for model 6 is a url to be downloaded");
                }
            }
            else
            {
                Debug.Log("model 6 not present for coroutine");
            }

            // Model 7
            if (data.model7_url != "")
            {
                Debug.Log("starting coroutine for model 7!");
                if (data.model7_material_color != "")
                {
                    StartCoroutine(GetModel(data.model7_url, data.model7_name + ".obj", data.model7_material_color, ParentModel));
                    Debug.Log("Input material for model 7 is a color");
                }
                else if (data.model7_material_url != "")
                {
                    StartCoroutine(GetModel(data.model7_url, data.model7_name + ".obj", data.model7_material_url, ParentModel));
                    Debug.Log("Input material for model 7 is a url to be downloaded");
                }
            }
            else
            {
                Debug.Log("model 7 not present for coroutine");
            }

            // Model 8
            if (data.model8_url != "")
            {
                Debug.Log("starting coroutine for model 8!");
                if (data.model8_material_color != "")
                {
                    StartCoroutine(GetModel(data.model8_url, data.model8_name + ".obj", data.model8_material_color, ParentModel));
                    Debug.Log("Input material for model 8 is a color");
                }
                else if (data.model8_material_url != "")
                {
                    StartCoroutine(GetModel(data.model8_url, data.model8_name + ".obj", data.model8_material_url, ParentModel));
                    Debug.Log("Input material for model 8 is a url to be downloaded");
                }
            }
            else
            {
                Debug.Log("model 8 not present for coroutine");
            }

            // create parent for QR code tracking
            GameObject QRVisualizer = new GameObject("QRVisualizer");
            ParentModel.transform.SetParent(QRVisualizer.transform);
            makeQRCodeTrackable(QRVisualizer, ref QRCodeTrackable_parent);

            // Add it to the trackermanager
            GameObject TrackerManager = GameObject.Find("TrackerManager");
            QRCodesVisualizer qrCodesVisualizer = TrackerManager.GetComponent<QRCodesVisualizer>();
            qrCodesVisualizer.qrCodePrefab = QRVisualizer;
        }
        request.Dispose();
    }



    public IEnumerator GetModel(string modelUrl, string modelName, string ModelMaterial, GameObject ParentObject)
    {
        // Download the model from the URL
        UnityWebRequest www = UnityWebRequest.Get(modelUrl);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"Failed to download model from {modelUrl}: {www.error}");
            yield break;
        }

        Debug.Log("model downloaded");

        // Save the downloaded file to the local directory
        string modelPath = Path.Combine(Application.streamingAssetsPath, modelName);
        File.WriteAllBytes(modelPath, www.downloadHandler.data);

        // Load the model from the local directory
        GameObject model = new OBJLoader().Load(modelPath);
        model.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        model.transform.position = new Vector3(0.0f, 0.25f, 0.2f);
        model.transform.SetParent(ParentObject.transform);


        // Managing material:

        // Is ModelMaterial a url or a color name?
        bool materialURL = ModelMaterial.StartsWith("http");
        string MaterialPath = ""; // has to be inicialized with a default value otherwise the compiler cannot guarantee that the variable is assigned inside the switch statement
        string materialDirectory = "Assets/Materials";
        if (!Directory.Exists(materialDirectory))
        {
            Directory.CreateDirectory(materialDirectory);
        }
        switch (materialURL)
        {
            case false:
                // The model material is a color name: we need to create the material and give it that color 
                Debug.Log("Creating material with color: " + ModelMaterial);

                Color color;
                if (ColorUtility.TryParseHtmlString(ModelMaterial, out color))
                {
                    // Create a new material and assign the color to its main (base) color property
                    Material material = new Material(Shader.Find("Standard"));
                    material.SetColor("_Color", color); // Assign the color to the "_Color" property

                    // If needed: customize here the material properties

                    // Save the material asset to the Materials folder
                    MaterialPath = "Assets/Materials/" + modelName.Substring(0, modelName.Length - 4) + "_material.mat";
                    Debug.Log("Material path: " + MaterialPath);
                    AssetDatabase.CreateAsset(material, MaterialPath);
                    AssetDatabase.SaveAssets();


                    Debug.Log("Material created and saved: " + MaterialPath);
                    
                }
                else
                {
                    Debug.LogError("Invalid color name: " + ModelMaterial);
                }
                break;

            case true:
                // the model material is a url: we need to download the material from the drive folder  IMPORTANT: The material must be uploaded as .txt file (converting it just changing the file extension when renaming it) otherwise it wont work
                Debug.Log("Downloading material!");

                UnityWebRequest materialDownloader = UnityWebRequest.Get(ModelMaterial);
                materialDownloader.redirectLimit = 10; // Increase the redirect limit to handle the virus scan warning

                yield return materialDownloader.SendWebRequest();

                if (materialDownloader.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"Failed to download material from {ModelMaterial}: {materialDownloader.error}");
                    yield break;
                }

                Debug.Log("material downloaded");
                // Save the downloaded file to the local directory
                MaterialPath = "Assets/Materials/" + modelName.Substring(0, modelName.Length - 4) + "_material.mat";
                Debug.Log("Material path: " + MaterialPath);
                File.WriteAllBytes(MaterialPath, materialDownloader.downloadHandler.data);

                // Now: refresh assets database as it takes a while to import the material and wait for the material file to be imported by Unity
                AssetDatabase.Refresh();
                yield return new WaitUntil(() => AssetDatabase.LoadAssetAtPath<Material>(MaterialPath) != null);


                break;
        }

        Debug.Log("Material path: " + MaterialPath);

        if (MaterialPath != "")
        {
            // Load the material from the Assets/Materials folder
            string materialPath = "Assets/Materials/" + modelName.Substring(0, modelName.Length - 4) + "_material.mat";
            Material loaded_material = AssetDatabase.LoadAssetAtPath<Material>(materialPath);

            Debug.Log("material has been loaded as: " + loaded_material);

            // Assign material if possible

            if (loaded_material != null)
            {
                Transform child = model.transform.GetChild(0); // Assuming the child object with the Renderer is the first child
                Renderer renderer = child.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material = loaded_material;
                }
                else
                {
                    Debug.LogError("Failed to find Renderer component on child object.");
                }
            }
            else
            {
                Debug.LogError("Failed to load material: " + MaterialPath);
            }
        }
        else
        {
            Debug.Log("Material path empty");
        }

    }

    void LoadOBJ(string path)
    {
        //Instance model3D from streaming assets folder
        var modelInstance = new OBJLoader().Load(path);

        Debug.Log("Model instantiated!");
        //set the model position and rotation
        modelInstance.transform.position = new Vector3(0.0f, 0.0f, 0.5f);
        modelInstance.transform.rotation = Quaternion.Euler(0, 0, 0);
        Debug.Log("Model position and rotation set!");
        //set the model scale
        modelInstance.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        Debug.Log("Model scale set!");

    }

    void CallForInteractability(Data data)
    {
        // start coroutine for all 7 models
        GameObject model1 = GameObject.Find(data.model1_name);
        GameObject model2 = GameObject.Find(data.model2_name);
        GameObject model3 = GameObject.Find(data.model3_name);
        GameObject model4 = GameObject.Find(data.model4_name);
        GameObject model5 = GameObject.Find(data.model5_name);
        GameObject model6 = GameObject.Find(data.model6_name);
        GameObject model7 = GameObject.Find(data.model7_name);
        GameObject model8 = GameObject.Find(data.model8_name);

        // Model 1
        if (data.model1_url != "" && model1 != null)
        {
            Debug.Log("starting interactability coroutine for model 1! Model name: " + data.model1_name);
            makeInteractable(model1, ref ComponentsAdded_model1);
            Debug.Log("model 1 made interactable!");
        }
        else if (model1 == null)
        {
            Debug.Log("model 1 not claimed: model null");
        }
        else
        {
            Debug.Log("model 1 not present for interactability coroutine");
        }

        // Model 2
        if (data.model2_url != "" && model2 != null)
        {
            Debug.Log("starting interactability coroutine for model 2! Model name: " + data.model2_name);
            makeInteractable(model2, ref ComponentsAdded_model2);
            Debug.Log("model 2 made interactable!");
        }
        else if (model2 == null)
        {
            Debug.Log("model 2 not claimed: model null");
        }
        else
        {
            Debug.Log("model 2 not present for interactability coroutine");
        }

        // Model 3
        if (data.model3_url != "" && model3 != null)
        {
            Debug.Log("starting interactability coroutine for model 3! Model name: " + data.model3_name);
            makeInteractable(model3, ref ComponentsAdded_model3);
            Debug.Log("model 3 made interactable!");
        }
        else if (model3 == null)
        {
            Debug.Log("model 3 not claimed: model null");
        }
        else
        {
            Debug.Log("model 3 not present for interactability coroutine");
        }

        // Model 4
        if (data.model4_url != "" && model4 != null)
        {
            Debug.Log("starting interactability coroutine for model 4! Model name: " + data.model4_name);
            makeInteractable(model4, ref ComponentsAdded_model4);
            Debug.Log("model 4 made interactable!");
        }
        else if (model4 == null)
        {
            Debug.Log("model 4 not claimed: model null");
        }
        else
        {
            Debug.Log("model 4 not present for interactability coroutine");
        }

        // Model 5
        if (data.model5_url != "" & model5 != null)
        {
            Debug.Log("starting interactability coroutine for model 5! Model name: " + data.model5_name);
            makeInteractable(model5, ref ComponentsAdded_model5);
            Debug.Log("model 5 made interactable!");
        }
        else if (model5 == null)
        {
            Debug.Log("model 5 not claimed: model null");
        }
        else
        {
            Debug.Log("model 5 not present for interactability coroutine");
        }

        // Model 6
        if (data.model6_url != "" && model6 != null)
        {
            Debug.Log("starting interactability coroutine for model 6! Model name: " + data.model6_name);
            makeInteractable(model6, ref ComponentsAdded_model6);
            Debug.Log("model 6 made interactable!");
        }
        else if (model6 == null)
        {
            Debug.Log("model 6 not claimed: model null");
        }
        else
        {
            Debug.Log("model 6 not present for interactability coroutine");
        }

        // Model 7
        if (data.model7_url != "" && model7 != null)
        {
            Debug.Log("starting interactability coroutine for model 7! Model name: " + data.model7_name);
            makeInteractable(model7, ref ComponentsAdded_model7);
            Debug.Log("model 7 made interactable!");
        }
        else if (model7 == null)
        {
            Debug.Log("model 7 not claimed: model null");
        }
        else
        {
            Debug.Log("model 7 not present for interactability coroutine");
        }
        // Model 8
        if (data.model8_url != "" && model8 != null)
        {
            Debug.Log("starting interactability coroutine for model 8! Model name: " + data.model8_name);
            makeInteractable(model8, ref ComponentsAdded_model8);
            Debug.Log("model 8 made interactable!");
        }
        else if (model8 == null)
        {
            Debug.Log("model 8 not claimed: model null");
        }
        else
        {
            Debug.Log("model 8 not present for interactability coroutine");
        }
    } // use only in case we want the models to be interacable separately

    void makeInteractable(GameObject model, ref bool ComponentsAdded)
    {
        Debug.Log("Inside makeInteractable method with " + model);
        Debug.Log(model);
        Debug.Log("Components added:" + ComponentsAdded);
        while (!ComponentsAdded)
        {
            // Add components to each of the GameObjects loaded
            Debug.Log("calling AddAllNeededComponents method");
            AddAllNeededComponents(model);
            ComponentsAdded = true;
            Debug.Log("Components added value: " + ComponentsAdded);

        }
        if (ComponentsAdded) // Verify components have been added
        {
            Debug.Log("Components have been added to the GameObjects");

        }
    }

    void AddAllNeededComponents(GameObject mymodel)
    {
        Debug.Log("inside the method AddAllNeededComponents");
        mymodel.AddComponent<BoxCollider>();
        mymodel.AddComponent<NearInteractionGrabbable>();
        mymodel.AddComponent<ObjectManipulator>();
        Debug.Log("model has been added box collider, near interaction grabbable and objectmanipulator");
        // Include a valid size box collider
        // Get the Renderer component of the GameObject
        Renderer renderer = mymodel.GetComponent<Renderer>();
        if (renderer == null)
        {
            Debug.Log("Renderer component not found on the model.Adding one");
            mymodel.AddComponent<MeshRenderer>();
            renderer = mymodel.GetComponent<Renderer>();
        }

        // Get the Box Collider component
        BoxCollider boxCollider = mymodel.GetComponent<BoxCollider>();

        boxCollider.size = new Vector3(200, 200, 200);

        Debug.Log("All components added to the model");
    }

    void makeQRCodeTrackable(GameObject TrackerVisualizer, ref bool QRCodeTrackable)
    {
        while (!QRCodeTrackable)
        {
            // Add components to visualize the tracking
            TrackerVisualizer.AddComponent<SpatialGraphNodeTracker>();
            TrackerVisualizer.AddComponent<QRCode>();
            QRCodeTrackable = true;
        }
    }
}
