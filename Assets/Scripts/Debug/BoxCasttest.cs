using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCasttest : MonoBehaviour
{ 
	RaycastHit hit;

	[SerializeField]
	bool isEnable = default;

	[SerializeField]
	private Vector2 scale = default;

	void OnDrawGizmos()
	{
		if (isEnable == false)
			return;
		
		Gizmos.DrawWireCube(transform.position - new Vector3(0, Variables._character_height), scale);
	}
}
