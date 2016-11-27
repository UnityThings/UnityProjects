using UnityEngine;
using System.Collections;

public class Grass : MonoBehaviour {
	public GameObject tree;

	void Start () {
		int nrTrees = Random.Range (2, 5);
		Vector3 pos = transform.position;
		for (int i = 0; i < nrTrees; i++) {
			GameObject go = Instantiate(tree, new Vector3(pos.x+(Random.Range(-0.5f, 0.5f)), pos.y, pos.z+(Random.Range(-0.5f, 0.5f))), Quaternion.identity) as GameObject;
			go.transform.SetParent(transform);
		}
	}
}
