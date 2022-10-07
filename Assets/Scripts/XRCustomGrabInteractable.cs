using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRCustomGrabInteractable : XRGrabInteractable
{
    private Vector3 interactorPosition = Vector3.zero;
    private Quaternion interactorRotation = Quaternion.identity;

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        base.OnSelectEntering(args);

        if (args.interactor is XRRayInteractor)
        {
            interactorPosition = args.interactor.attachTransform.localPosition;
            interactorRotation = args.interactor.attachTransform.localRotation;

            bool hasAttach = attachTransform != null;
            args.interactor.attachTransform.position = hasAttach ? attachTransform.position : transform.position;
            args.interactor.attachTransform.rotation = hasAttach ? attachTransform.rotation : transform.rotation;
        }
    }

    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        base.OnSelectExiting(args);

        if (args.interactor is XRRayInteractor)
        {
            interactorPosition = Vector3.zero;
            interactorRotation = Quaternion.identity;
        }
    }
}
