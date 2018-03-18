using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Habitat
{
	public class DeployableHabitat : PartModule, IAnimatedModule
	{
		[KSPField]
		public int crewCapacityDeployed = 0;

		[KSPField]
		public int crewCapacityRetracted = 0;

		[KSPField]
		public string deployedState = "deployed";

		[KSPField]
		public string retractedState = "retracted";

		public override void OnStart(PartModule.StartState state)
		{
			base.OnStart(state);
			GameEvents.onCrewTransferred.Add (onCrewTransferred);
			StartCoroutine (WaitAndCountCrew ());
		}

		void OnDestroy ()
		{
			GameEvents.onCrewTransferred.Remove (onCrewTransferred);
		}

		public override string GetInfo()
		{
			string text = "";
			text = text + "<b>Crew capacity deployed: </b>" + this.crewCapacityDeployed.ToString("0");
			if (this.crewCapacityRetracted > 0)
			{
				text = text + "\n<b>Crew capacity retracted: </b>" + this.crewCapacityRetracted.ToString("0");
			}
			else
			{
				text += "\n<b><color=orange>Can't be crewed while retracted</color></b>";
			}
			return text;
		}

		void CountCrew ()
		{
			if (!isEnabled) {
				return;
			}
			var group = part.FindModuleImplementing<ModuleAnimationGroup> ();
			int crewCount = part.protoModuleCrew.Count;
			bool canRetract = crewCount <= crewCapacityRetracted;
			group.Events["RetractModule"].active = canRetract;
		}

		IEnumerator WaitAndCountCrew ()
		{
			yield return null;
			CountCrew ();
		}

		void onCrewTransferred (GameEvents.HostedFromToAction<ProtoCrewMember,Part> hft)
		{
			if (hft.from != part && hft.to != part) {
				return;
			}
			CountCrew ();
		}

		void UpdateCrewCapacity ()
		{
			if (isEnabled) {
				part.CrewCapacity = crewCapacityDeployed;
			} else {
				part.CrewCapacity = crewCapacityRetracted;
			}
			part.CheckTransferDialog();
		}

		public void EnableModule ()
		{
			isEnabled = true;
			UpdateCrewCapacity ();
		}

		public void DisableModule ()
		{
			isEnabled = false;
			UpdateCrewCapacity ();
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
	}
}
