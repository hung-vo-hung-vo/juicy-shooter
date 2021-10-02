using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour
{
    [field: SerializeField] public MovementDataSO movementData { get; private set; }
    protected Rigidbody2D rigidbody;

    protected float currentSpeed = 0;
    protected Vector2 currentDirection = new Vector2(0, 0);

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = currentDirection.normalized * currentSpeed;
    }

    public void MoveAgent(Vector2 moveInput)
    {
        currentDirection = moveInput;
        currentSpeed = CalculateSpeed(moveInput);
    }

    private float CalculateSpeed(Vector2 moveInput)
    {
        if (moveInput.magnitude > 0)
            currentSpeed += movementData.Acceleration * Time.deltaTime;
        else
            currentSpeed -= movementData.Deacceleration * Time.deltaTime;

        return Mathf.Clamp(currentSpeed, 0, movementData.MaxSpeed);
    }
}