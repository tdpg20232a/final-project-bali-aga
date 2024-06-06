using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)){
            float interactRange = 0.2F;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray) {
                if(collider.TryGetComponent(out PedestalInteractable pedestalInteractable)){
                    pedestalInteractable.Interact();
                }
            }
        }
    }
}
