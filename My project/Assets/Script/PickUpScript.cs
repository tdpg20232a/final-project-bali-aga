using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PickUpScript : MonoBehaviour
{
    public GameObject player;
    public Transform holdPos;
    public float throwForce = 500f; //force at which the object is thrown at
    public float pickUpRange = 1; //how far the player can pickup the object from
    private float rotationSensitivity = 1f; //how fast/slow the object is rotated in relation to mouse movement
    private GameObject heldObj; //object which we pick up
    private Rigidbody heldObjRb; //rigidbody of object we pick up
    private bool canDrop = true; //this is needed so we don't throw/drop object when rotating the object
    private int LayerNumber; //layer index
    private float interactRange = 2F;

    public InputActionProperty rotateAction; // XR input action for rotation

    private Vector3 initialObjectPosition;
    private Quaternion initialObjectRotation;

    private XRGrabInteractable grabInteractable;

    void Start()
    {
        LayerNumber = LayerMask.NameToLayer("holdLayer"); //if your holdLayer is named differently make sure to change this ""

        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrabbed);
            grabInteractable.selectExited.AddListener(OnReleased);
        }
    }

    void Update()
    {
        if (heldObj != null) //if player is holding object
        {
            MoveObject(); //keep object position at holdPos
            RotateObject();
            if (Input.GetKeyDown(KeyCode.Mouse0) && canDrop == true) //Mous0 (leftclick) is used to throw, change this if you want another button to be used)
            {
                StopClipping();
                DropObject();
            }
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, initialObjectRotation, Time.deltaTime * 2);
        }
    }

    void PickUpObject(GameObject pickUpObj)
    {
        initialObjectPosition = pickUpObj.transform.position;
        initialObjectRotation = pickUpObj.transform.rotation;
        Debug.Log(pickUpObj.GetComponent<Rigidbody>());
        if (pickUpObj.GetComponent<Rigidbody>()) //make sure the object has a RigidBody
        {
            if (pickUpObj.TryGetComponent(out PlayAudio playAudio))
            {
                playAudio.PlayAudioInformation();
            }
            heldObj = pickUpObj; //assign heldObj to the object that was hit by the raycast (no longer == null)
            heldObjRb = pickUpObj.GetComponent<Rigidbody>(); //assign Rigidbody
            heldObjRb.isKinematic = true;
            heldObjRb.transform.parent = holdPos.transform; //parent object to hold position
            heldObj.layer = LayerNumber; //change the object layer to the holdLayer
            //make sure object doesnt collide with player, it can cause weird bugs
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
    }

    void DropObject()
    {
        if (heldObj.TryGetComponent(out PlayAudio playAudio))
        {
            playAudio.TerminateAudioInformation();
        }
        //re-enable collision with player
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0; //object assigned back to default layer
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null; //unparent object
        heldObj.transform.position = initialObjectPosition;
        heldObj.transform.rotation = initialObjectRotation;
        heldObj = null; //undefine game object
    }

    void MoveObject()
    {
        //keep object position the same as the holdPosition position
        heldObj.transform.position = holdPos.transform.position;
    }

    void RotateObject()
    {
        Vector2 rotateValue = rotateAction.action.ReadValue<Vector2>();
        float XaxisRotation = rotateValue.x * rotationSensitivity;
        float YaxisRotation = rotateValue.y * rotationSensitivity;
        //rotate the object depending on XR input values
        heldObj.transform.Rotate(Vector3.down, XaxisRotation);
        heldObj.transform.Rotate(Vector3.right, YaxisRotation);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        heldObj = args.interactableObject.transform.gameObject;
        initialObjectRotation = heldObj.transform.rotation;
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        heldObj = null;
    }

    private void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrabbed);
            grabInteractable.selectExited.RemoveListener(OnReleased);
        }
    }

    void StopClipping() //function only called when dropping/throwing
    {
        var clipRange = Vector3.Distance(heldObj.transform.position, transform.position); //distance from holdPos to the camera
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);
        if (hits.Length > 1)
        {
            heldObj.transform.position = transform.position + new Vector3(0f, -0.5f, 0f); //offset slightly downward to stop object dropping above player
        }
    }
}