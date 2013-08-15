using System;

namespace HockeyApp
{
	
	public enum BITCrashManagerStatus {
		Disabled = 0,
		AlwaysAsk = 1,
		AutoSend = 2
	}

	
	public enum BITFeedbackUserDataElement {
		DontShow = 0,
		Optional = 1,
		Required = 2
	}
	

	public enum BITUpdateAuthorizationState {
		Denied,
		Allowed,
		Pending
	}

	public enum BITUpdateSetting  {
		CheckStartup = 0,
		CheckDaily = 1,
		CheckManually = 2
	}
}

