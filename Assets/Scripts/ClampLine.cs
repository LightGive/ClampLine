using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class ClampLine : MonoBehaviour
{
	#region Inspector
	[SerializeField]
	private Transform m_pointA = null;
	[SerializeField]
	private Transform m_pointB = null;
	[SerializeField]
	private Transform m_target = null;
	[SerializeField]
	private Transform m_moveObject = null;
	[SerializeField]
	private LineRenderer m_line = null;
	#endregion

	#region Field

	#endregion

	#region MonoMethod

	void Start()
	{
	}

	void Update()
	{
		m_line.SetPositions(new Vector3[] { m_pointA.position, m_pointB.position });

		m_moveObject.position = GetPosition(m_pointA.position, m_pointB.position, m_target.position, out float l);
		Debug.Log(l);

		var d = Vector3.Dot(m_target.position - m_pointA.position, (m_pointB.position - m_pointA.position).normalized);
		var dis = Vector3.Distance(m_pointA.position, m_pointB.position);
	}

	#endregion

	#region Method

	private Vector3 GetPosition(Vector3 _p1, Vector3 _p2, Vector3 _checkPos, out float _lerp)
	{
		var x = Vector3.Dot((_p2 - _p1).normalized, _checkPos - _p1);
		_lerp = x / Vector3.Distance(_p1, _p2);
		return _p1 + (_p2 - _p1).normalized * x;
	}

	#endregion
}
