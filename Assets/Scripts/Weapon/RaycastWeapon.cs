using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{
    private const byte Count = 1;
    private const int FireRate = 25;
    private const float AdditionalGravity = 0.5f;
    private const float MaxLifeTime = 3.0f;
    private const float ShootInterval = 0.5f;

    [SerializeField] private ParticleSystem[] _effects;
    [SerializeField] private ParticleSystem _hitEffect;
    [SerializeField] private Transform _raycastOrigin;
    [SerializeField] private Transform _raycastDestination;
    [SerializeField] private float _bulletSpeed = 1000.0f;
    [SerializeField] private float _bulletDrop = 0.0f;

    [field: SerializeField] public int AmmoCount { get; private set; }
    [field: SerializeField] public int ClipSize { get; private set; }
    [field: SerializeField] public GameObject Magazine { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }

    private List<Bullet> _bullets = new();
    private float _accumulatedTime;
    private Ray _ray;

    public WeaponRecoil Recoil { get; private set; }
    public bool IsFired { get; private set; } = false;                                                                              

    private void Awake()
    {
        Recoil = GetComponent<WeaponRecoil>();
    }

    public void SetAmmoCount(int ammoCount) => AmmoCount = ammoCount;

    public void SetMagazinePosition(GameObject magazine)
    {
        Magazine = magazine;
    }

    public void StartFire()
    {
        IsFired = true;
        _accumulatedTime = 0.0f;
        FireBullet();
    }

    public void UpdateFire(float deltaTime)
    {
        _accumulatedTime += deltaTime;
        float fireInterval = ShootInterval / FireRate;

        while (_accumulatedTime >= 0.0f)
        {
            FireBullet();
            _accumulatedTime -= fireInterval;
        }
    }

    public void StopFire() => IsFired = false;

    public void UpdateBullets(float deltaTime)
    {
        SimulateBullets(deltaTime);
        DestroyBullets();
    }

    public void SetRaycastDestination(Transform raycastDestination)
    {
        _raycastDestination = raycastDestination;
    }

    private void DestroyBullets()
    {
        _bullets.RemoveAll(bullet => bullet.Time > MaxLifeTime);
    }

    private void SimulateBullets(float deltaTime)
    {
        _bullets.ForEach(bullet =>
        {
            Vector3 position = GetPosition(bullet);
            bullet.AddTime(deltaTime);
            Vector3 secondPosition = GetPosition(bullet);
            RaycastSegment(position, secondPosition);
        });
    }

    private void RaycastSegment(Vector3 start, Vector3 end)
    {
        Vector3 direction = end - start;
        _ray.origin = start;
        _ray.direction = direction;

        if (Physics.Raycast(_ray, out RaycastHit hitInfo))
        {
            _hitEffect.transform.position = hitInfo.point;

            _hitEffect.transform.forward = hitInfo.normal;
            _hitEffect.Emit(Count);

            var hitBox = hitInfo.collider.GetComponent<Health>();

            if (hitBox != null)
            {
                hitBox.Decrease(Damage);
            }
        }
    }

    private void FireBullet()
    {
        if (AmmoCount <= 0)
            return;

        AmmoCount--;

        foreach (var effect in _effects)
        {
            effect.Emit(Count);
        }

        Vector3 velocity = (_raycastDestination.position - _raycastOrigin.position).normalized * _bulletSpeed;
        var bullet = CreateBullet(_raycastOrigin.position, velocity);
        _bullets.Add(bullet);

        Recoil.GenerateRecoil();
    }

    private Vector3 GetPosition(Bullet bullet)
    {
        Vector3 gravity = Vector3.down * _bulletDrop;

        return (bullet.InitialPosition) + (bullet.InitialVelocity * bullet.Time) + (AdditionalGravity * gravity * bullet.Time * bullet.Time);
    }

    private Bullet CreateBullet(Vector3 position, Vector3 velocity)
    {
        Bullet bullet = new();
        bullet.SetPosition(position);
        bullet.SetVelocity(velocity);

        return bullet;
    }
}