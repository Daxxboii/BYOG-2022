using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityTutorial.PlayerControl;
using UnityTutorial.Manager;
using MyBox;
using TMPro;
using UnityEngine.SceneManagement;

public class Interactions : MonoBehaviour
{
    [SerializeField,ReadOnly]private PlayerController _PlayerController;
    [SerializeField, ReadOnly] private InputManager _InputManager;
    [SerializeField, Range(1f, 10f)] private float Range;
    [SerializeField] private LayerMask Layermask;
    [SerializeField] private TextMeshProUGUI NoteText;
    [SerializeField] private GameObject NotePanel;
    private Camera PlayerCam;
    [SerializeField] private RectTransform PlayerCanvas;
    public GameObject YouDied;

    [Foldout("Buttons")]
    [SerializeField] private RectTransform InteractHandle;

    public GameObject PauseMenu;

    Interactable _Interactable;
    public static Interactions instance;
    RaycastHit hit;
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        Restart.restart += Die;
        _PlayerController = GetComponent<PlayerController>();
        _InputManager = GetComponent<InputManager>();
        _InputManager.InteractPressed += Interact;
        PlayerCam = _PlayerController.Cam.GetComponent<Camera>();
        CloseNote();
        YouDied.SetActive(false);
        PauseMenu.SetActive(false);
        instance = this;
    }

    public void Pause()
    {
        PauseMenu.SetActive(!PauseMenu.activeInHierarchy);
        Cursor.lockState = PauseMenu.activeInHierarchy ?CursorLockMode.None:CursorLockMode.Locked;
        Time.timeScale = PauseMenu.activeInHierarchy ? 0f : 1f;
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(PlayerCam.transform.position, PlayerCam.transform.TransformDirection(Vector3.forward));

        if(Physics.Raycast(ray,out hit,Range, Layermask))
        {
            InteractHandle.gameObject.SetActive(true);

            _Interactable = hit.transform.gameObject.GetComponent<Interactable>();

            Track(_Interactable.Tracker.transform);
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
                _Interactable.DoorAnimator.SetBool("Open", !_Interactable.DoorAnimator.GetBool("Open"));
            }
            else if(_Interactable._Type == Interactable.Type.Note)
            {
                NotePanel.SetActive(true);
                NoteText.text = _Interactable.NoteText;
                Time.timeScale = 0f;
            }
            else if(_Interactable._Type == Interactable.Type.Portal)
            {
                GameManager.instance.LoadScene(_Interactable.SceneToLoad);
                _Interactable.gameObject.SetActive(false);
                _Interactable = null;
            }
        }
    }

    public void CloseNote()
    {
        NotePanel.SetActive(false);
        NoteText.text = "";
        Time.timeScale = 1f;
    }

    void Track(Transform GO)
    {
        Vector2 pos = PlayerCam.WorldToScreenPoint(GO.position);
        pos.x *= PlayerCanvas.rect.width / (float)PlayerCam.pixelWidth;
        pos.y *= PlayerCanvas.rect.height / (float)PlayerCam.pixelHeight;
        InteractHandle.anchoredPosition = pos - PlayerCanvas.sizeDelta / 2f;
    }

    public void Die()
    {
        YouDied.SetActive(true);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
