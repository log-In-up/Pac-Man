using UnityEngine;

namespace Pacman
{
    public class PlayerMovementViewModel
    {
        private readonly PlayerMovementModel _model;
        private readonly Rigidbody _playerRigidbody;
        private readonly SphereCollider _playerSphereCollider;

        private const string HORIZONTAL_AXIS = "Horizontal", VERTICAL_AXIS = "Vertical";

        public PlayerMovementViewModel(PlayerMovementModel playerMovementModel)
        {
            _model = playerMovementModel;

            _playerRigidbody = _model.Player.GetComponent<Rigidbody>();
            _playerSphereCollider = _model.Player.GetComponentInChildren<SphereCollider>();
        }

        public void FixedUpdate()
        {
            UpdateMovement();
        }

        private void UpdateMovement()
        {
            float x = 0.0f;
            float y = 0.0f;
            float z = 0.0f;

            if (_model.Joystick.Direction != Vector2.zero)
            {
                x = _model.MovementSpeed * Time.fixedDeltaTime * _model.Joystick.Horizontal;
                z = _model.MovementSpeed * Time.fixedDeltaTime * _model.Joystick.Vertical;
            }

            if (Input.GetButton(HORIZONTAL_AXIS))
            {
                x = _model.MovementSpeed * Time.fixedDeltaTime * Input.GetAxis(HORIZONTAL_AXIS);
            }

            if (Input.GetButton(VERTICAL_AXIS))
            {
                z = _model.MovementSpeed * Time.fixedDeltaTime * Input.GetAxis(VERTICAL_AXIS);
            }

            if (x != 0.0f | z != 0.0f)
            {
                Vector3 position = _playerRigidbody.position + new Vector3(x, y, z);
                float distance = Vector3.Distance(_playerRigidbody.position, position);

                RaycastHit hit;
                if (Physics.SphereCast(_playerRigidbody.position, _playerSphereCollider.radius, position.normalized, out hit, distance, _model.SelfLayer))
                {
                    return;
                }

                Vector3 direction = new Vector3(x, y, z);

                _model.Player.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
                _playerRigidbody.MovePosition(_playerRigidbody.position + direction);
            }
            else
            {
                _playerRigidbody.linearVelocity = Vector3.zero;
            }
        }
    }
}