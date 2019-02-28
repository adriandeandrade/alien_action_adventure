using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceUIController : MonoBehaviour
{
    [SerializeField] private Transform lookAtTarget;

    public bool isActive;

    RectTransform rectTransform;
    GameObject targetObject;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        isActive = false;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.LookAt(lookAtTarget);
    }

    public void SetPosition(GameObject _targetObject)
    {
        targetObject = _targetObject;

        // Position
        Bounds objectBounds = GetObjectBounds(_targetObject);
        Vector3 offset = new Vector3(0f, objectBounds.size.y, 0f);
        Vector3 finalPosition = _targetObject.transform.position + offset;

        rectTransform.SetPositionAndRotation(finalPosition, Quaternion.identity);
    }

    private Bounds GetObjectBounds(GameObject target)
    {
        Bounds total = new Bounds(target.transform.position, Vector3.zero);

        Collider col = target.GetComponent<BoxCollider>();
        total.Encapsulate(col.bounds);

        return total;
    }

    public void ToggleCanvas(bool state)
    {
        gameObject.SetActive(state);
    }
}
