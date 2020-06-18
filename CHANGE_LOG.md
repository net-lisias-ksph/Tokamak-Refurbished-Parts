# Tokamak-Refurbished-Parts :: Change Log

* 2018-1104: 0.1.15.4 (LinuxGuruGamer) for KSP 1.4.1
	+ Version bump for 1.5 rebuild
* 2018-0726: 0.1.15.3 (LinuxGuruGamer) for KSP 1.4.1
	+ Fixed node offsets for the ADAPT Largish and ADAPT Medium heat shields
* 2018-0718: 0.1.15.2 (LinuxGuruGamer) for KSP 1.4.1
	+ Updated EPL patches to reflect the new names for the workshop and convertor
* 2018-0424: 0.1.15.1 (LinuxGuruGamer) for KSP 1.4.1
	+ Thanks to @Fitiales for the spanish translation
* 2018-0409: 0.1.15 (LinuxGuruGamer) for KSP 1.4.1
	+ Thanks to user @LeLeon for the localization and german translation
	+ Thanks to form user @ taniwha for a couple of config file fixes
* 2018-0325: 0.1.14 (LinuxGuruGamer) for KSP 1.4.1
	+ Updated for 1.4.1
		- Added TechRequired value to the Munox part
		- Thanks to forum user @taniwha for these updates
			- Add a makefile based build system
			- Fix a merge issue I forgot to test.
			- Add the new KADEPT configs
			- Correct the descriptions of the KADEPT.
				- The large heat shield is better described as being 5m (it's
				- bulkheadProfiles has been updated accordingly) with an extended
				- size of 8m. Medium is 2.5m/4m and small is 1.25m/2m.
			- Add configs for 3.75m and 1.875m KADEPT shields
			- Build tweaks
* 2018-0325: 0.1.13 (LinuxGuruGamer) for KSP 1.4.1
	+ Thanks to forum user @taniwha for these updates
		- Make Centrifuge an animated module.
		- Install to the correct directory
		- Get crew portraits working on scene load.
		- Force-add KIS pod inventories.
		- Fix the centrifuge's crew capacity.
* 2018-0318: 0.1.12 (LinuxGuruGamer) for KSP 1.2.
	+ Updated for 1.4.1
* 2018-0204: 0.1.11 (LinuxGuruGamer) for KSP 1.3.1
	+ Changed Base Mount landing leg's category to Ground
	+ Added standardized build scripts
	+ Added Jenkins config
	+ Following changes from github user @taniwha
		- Add a disambiguator for parts with multiple ports
		- Adjust the control node positions.
		- They now match the positions of the docking ports when extended such that
		- docking indicator mods display the correct distance to the target port.
		- They have been moved out 2.72m from the center (the positions of the
		- docking port transforms when the habitat is inflated).
		- Test the correct var for null.
		- Create a module for setting the control reference.
		- This module makes it possible to use any transform of the part to which it
		- is attached as the reference transform ("Control From Here"). If the part
		- has a ModuleCommand module, then the command on the ModuleCommand module is
		- disabled in order to work around a stock bug where ModuleCommand does not
		- ensure the part's reference transform is correct before setting the
		- vessel's reference transform.
		- Fix the loading of the reference transform submodel.
		- Only the first "model =" line in a MODEL node has effect. To load multiple
		- models into a part, multiple MODEL nodes are required. This fixes the
		- problem of "Control from Here" not having the desired effect when used on
		- the docking ports. It does, however, break "Control From Here" for the
		- command module because ModuleCommand does not reset the part's reference
		- transform before setting the vessel's reference transform.
		- Use the correct module for internal flags.
		- Was added for KSP 1.2. If it doesn't work, then there's no such transform
		- in the model (it works for EL's workshop).
		- Rewrite the DeployableHabitat module.
		- It now works with ModuleAnimationGroup via IAnimatedModule. It keeps track
		- of the number of crew members in the part to determine whether the part
		- should be retractable and correctly updates the PAW for both crew transfer
		- and retract-ability
		- Make geeforce public to fix a warning.
		- Quick and dirty makefile to ease building.
		- It's not properly setup for Tokamak, but it works well enough for building
		- in Linux.
* 2017-1012: 0.1.10.1 (LinuxGuruGamer) for KSP 1.3.1
	+ Fixed bottom node location on the dry workshop
* 2017-1011: 0.1.10 (LinuxGuruGamer) for KSP 1.3
	+ No changelog provided
* 2017-0723: 0.1.9 (LinuxGuruGamer) for KSP 1.3
	+ Updated hab time for MKS
* 2017-0722: 0.1.8 (LinuxGuruGamer) for KSP 1.3
	+ Moved heat shields to Thermal category
	+ Increased crew capacity of small centrifuge to 2
	+ Added IVA from old centrifuge to replace broken on from new one
			- Following changes by @JadeOfMaar:
				- Added life support for Orbital Orb, Munox Shuttle and Small Centrifuge.
				- Wrote descriptions and adjusted titles for Munox Shuttle and Munox Adapters.
				- Munox Shuttle will hold approximately 5x the amount of any life support 1.25m tank.
				- Added T.I. prefix to Dry Workshop and Munox parts to help with search function.
				- Removed redundant Extraplanetary Launchpad modules from Inflato Workshop.
				- Moved Small Centrifuge to an appropriate place in Tech Tree (alongside stock Science Lab).
				- Fixed USI patch:
				- Parts not showing in part selection.
				- Raised habitation values. -Thanks in part to forum user @Mihara.
* 2017-0719: 0.1.7 (LinuxGuruGamer) for KSP 1.3
	+ Removed extra files in the Inflatoflat directory
* 2017-0716: 0.1.6 (LinuxGuruGamer) for KSP 1.3
	+ Removed old LS files, moved into Extras directory
	+ Added Small Centrifuge
* 2017-0712: 0.1.5 (LinuxGuruGamer) for KSP 1.3
	+ Added Life Support
* 2017-0707: 0.1.4.0 (LinuxGuruGamer) for KSP 1.3
	+ No changelog provided
* 2016-0907: 0.1.3 (maekern) for KSP 1.1.3
	+ Previous release zip had wrong version of some files. Incrementing version number to make sure changes get pushed out to everyone
* 2016-0904: 0.1.2 (maekern) for KSP 1.1.3
	+ Fixed dry worskhop not having tech tree entry
* 2016-0831: 0.1.1 (maekern) for KSP 1.1.3
	+ 0.1.1 - 2016.08.30
		- Added updated (K)ADEPT heat shields originally by DennyTX
		- Added AVC support
		- Minor bug fixes
* 2016-0827: 0.1.0 (maekern) for KSP 1.1.3 PRE-RELEASE
	+ Initial release
		- Added "refurbished" inflato1, inflato2, and inflatoflat from Porkjet hab pack, with USI-LS/MKS, CLS and ELP support
		- Added Dry Workshop with USI-LS/MKS, CLS and ELP support
