using System;
using System.Collections.Generic;
using UnityEngine;

namespace Habitat
{
	public class MultiPortDisambiguator : PartModule
	{
		List<string> portSuffixes;

		void UpdateGuiName (BaseEvent evt, int index)
		{
			string suffix;

			if (index >= 0 && index < portSuffixes.Count) {
				suffix = portSuffixes[index];
			} else {
				suffix = index.ToString("<D2>") + " " + portSuffixes.Count;
			}
			evt.guiName = evt.guiName + " " + suffix;
		}

		void SetGuiNames ()
		{
			var ports = part.FindModulesImplementing<ModuleDockingNode> ();
			for (int i = 0; i < ports.Count; i++) {
				ModuleDockingNode p = ports[i];
				UpdateGuiName (p.Events["Undock"], i);
				UpdateGuiName (p.Events["UndockSameVessel"], i);
				UpdateGuiName (p.Events["Decouple"], i);
				UpdateGuiName (p.Events["SetAsTarget"], i);
				//Kind of redundant
				//UpdateGuiName (p.Events["UnsetTarget"], i);
				UpdateGuiName (p.Events["EnableXFeed"], i);
				UpdateGuiName (p.Events["DisableXFeed"], i);
				UpdateGuiName (p.Events["MakeReferenceTransform"], i);
			}
		}

		public override void OnStart(PartModule.StartState state)
		{
			if (portSuffixes == null) {
				var mpd = part.partInfo.partPrefab.FindModuleImplementing<MultiPortDisambiguator> ();
				portSuffixes = mpd.portSuffixes;
			}
			SetGuiNames ();
		}

		public override void OnLoad (ConfigNode node)
		{
			for (int i = 0; i < node.values.Count; i++) {
				ConfigNode.Value v = node.values[i];
				if (v.name == "suffix") {
					if (portSuffixes == null) {
						portSuffixes = new List<string> ();
					}
					portSuffixes.Add (v.value);
				}
			}
		}
	}
}
