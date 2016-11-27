using UnityEngine;
using System.Collections;

public class HouseBlock : MonoBehaviour {
	public GameObject house1, house2;

	void Start () {
		Vector3 pos = transform.position;
		for (int x = 0; x < 2; x++) {
			for (int z = 0; z < 2; z++) {
				if(Random.Range (0, 2)==0){
					Instantiate(house1, new Vector3(pos.x+x-0.5f, 0, pos.z+z-0.5f), Quaternion.identity);
				}else{
					Instantiate(house2, new Vector3(pos.x+x-0.5f, 0, pos.z+z-0.5f), Quaternion.identity);
				}
			}

		}
	}
}
