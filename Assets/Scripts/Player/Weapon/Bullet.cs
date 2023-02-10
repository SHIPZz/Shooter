using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Time { get; private set; } = 0.0f;
    public Vector3 InitialPosition { get; private set; }
    public Vector3 InitialVelocity { get; private set; }

    public void SetPosition(Vector3 position) => InitialPosition = position;

    public void SetVelocity(Vector3 velocity) => InitialVelocity = velocity;

    public void AddTime(float deltaTime) => Time += deltaTime;
}

