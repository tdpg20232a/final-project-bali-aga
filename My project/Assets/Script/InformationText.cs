using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationText : MonoBehaviour
{

    
    public GameObject floatingTextPrefab;
    public GameObject wholeText;
    private Vector3 adjustView = new Vector3(0, 0.85f, 0.3f);
    private Vector3 adjustViewText = new Vector3(0, 0.85f, 0.28f);
    private Quaternion myRotation = new Quaternion();
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        
        // wholeText = GetComponent<RunningText>(); // Get the PlayAudio component
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowInformation(Vector3 initialObjectPosition, Quaternion initialObjectRotation) {
        // wholeText = Instantiate(floatingTextPrefab, initialObjectPosition + adjustView, myRotation);
    }
    public void HideInformation() {
        // Destroy(wholeText);
    }

    public void Hide(Vector3 initialObjectPosition) {
        animator.SetTrigger("Hide");
        animator.ResetTrigger("Show");
        if (wholeText != null) {
            wholeText.SetActive(false);
        }
    }
    public void Show(Vector3 initialObjectPosition) {
        floatingTextPrefab.transform.position = initialObjectPosition + adjustView;
        if (wholeText != null) {
            wholeText.SetActive(true);
            floatingTextPrefab.transform.position = initialObjectPosition + adjustViewText;
        }
        // wholeText.transform.position = initialObjectPosition + adjustView;
        animator.SetTrigger("Show");
        animator.ResetTrigger("Hide");
    }
}
