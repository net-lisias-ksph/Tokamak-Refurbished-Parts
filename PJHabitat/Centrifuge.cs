using System;
//using System.Linq;
using UnityEngine;

namespace Habitat
{
	public class Centrifuge : PartModule, IAnimatedModule
	{
		[KSPField]
		public string rotorTransformName = "center";

		public Transform rotorTransform;

		[KSPField]
		public string flywheelTransformName = "flywheel";

		public Transform flywheelTransform;

		[KSPField]
		public float rotorRPM = 0f;

		[KSPField(isPersistant = true, guiActive = true, guiActiveEditor = true, guiName = "Speed Factor", guiUnits = "%")]
		[UI_FloatRange(scene = UI_Scene.All, minValue = 0f, maxValue = 200f, stepIncrement = 5f, affectSymCounterparts = UI_Scene.All)]
		public float rotorSpeedFactor = 100;

		[KSPField]
		public float flywheelRotationMult = 0f;

		[KSPField]
		public float acceleration = 0.005f;

		[KSPField]
		public float habRadius = 0f;

		[KSPField(isPersistant = true)]
		private float speedMult = 0f;

		[KSPField]
		public string animationName = "";

		[KSPField(guiActive = true, guiActiveEditor = true, guiFormat = "F2", guiName = "Artificial Gravity", guiUnits = "g", isPersistant = false)]
		public float currentGeeforce = 0f;

		public float geeforce = 0f;

		private bool startrot = false;

		public override void OnStart(PartModule.StartState state)
		{
			this.rotorTransform = base.part.FindModelTransform(this.rotorTransformName);
			this.flywheelTransform = base.part.FindModelTransform(this.flywheelTransformName);
			this.geeforce = this.habRadius * Mathf.Pow(3.14159274f * this.rotorRPM / 30f, 2f) / 9.81f;
		}

		public void EnableModule ()
		{
			isEnabled = true;
		}

		public void DisableModule ()
		{
			isEnabled = false;
		}

		public bool ModuleIsActive ()
		{
			return isEnabled;
		}

		public bool IsSituationValid()
		{
			// FIXME might want to support undeployable situations, though it
			// seems the test is for only deploy, not retract.
			return true;
		}

		private void Update()
		{
			float rotorSpeed = rotorRPM * (rotorSpeedFactor / 100) * speedMult;
			this.rotorTransform.Rotate(new Vector3(0f, 6f, 0f) * rotorSpeed * Time.deltaTime);
			this.flywheelTransform.Rotate(new Vector3(0f, -6f, 0f) * rotorSpeed * this.flywheelRotationMult * Time.deltaTime);
			this.currentGeeforce = this.habRadius * Mathf.Pow(3.14159274f * rotorSpeed / 30f, 2f) / 9.81f;
			this.startrot = isEnabled;
			if (this.startrot && this.speedMult < 1f)
			{
				this.speedMult += this.acceleration;
			}
			if (!this.startrot && this.speedMult > 0f)
			{
				this.speedMult -= this.acceleration;
			}
			if (this.speedMult < 0f)
			{
				this.speedMult = 0f;
			}
		}

		public override string GetInfo()
		{
			string str = "";
			str = str + "<b>Artificial gravity: </b> " + (this.habRadius * Mathf.Pow(3.14159274f * this.rotorRPM / 30f, 2f) / 9.81f).ToString("0.00") + "g";
			return str + "\n<b>Speed of rotation: </b> " + this.rotorRPM.ToString("0") + "rpm";
		}
	}
}
