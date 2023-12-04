using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : Observer
{
    public float pullRadius = 2f;
    public float pullForce = 1000f;
    private bool isActivated = false;
    public Vector2 pullDir;
    private Collider2D[] cols;
    private GameObject target;
    public float pullTime = 0.5f;
    public float pullTimer = 0f;
    private void Awake()
    {
        isActivated = false;
        AddEventListener(EventName.BlackHolePull, args =>
        {
            //isActivated = !isActivated;
            //ApplyGravityPull();
            DetectGravityArea();
        });
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    void FixedUpdate()
    {
        if (isActivated && pullTimer<=pullTime) {
            pullTimer += Time.fixedDeltaTime;
            //Debug.Log(pullDir.normalized);
            ApplyGravityPull();
        }
        else if (pullTimer > pullTime)
        {
            isActivated = false;
            GameManager.instance.isPulling = false;
            pullTimer = 0f;
            Debug.Log("count down end");
            return;
        }
        
    }

    void DetectGravityArea()
    {
        cols = null;
        cols = Physics2D.OverlapCircleAll(transform.position, pullRadius);
        for (int i = 0; i < cols.Length; i++)
        {
            Debug.Log("detecting");
            if (cols[i].transform.CompareTag("Player"))
            {
                Debug.Log("pulling");
                pullDir = transform.position - cols[i].transform.position;
                isActivated = true;
                GameManager.instance.isPulling = true;
                target = cols[i].transform.gameObject;
                // cols[i].transform.gameObject.GetComponent<Rigidbody2D>().AddForce(pullDir.normalized * pullForce);
            }
        }
    }

    void ApplyGravityPull()
    {
        //target.GetComponent<Rigidbody2D>().AddForce(pullDir.normalized * pullForce);
        target.GetComponent<Rigidbody2D>().velocity += pullDir.normalized * pullForce;
        Debug.Log(target.GetComponent<Rigidbody2D>().velocity);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pullRadius);
    }

#endif

}
