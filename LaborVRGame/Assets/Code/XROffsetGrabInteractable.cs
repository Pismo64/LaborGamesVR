using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XROffsetGrabInteractable : XRGrabInteractable
{
    private Vector3 initialLocalPos;
    private Quaternion initialLocalRot;
    void Start()
    {
        if (!attachTransform)
        {
            GameObject attachPoint = new GameObject("Offset Grab Pivot");
            attachPoint.transform.SetParent(transform, false);
            attachTransform = attachPoint.transform;
        }
        else
        {
            initialLocalPos = transform.localPosition;
            initialLocalRot = transform.localRotation;
        }
    }
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(args.interactableObject is XRDirectInteractor)
        {
            attachTransform.position = args.interactableObject.transform.position;
            attachTransform.rotation = args.interactableObject.transform.rotation;
        }
        else
        {
            attachTransform.localPosition = initialLocalPos;
            attachTransform.localRotation = initialLocalRot;
        }
        

        base.OnSelectEntered(args);
    }
}
