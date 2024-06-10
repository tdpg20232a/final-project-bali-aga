using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RotateAndReturn : MonoBehaviour
{
    public float returnSpeed = 2f;
    public float zoomSpeed = 2f;
    public float maxZoomIn = 0.5f;
    public float maxZoomOut = 3f;
    public GameObject textPrefab; // Prefab for floating text

    private XRGrabInteractable grabInteractable;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private bool isGrabbed = false;
    private Rigidbody rb;
    private PlayAudio playAudio; // Reference to the PlayAudio script
    private Transform playerTransform;
    private GameObject floatingTextInstance;
    private InformationText floatingTextInstance2;
    public InputActionProperty zoomAction; // Add this for zoom input
    
    private Vector3 initialObjectPosition;
    private Quaternion initialObjectRotation;

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();
        playAudio = GetComponent<PlayAudio>(); // Get the PlayAudio component
        floatingTextInstance2 = GetComponent<InformationText>();

        // Get the player transform (e.g., camera or controller transform)
        playerTransform = Camera.main.transform; // Adjust as necessary

        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrabbed);
            grabInteractable.selectExited.AddListener(OnReleased);
        }

        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true; // Make sure it doesn't interfere with physics when grabbed
        }

        // Initialize floating text instance
        if (textPrefab != null)
        {
            floatingTextInstance = Instantiate(textPrefab, transform.position + Vector3.up, Quaternion.identity, transform);
            floatingTextInstance.SetActive(false);
        }

        // Ensure zoomAction is enabled
        if (zoomAction != null && zoomAction.action != null)
        {
            zoomAction.action.Enable();
        }
    }

    private void Update()
    {
        if (!isGrabbed)
        {
            // Smoothly return to the initial position and rotation
            transform.position = Vector3.Lerp(transform.position, initialPosition, returnSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation, returnSpeed * Time.deltaTime);
        }

        // Handle zooming
        if (zoomAction != null && isGrabbed)
        {
            float zoomValue = zoomAction.action.ReadValue<Vector2>().y; // Read y-axis of the joystick
            ZoomObject(zoomValue);
        }
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        
        initialObjectPosition = grabInteractable.transform.position;
        initialObjectRotation = grabInteractable.transform.rotation;
        
        Debug.Log(initialObjectPosition);
        Debug.Log(initialObjectRotation);
        isGrabbed = true;
        rb.isKinematic = true; // Disable physics while grabbing
        Debug.Log("Object grabbed");

        if (playAudio != null)
        {
            playAudio.PlayAudioInformation(); // Play the audio
        }
        if (floatingTextInstance2 != null)
        {
            Debug.Log("Instance Found");
            floatingTextInstance2.Show(initialObjectPosition);
            // floatingTextInstance2.ShowInformation(initialObjectPosition, initialObjectRotation); // Show information
        }

        if (floatingTextInstance != null)
        {
            floatingTextInstance.SetActive(true);
            floatingTextInstance.GetComponentInChildren<TextMesh>().text = "This is your object information.";
        }
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        isGrabbed = false;
        rb.isKinematic = false; // Enable physics after releasing
        Debug.Log("Object released");

        if (playAudio != null)
        {
            playAudio.TerminateAudioInformation(); // Stop the audio
        }

        if (floatingTextInstance != null)
        {
            floatingTextInstance.SetActive(false);
        }
        
        if (floatingTextInstance2 != null)
        {
            floatingTextInstance2.Hide(initialObjectPosition);
        }

    }

    private void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrabbed);
            grabInteractable.selectExited.RemoveListener(OnReleased);
        }

        if (zoomAction != null && zoomAction.action != null)
        {
            zoomAction.action.Disable();
        }
    }

    private void ZoomObject(float zoomValue)
    {
        float distance = Vector3.Distance(playerTransform.position, transform.position);
        distance = Mathf.Clamp(distance - (zoomValue * zoomSpeed * Time.deltaTime), maxZoomIn, maxZoomOut);
        transform.position = playerTransform.position + (transform.position - playerTransform.position).normalized * distance;
    }
}
