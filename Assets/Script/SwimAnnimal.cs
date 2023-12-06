using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwimAnnimal : Animal
{
    [SerializeField] int Chill;
    [SerializeField] bool DontMoove;
    [SerializeField] float speed;

    Vector2 AreaSize;

    void Start()
    {
        base.Start();
        AreaSize = Camera.main.ViewportToWorldPoint(Vector2.one) - Camera.main.ViewportToWorldPoint(Vector2.zero);
        if (FirstTime == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
            FirstTime = false;
        }
    }

    void Update()
    {
        base.Update();

        if (!DontMoove && !Sleep)
        {
            Chill = Random.Range(0, 100000);
            if (Chill == 0)
            {
                DontMoove = true;
                Invoke("Chilling", 10f);
            }
            else
            {
                

                if (transform.position.y > AreaSize.y / 2 || transform.position.y < -(AreaSize.y / 2))
                {
                    transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
                }
                if (transform.position.x > (AreaSize.x / 2) || transform.position.x < 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
                }

                if (transform.position.y < -(AreaSize.y / 2))
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
                }
                if (transform.position.x < -(AreaSize.x / 2))
                {
                    transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y);
                }
                if (transform.position.y > AreaSize.y / 2)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
                }
                if (transform.position.x > AreaSize.x / 2)
                {
                    transform.position = new Vector2(transform.position.x - 0.5f, transform.position.y);
                }
                transform.position += transform.right * speed * Time.deltaTime;
            }
        }

    }

    private void Chilling()
    {
        DontMoove = false;
    }
}
