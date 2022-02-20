/// <summary>
/// Turret detect and shoot manager
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class TurretShoot : MonoBehaviour
{
    #region 
    /// <summary>
    /// Bullet prefab
    /// </summary>
    public GameObject bullet;

    /// <summary>
    /// Bullet speed
    /// </summary>
    public float speed = 100f;

    /// <summary>
    /// Banana man
    /// </summary>
    public GameObject enemy;

    /// <summary>
    /// Turrent detect range
    /// </summary>
    public float range = 10f;

    /// <summary>
    /// Container
    /// </summary>
    public GameObject gunRigContainer;
    #endregion
    
    #region 
    /// <summary>
    /// Gun aim
    /// </summary>
    private MultiAimConstraint gunRig;

    /// <summary>
    /// Visualize distance on inspector
    /// </summary>
    [SerializeField]
    private float turretDistanceWithEnemy = 0f;

    /// <summary>
    /// Turrent fire rate
    /// </summary>
    private float bulletsPerSecond = 3f;

    /// <summary>
    /// Is turrent shooting or not 
    /// </summary>
    private bool shooting = false;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        this.gunRig = gunRigContainer.GetComponent<MultiAimConstraint>(); // get gun rig
        if (this.gunRig == null)
        {
            Debug.Log("gunRig == null");
        }

        InvokeRepeating("Shoot", 0.0f, 1.0f / bulletsPerSecond); // in order to control the turrent fire rate
        this.gunRig.weight = 0.5f;
        Debug.Log("gunRig.weight" + gunRig.weight);
    }

    // Update is called once per frame
    void Update()
    {
        this.turretDistanceWithEnemy = Vector3.Distance(enemy.transform.position, transform.position);
        if (this.turretDistanceWithEnemy <= range && enemy.GetComponent<BananaManHealthSystem>().health > 0)
        {
            this.gunRig.weight = 1f; // fullly follow the enemy
            Debug.Log("gunRig.weight" + gunRig.weight);
            this.shooting = true;
        }
        else{
            this.shooting = false; // FIXME:Turrent keeps following
        }
    }

    /// <summary>
    /// Shoot bullet in instantiate way
    /// </summary>
    void Shoot()
    {
        if (!this.shooting) return;
        GameObject aBullet = Instantiate(bullet, transform.position, transform.rotation); // FIXME:Bullet rotation
        Rigidbody aRigbody = aBullet.GetComponent<Rigidbody>();
        aRigbody.AddForce(transform.forward * speed); // dont set to vector3.forward, we need the force added along with the gun shooter direction
        Destroy(aBullet, 3); // destroy after 3 seconds
    }
        
}
