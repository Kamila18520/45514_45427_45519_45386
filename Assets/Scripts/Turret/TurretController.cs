using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Transform target;  // Gracz lub inny cel
    public float rotationSpeed = 5f;
    public float fireRate = 2f;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;

    private float fireCountdown = 0f;

    void Update()
    {
        if (target == null)
            return;

        // Obracanie korpusu turretu w kierunku gracza
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        // Obracanie lufy turretu w kierunku gracza
        Vector3 gunDirection = target.position - bulletSpawnPoint.position;
        Quaternion gunRotation = Quaternion.LookRotation(gunDirection);
        bulletSpawnPoint.rotation = gunRotation;

        // Strzelanie zgodnie z czêstotliwoœci¹ strza³ów
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        // Tworzenie pocisku na podstawie prefabu
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Przekazywanie informacji do skryptu BulletController w prefabie (jeœli potrzebne)
        BulletController bulletController = bullet.GetComponent<BulletController>();
        if (bulletController != null)
        {
            // Tutaj mo¿esz przekazywaæ dodatkowe informacje
        }

        // Zniszczenie pocisku po pewnym czasie (jeœli nie trafi w cel)
        Destroy(bullet, 2f);
    }
}






