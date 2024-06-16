using System;
using System.Collections;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Laser : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 100;
    public Transform laserFirePoint;
    public LineRenderer m_lineRenderer;
    Transform m_transform;

    public bool isAutoShoot = false;
    private Coroutine shootingCoroutine;

    public float timeShoot = 1f;
    public float timeDelay = 10f;

    public bool isEnemy = false;


    public int powerUpRequirement = 0;




    public GameObject effectGun;



    public void Awake()
    {
        m_transform = GetComponent<Transform>();
    }

    private void Update()
    {
        // Start or stop shooting cycle based on isAutoShoot flag
        if (isAutoShoot)
        {
            StartShootingCycle();
        }


        else if (!isEnemy && !isAutoShoot)
        {

            if (Input.GetKeyUp(KeyCode.L))
            {


                StartCoroutine(ShootingOne());

            }
        }
        else
        {
            StopShootingCycle();
        }


        // Continuously update laser position to follow the moving object
        if (m_lineRenderer.enabled)
        {
            ShootLaser();
        }
    }


    void ShootLaser()
    {
        m_lineRenderer.enabled = true;
        RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position, transform.right);
        if (_hit.collider != null)
        {
            Debug.Log("Laser hit: " + _hit.collider.name);

            if (isEnemy)
            {
                if (_hit.collider.CompareTag("Player"))
                {
                    PlayerCollision ship = _hit.collider.GetComponent<PlayerCollision>();
                    if (ship != null)
                    {
                        ship.hit();
                    }
                }
            }
            else
            {
                if (_hit.collider.CompareTag("Boss"))
                {
                    BossBody boss = _hit.collider.GetComponent<BossBody>();
                    if (boss != null)
                    {
                        boss.Hit();
                    }
                }
            }

            Draw2DRay(laserFirePoint.position, _hit.point);
        }
        else
        {
            Draw2DRay(laserFirePoint.position, laserFirePoint.position + (Vector3)transform.right * defDistanceRay);
        }
    }

    void Draw2DRay(Vector3 startPos, Vector2 endPoint)
    {


        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPoint);
    }

    void StopLaser()
    {


        m_lineRenderer.enabled = false;
    }

    void StartShootingCycle()
    {
        if (shootingCoroutine == null)
        {

            shootingCoroutine = StartCoroutine(ShootingCycle());
        }
    }




    void StopShootingCycle()
    {
        if (shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
        }
        StopLaser();
    }

    IEnumerator ShootingCycle()
    {
        while (true)
        {
            GameObject effectInstance = Instantiate(effectGun, transform.position, Quaternion.Euler(0, 0, 90));
            StartCoroutine(UpdateEffectPosition(effectInstance));
            yield return new WaitForSeconds(0.5f);

            ShootLaser();
            yield return new WaitForSeconds(timeShoot); // Laser fires for 1 second

            StopLaser();
            yield return new WaitForSeconds(timeDelay); // Wait 10 seconds before firing again
        }
    }

    IEnumerator ShootingOne()
    {
        GameObject effectInstance = Instantiate(effectGun, transform.position, Quaternion.Euler(0, 0, 90));
        StartCoroutine(UpdateEffectPosition(effectInstance));
        yield return new WaitForSeconds(0.5f);
        ShootLaser();
        yield return new WaitForSeconds(timeShoot); // Laser fires for 1 second
        Debug.Log("in here");
        StopLaser();
        yield return new WaitForSeconds(timeDelay);
    }

    IEnumerator UpdateEffectPosition(GameObject effectInstance)
    {
        while (effectInstance != null)
        {
            effectInstance.transform.position = transform.position;
            yield return null;
        }
    }

}