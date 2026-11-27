using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private InputAction _inputMove;

    private void Start()
    {
        _inputMove = InputSystem.actions.FindAction("Move");
    }

    private void Update()
    {
        var inputValue = _inputMove.ReadValue<Vector2>();
        var direction = new Vector3(0, 0, inputValue.x).normalized * 0.1f;
        this.transform.Translate(direction, Space.World);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Vector3 ballv = Vector3.Normalize(collision.gameObject.transform.position - this.gameObject.transform.position);
            collision.rigidbody.linearVelocity = ballv * 20;
        }
    }
}