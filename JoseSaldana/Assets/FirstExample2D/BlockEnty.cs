using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockEnty : MonoBehaviour {
    public float lifePoints;
	
    public void DecreaseLife(int ammount)
    {
        //ammount es lo decreciente que hace las balas
        lifePoints -= ammount;
        if (lifePoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
