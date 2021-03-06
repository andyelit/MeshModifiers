﻿using System;
using UnityEngine;
using MeshModifiers;

[RequireComponent (typeof (ModifierObject))]
public class DistanceBasedModifyFrames : MonoBehaviour
{
	public Transform target;

	public int
		minFrames = 2,
		maxFrames = 10;

	public float
		minFramesDistance = 0.1f,
		maxFramesDistance = 50f;


	[NonSerialized]
	public ModifierObject modObject;

	private void Start ()
	{
		if (modObject == null)
			modObject = GetComponent<ModifierObject> ();
	}

	private void Update ()
	{
		if (target == null || modObject == null || !modObject.autoUpdate)
			return;

		var distance = Vector3.Distance (modObject.transform.position, target.position);

		modObject.modifyFrames = (int)Mathf.Lerp (minFrames, maxFrames, Mathf.InverseLerp (minFramesDistance, maxFramesDistance, distance));
	}

	private void OnValidate ()
	{
		if (minFrames < 1)
			minFrames = 1;
		if (maxFrames < minFrames)
			maxFrames = minFrames;

		if (minFramesDistance < 0.01f)
			minFramesDistance = 0.01f;
		if (maxFramesDistance < minFramesDistance)
			maxFramesDistance = minFramesDistance;
	}
}