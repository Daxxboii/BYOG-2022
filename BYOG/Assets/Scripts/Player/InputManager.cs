using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.SceneManagement;

namespace UnityTutorial.Manager
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private PlayerInput PlayerInput;

        public delegate void OnInteracted();
        public OnInteracted InteractPressed;

        public Vector2 Move { get; private set; }
        public Vector2 Look { get; private set; }
        public bool Run { get; private set; }
        public bool Jump { get; private set; }
        public bool Crouch { get; private set; }
        public bool Interact { get; private set; }
      
       

        private InputActionMap _currentMap;
        private InputAction _moveAction;
        private InputAction _lookAction;
        private InputAction _runAction;
        private InputAction _jumpAction;
        private InputAction _crouchAction;
        private InputAction _interactAction;

       

        public void Awake() {
            HideCursor();
           
                _currentMap = PlayerInput.currentActionMap;
                _moveAction = _currentMap.FindAction("Move");
                _lookAction = _currentMap.FindAction("Look");
                _runAction = _currentMap.FindAction("Run");
                _jumpAction = _currentMap.FindAction("Jump");
                _crouchAction = _currentMap.FindAction("Crouch");
            _interactAction = _currentMap.FindAction("Interact");

                _moveAction.performed += onMove;
                _lookAction.performed += onLook;
                _runAction.performed += onRun;
                _jumpAction.performed += onJump;
                _crouchAction.started += onCrouch;
            _interactAction.performed += OnInteract;

                _moveAction.canceled += onMove;
               _lookAction.canceled += onLook;
                _runAction.canceled += onRun;
                _jumpAction.canceled += onJump;
                _crouchAction.canceled += onCrouch;



        }

      

        private void HideCursor()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        #region Inputs


        private void onMove(InputAction.CallbackContext context)
        {
            Move = context.ReadValue<Vector2>();
        }
        private void onLook(InputAction.CallbackContext context)
        {
            Look = context.ReadValue<Vector2>();
        }
        private void onRun(InputAction.CallbackContext context)
        {
            Run = context.ReadValueAsButton();
        }
        private void onJump(InputAction.CallbackContext context)
        {
            Jump = context.ReadValueAsButton();
        }
        private void onCrouch(InputAction.CallbackContext context)
        {
            Crouch = context.ReadValueAsButton();
        }
        private void OnInteract(InputAction.CallbackContext context)
        {
            //Interact = context.ReadValueAsButton();
            InteractPressed.Invoke();
        }
        private void OnEnable() {
            _currentMap.Enable();
        }

        private void OnDisable() {
             _currentMap.Disable();
        }

        #endregion

     /*   #region Input Over Network
       //Network Stuff
        void Update()
        {
            //Writing values to server
            if (IsOwner)
            {
                PlayerEntityData.Value = new PlayerNetworkData()
                {
                    _Move = Move,
                    _Look = Look,
                    _Run = Run,
                    _Jump = Jump,
                    _Crouch = Crouch,
                    _Position = transform.position,
                    _Rotation = transform.rotation.eulerAngles
                };
            }
            //Reading Values from Server
            else
            {
                Move = PlayerEntityData.Value._Move;
                Look = PlayerEntityData.Value._Look;
                Run  = PlayerEntityData.Value._Run;
                Jump = PlayerEntityData.Value._Jump;
                Crouch = PlayerEntityData.Value._Crouch;
                transform.position = PlayerEntityData.Value._Position;
                transform.rotation = Quaternion.Euler(PlayerEntityData.Value._Rotation);
            }
        }
      
    
        

        struct PlayerNetworkData: INetworkSerializable
        {
            private float _x,_y;
            private float xPos,yPos,zPos;
            private float xRot,yRot,zRot;
            private float LookX,LookY;
            private bool jump, run, crouch;
        
             //Move Variable
            internal Vector2 _Move
            {
               get => new Vector2(_x,_y);
               set
               {
                   _x = value.x;
                   _y = value.y;
               }
            }
        
            //Look Variable
            internal Vector2 _Look
            {
                get => new Vector2(LookX,LookY);
                set
                {
                    LookX = value.x;
                    LookY = value.y;
                }
            }
         
            internal bool _Run
            {
                get => run;
                set { run = value;}

            }   
            internal bool _Crouch
            {
                get => crouch;
                set { crouch = value; }
            }
            internal bool _Jump
            {
                get => jump;
                set { jump = value; }
            }
             
            internal Vector3 _Position
            {
               get => new Vector3(xPos,yPos,zPos);
               set
               {
                   xPos = value.x;
                   yPos = value.y;
                   zPos = value.z;
               }
            }

            internal Vector3 _Rotation
            {
               get => new Vector3(xRot,yRot,zRot);
               set
               {
                   xRot = value.x;
                   yRot = value.y;
                   zRot = value.z;
               }
            }

             public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter 
            {
               serializer.SerializeValue(ref _x);
               serializer.SerializeValue(ref _y);


               serializer.SerializeValue(ref LookX);
               serializer.SerializeValue(ref LookY);

                serializer.SerializeValue(ref jump);
                serializer.SerializeValue(ref crouch);
                serializer.SerializeValue(ref run);

                serializer.SerializeValue(ref xPos);
                serializer.SerializeValue(ref yPos);
                serializer.SerializeValue(ref zPos);

                serializer.SerializeValue(ref xRot);
                serializer.SerializeValue(ref yRot);
                serializer.SerializeValue(ref zRot);

            }
            #endregion
            */
        }
    }

