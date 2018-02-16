using UnityEngine;

namespace Lean.Touch
{
	// This script will allow you to control a basic turret using a joystick and button
	public class LeanJoystickTurret : MonoBehaviour
	{
		[Tooltip("Sensitivity of the turn")]
		public float YawSensitivity = 0.25f;

		[Tooltip("The joystick used to control the turret rotation")]
		public LeanCircleJoystick AimJoystick;

		[Tooltip("The current turret yaw value")]
		public float Yaw;

		[Tooltip("The transform that will handle the yaw rotation")]
		public Transform YawRoot;

		[Tooltip("The current turret pitch value")]
		public float Pitch;

		[Tooltip("The minimum pitch value")]
		public float PitchMin = -20.0f;

		[Tooltip("The maximum pitch value")]
		public float PitchMax = 20.0f;

		[Tooltip("The transform that will handle the pitch rotation")]
		public Transform PitchRoot;

		protected virtual void Update()
		{
			// Does the yaw root exist?
			if (YawRoot != null)
			{
				Yaw += AimJoystick.ScaledValue.x * YawSensitivity;

				YawRoot.localRotation = Quaternion.Euler(0.0f, Yaw, 0.0f);
			}

			// Does the pitch root exist?
			if (PitchRoot != null)
			{
				Pitch += AimJoystick.ScaledValue.y * YawSensitivity;

				Pitch = Mathf.Clamp(Pitch, PitchMin, PitchMax);

				PitchRoot.localRotation = Quaternion.Euler(Pitch, 0.0f, 0.0f);
			}
		}
	}
}