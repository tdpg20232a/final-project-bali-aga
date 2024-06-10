using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    // Start is called before the first frame update
    private InformationText floatingTextInstance2;
    void Start()
    {
        floatingTextInstance2 = GetComponent<InformationText>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)){
            float interactRange = 0.2F;
            
            Debug.Log("F Pressed");
            if (floatingTextInstance2 != null)
            {
                Debug.Log("Instance Found");
                // floatingTextInstance2.ShowInformation(); // Show information
            }
                    
        }
    }
}
