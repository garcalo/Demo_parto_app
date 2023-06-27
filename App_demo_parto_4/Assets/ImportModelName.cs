////GAA: This script has the purpose of reading the model name from a .json file and updating it on the ui when the models are loaded
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.IO;


//public class ImportModelName : MonoBehaviour
//{
//    public Text nameLabel; // Reference to the Text UI element

//    public void LoadData()
//    {
//        // Read the JSON file
//        string jsonPath = Path.Combine(Application.streamingAssetsPath, "Data.json");
//        string jsonData = File.ReadAllText(jsonPath);

//        // Parse the JSON data into a custom data structure
//        DataModel data = JsonUtility.FromJson<DataModel>(jsonData);

//        // Update the name label text
//        nameLabel.text = data.name;
//    }
//}

//[System.Serializable]
//public class DataModel
//{
//    public string name;
//}
