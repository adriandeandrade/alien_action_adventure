using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionUIController : MonoBehaviour
{
    [SerializeField] private Transform lookAtTarget;
    [SerializeField] private TextMeshProUGUI interactText;

    public bool isActive;

    RectTransform rectTransform;
    Transform targetObject;
    Camera cam;
    Animator anim;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        anim = GetComponent<Animator>();
        cam = Camera.main;
    }

    private void Start()
    {
        isActive = false;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.LookAt(cam.transform);
    }

    public void UpdateUI(InteractableObjectData objData)
    {
        interactText.SetText("Interact with " + objData.objectName);
    }

    public void SetPosition(Transform _targetObject, bool useCustomPosition)
    {
        targetObject = _targetObject;

        if (useCustomPosition)
        {
            rectTransform.SetPositionAndRotation(_targetObject.position, Quaternion.identity);
        }
        else
        {
            // Position
            Bounds objectBounds = GetObjectBounds(_targetObject.gameObject);
            Vector3 offset = new Vector3(0f, objectBounds.size.y, 0f);
            Vector3 finalPosition = _targetObject.transform.position + offset;

            rectTransform.SetPositionAndRotation(finalPosition, Quaternion.identity);
        }
    }

    private Bounds GetObjectBounds(GameObject target)
    {
        Bounds total = new Bounds(target.transform.position, Vector3.zero);

        Collider col = target.GetComponent<Collider>();
        total.Encapsulate(col.bounds);

        return total;
    }

    public void ToggleCanvas(bool state)
    {
        gameObject.SetActive(state);
        isActive = state;
    }

    public void TriggerFadeOut()
    {
        anim.SetTrigger("fadeOut");
    }

    public void OnFadeOutEnd()
    {
        ToggleCanvas(false);
    }
}
