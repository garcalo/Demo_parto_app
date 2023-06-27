// GAA: this class manages the visualization of QR codes in the scene by instantiating and removing QR code objects based on the QR code events received from the QRCodesManager

using System.Collections.Generic;
using UnityEngine;

namespace Microsoft.MixedReality.SampleQRCodes
{
    public class QRCodesVisualizer : MonoBehaviour
    {
        public GameObject qrCodePrefab;
        public Vector3 PositionAtStart;
        public Quaternion RotationAtStart;
        public bool needRestartTracking = true;

        private SortedDictionary<System.Guid, GameObject> qrCodesObjectsList;
        private bool clearExisting = false;

        struct ActionData // Struct to store the action type and corresponding QR code data
        {
            public enum Type
            {
                Added,
                Updated,
                Removed
            };
            public Type type;
            public Microsoft.MixedReality.QR.QRCode qrCode;

            public ActionData(Type type, Microsoft.MixedReality.QR.QRCode qRCode) : this()
            {
                this.type = type;
                qrCode = qRCode;
            }
        }

        private Queue<ActionData> pendingActions = new Queue<ActionData>();

        // Use this for initialization
        void Start()
        {
            // Initialize the Main Camera in the scene with black background
            Camera mainCamera = GameObject.Find("MixedRealityPlayspace").transform.Find("Main Camera").GetComponent<Camera>();
            mainCamera.clearFlags = CameraClearFlags.SolidColor;

            // Reset position and rotation of the model to an original one
            ResetLocationAtStart();

            Debug.Log("QRCodesVisualizer start");
            qrCodesObjectsList = new SortedDictionary<System.Guid, GameObject>();

            // Register event handlers for QR code events
            QRCodesManager.Instance.QRCodesTrackingStateChanged += Instance_QRCodesTrackingStateChanged;
            QRCodesManager.Instance.QRCodeAdded += Instance_QRCodeAdded;
            QRCodesManager.Instance.QRCodeUpdated += Instance_QRCodeUpdated;
            QRCodesManager.Instance.QRCodeRemoved += Instance_QRCodeRemoved;
            if (qrCodePrefab == null) // Check if the QR code prefab is assigned
            {
                throw new System.Exception("Prefab not assigned");
            }
        }
        private void Instance_QRCodesTrackingStateChanged(object sender, bool status)
        {
            // Event handler for QR codes tracking state change
            if (!status)
            {
                clearExisting = true; // Set the flag to clear existing QR code objects
            }
        }

        private void Instance_QRCodeAdded(object sender, QRCodeEventArgs<Microsoft.MixedReality.QR.QRCode> e)
        {
            // Event handler for QR code added event
            Debug.Log("QRCodesVisualizer Instance_QRCodeAdded: QR code has been added");

            lock (pendingActions)
            {
                // Enqueue the action data for later processing
                pendingActions.Enqueue(new ActionData(ActionData.Type.Added, e.Data));
            }
        }

        private void Instance_QRCodeUpdated(object sender, QRCodeEventArgs<Microsoft.MixedReality.QR.QRCode> e)
        {
            // Event handler for QR code updated event
            Debug.Log("QRCodesVisualizer Instance_QRCodeUpdated: QR code has been updated");

            lock (pendingActions)
            {
                // Enqueue the action data for later processing
                pendingActions.Enqueue(new ActionData(ActionData.Type.Updated, e.Data));
            }
        }

        private void Instance_QRCodeRemoved(object sender, QRCodeEventArgs<Microsoft.MixedReality.QR.QRCode> e)
        {
            // Event handler for QR code removed event
            Debug.Log("QRCodesVisualizer Instance_QRCodeRemoved: QR code has been removed");

            lock (pendingActions)
            {
                // Enqueue the action data for later processing
                pendingActions.Enqueue(new ActionData(ActionData.Type.Removed, e.Data));
            }
        }

        private void HandleEvents() 
        {
            lock (pendingActions) // Process the pending QR code actions
            {
                while (pendingActions.Count > 0)
                {
                    var action = pendingActions.Dequeue();
                    if (action.type == ActionData.Type.Added || action.type == ActionData.Type.Updated)
                    {

                        // Update the QR code object properties
                        qrCodePrefab.GetComponent<SpatialGraphNodeTracker>().Id = action.qrCode.SpatialGraphNodeId;
                        qrCodePrefab.GetComponent<QRCode>().qrCode = action.qrCode;
                        qrCodePrefab.SetActive(true); // Enable the QR code object
                    }

                }

            }

        }

        // Update is called once per frame
        void Update()  
        {
            HandleEvents();
            GameObject isTrackingConfigured = GameObject.Find("QRVisualizer");
            if (isTrackingConfigured != null && needRestartTracking)
            {
                Start();
                needRestartTracking = false;
            }
        }

        void ResetLocationAtStart() // this doesnt work for some reason 
        {
            qrCodePrefab.transform.position = PositionAtStart; // reset position everytime the app is launched
            qrCodePrefab.transform.rotation = RotationAtStart; // reset rotation everytime the app is launched

        }
    }
}
