using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationText : MonoBehaviour
{

    
    public GameObject floatingTextPrefab;
    public GameObject wholeText;
    private Vector3 adjustView = new Vector3(0, 1, 0);
    private Quaternion myRotation = new Quaternion();
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowInformation(Vector3 initialObjectPosition, Quaternion initialObjectRotation) {
        wholeText = Instantiate(floatingTextPrefab, initialObjectPosition + adjustView, myRotation);
    }
    public void HideInformation() {
        Destroy(wholeText);
    }

    public void Hide(Vector3 initialObjectPosition) {
        animator.SetTrigger("Hide");
        animator.ResetTrigger("Show");
    }
    public void Show(Vector3 initialObjectPosition) {
        floatingTextPrefab.transform.position = initialObjectPosition + adjustView;
        animator.SetTrigger("Show");
        animator.ResetTrigger("Hide");
    }
}
