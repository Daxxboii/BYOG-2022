using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityTutorial.PlayerControl;
using UnityTutorial.Manager;
using MyBox;

public class Interactions : MonoBehaviour
{
    [SerializeField,ReadOnly]private PlayerController _PlayerController;
    [SerializeField, ReadOnly] private InputManager _InputManager;
    [SerializeField, Range(1f, 10f)] private float Range;
    [SerializeField] private LayerMask Layermask;
    private Camera PlayerCam;
    [SerializeField] private RectTransform PlayerCanvas;

    [Foldout("Buttons")]
    [SerializeField] private RectTransform InteractHandle;

    Interactable _Interactable;

    RaycastHit hit;
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        _PlayerController = GetComponent<PlayerController>();
        _InputManager = GetComponent<InputManager>();
        _InputManager.InteractPressed += Interact;
        PlayerCam = _PlayerController.Cam.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(PlayerCam.transform.position, PlayerCam.transform.TransformDirection(Vector3.forward));

        if(Physics.Raycast(ray,out hit,Range, Layermask))
        {
            InteractHandle.gameObject.SetActive(true);

            _Interactable = hit.transform.gameObject.GetComponent<Interactable>();

            Track(_Interactable.transform);
        }
        else
        {
            InteractHandle.gameObject.SetActive(false);
            _Interactable = null;
        }

      
    }

    void Interact()
    {
        if (_Interactable != null)
        {
            if(_Interactable._Type == Interactable.Type.Door)
            {

            }
            else if(_Interactable._Type == Interactable.Type.Note)
            {

            }
            else if(_Interactable._Type == Interactable.Type.Portal)
            {
                GameManager.instance.LoadScene(_Interactable.SceneToLoad);
                _Interactable.gameObject.SetActive(false);
                _Interactable = null;
            }
        }
    }

    void Track(Transform GO)
    {
        Vector2 pos = PlayerCam.WorldToScreenPoint(GO.position);
        pos.x *= PlayerCanvas.rect.width / (float)PlayerCam.pixelWidth;
        pos.y *= PlayerCanvas.rect.height / (float)PlayerCam.pixelHeight;
        InteractHandle.anchoredPosition = pos - PlayerCanvas.sizeDelta / 2f;
    }
}
