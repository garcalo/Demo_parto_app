//// GAA
//// This class has the purpose of adding the needed components and scripts to the GameObjects in order to make them interactable
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



//public class AddInteractable : MonoBehaviour
//{
//    private GameObject model1;
//    private GameObject model2;
//    private GameObject model3;
//    private GameObject model4;
//    private GameObject model5;
//    private GameObject model6;
//    private GameObject model7;

//    public LoadModel LoadModelScript;



//    int ComponentsAdded = 0;
//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        model1 = GameObject.Find(LoadModelScript.model1_name);
//        Debug.Log("name for the model found");
//        Debug.Log("Components added:" + ComponentsAdded);
//        while (ComponentsAdded <= 0)
//        {
//            // Add components to each of the GameObjects loaded
//            Debug.Log("calling the method");
//            AddAllNeededComponents(model1);
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
//        Debug.Log("inside the method");
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

//        //// Calculate the bounds of the model
//        //Bounds bounds = CalculateModelBounds(mymodel); ;//renderer.bounds;

//        // Get the Box Collider component
//        BoxCollider boxCollider = mymodel.GetComponent<BoxCollider>();

//        //// Set the size of the Box Collider to match the model's bounds
//        //boxCollider.size = bounds.size;

//        boxCollider.size = new Vector3(200, 200, 200);

//        Debug.Log("All components added to the model");
//    }

//    Bounds CalculateModelBounds(GameObject mymodel)
//    {
//        // decided i dont need this now
//        // First check for MeshFilter (the model shouldn't have one at this point)
//        MeshFilter meshFilter = mymodel.GetComponent<MeshFilter>();
//        if (meshFilter == null)
//        {
//            mymodel.AddComponent<MeshFilter>();
//            meshFilter = mymodel.GetComponent<MeshFilter>();
//            Debug.Log("The model did not have a MeshFilter but one has been added");
//        }
//        // Check for a MeshRenderer
//        MeshRenderer meshRenderer = mymodel.GetComponent<MeshRenderer>();
//        if (meshRenderer != null)
//        {
//            // Add mesh renderer as mesh to mesh filter
//            //meshFilter.mesh = meshRenderer; // wrong bc you have to add an actual mesh 

//            // Check if mesh renderer has properly set bounds
//            if (meshRenderer.bounds.size == Vector3.zero)
//            {
//                //Debug.Log("MeshRenderer bounds have not been set.");

//                //// Recalculate the mesh bounds
//                //meshFilter.sharedMesh.RecalculateBounds();
//                //Debug.Log("MeshRenderer bounds have been recomputed.");

//                //// Update the MeshRenderer's bounds
//                //meshRenderer.bounds = meshFilter.sharedMesh.bounds;
//                //Debug.Log("MeshRenderer bounds have been updated.");
//            }
//            else
//            {
//                Debug.Log("The model has a MeshRenderer, and the bounds found are: " + meshRenderer.bounds);
//            }
//            return meshRenderer.bounds;
//        }

//        // If no suitable renderer found, return an empty bounds
//        return new Bounds();
//    }
//}
