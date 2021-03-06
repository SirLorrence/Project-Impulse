﻿using UnityEngine;
using TMPro;
using UnityEditor;

[RequireComponent(typeof(TextMeshPro))]
public class DamagePopup : MonoBehaviour
{
	[Header("Settings")] public float ySpeed = 20f;
	public float timeToDisappear = 20f;
	public float disappearSpeed = 3f;


	private float disappearTimer;
	private Color textColor;
	private TextMeshPro tmp;

	private Quaternion originalRotation;

	void Awake() {
		tmp = transform.GetComponent<TextMeshPro>();
		textColor = tmp.color;
		originalRotation = transform.rotation;
	}

	public void Setup(int damageAmount) {
		tmp.SetText(damageAmount.ToString());
		disappearTimer = timeToDisappear;
		textColor.a = 1;
		tmp.color = textColor;
		
	}

	void Update() {
		transform.position += new Vector3(0, ySpeed, 0) * Time.deltaTime;
		disappearTimer -= Time.deltaTime;
		if (disappearTimer <= 0) {
			textColor.a -= disappearSpeed * Time.deltaTime;
			tmp.color = textColor;

			if (textColor.a <= 0) ObjectPooler.Instance.SetObjectInPool(this.gameObject);
		}

		//------------------
		// Purpose: Creates the billboard effect; the damage # will face the player
		//------------------
		var cam = GameObject.Find("Camera"); // Change this name later
		transform.rotation = cam.transform.rotation * originalRotation;
	}
}