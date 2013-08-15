using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace HockeyApp {

	[BaseType (typeof (NSObject))]
	public partial interface BITHockeyBaseManager {

		[Export ("serverURL", ArgumentSemantic.Copy)]
		string ServerURL { get; set; }

		[Export ("barStyle")]
		UIBarStyle BarStyle { get; set; }

		[Export ("tintColor", ArgumentSemantic.Retain)]
		UIColor TintColor { get; set; }

		[Export ("modalPresentationStyle")]
		UIModalPresentationStyle ModalPresentationStyle { get; set; }
	}


	[BaseType (typeof (BITHockeyBaseManager))]
	public partial interface BITCrashManager {

		[Export ("delegate", ArgumentSemantic.Assign)]
		BITCrashManagerDelegate Delegate { get; set; }

		[Export ("crashManagerStatus")]
		BITCrashManagerStatus CrashManagerStatus { get; set; }

		[Export ("showAlwaysButton")]
		bool ShowAlwaysButton { [Bind ("shouldShowAlwaysButton")] get; set; }

		[Export ("didCrashInLastSession")]
		bool DidCrashInLastSession { get; }

		[Export ("timeintervalCrashInLastSessionOccured")]
		double TimeintervalCrashInLastSessionOccured { get; }
	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface BITCrashManagerDelegate {

		[Export ("applicationLogForCrashManager:")]
		string  GetApplicationLog (BITCrashManager crashManager);

		[Export ("userNameForCrashManager:")]
		string  GetUserName (BITCrashManager crashManager);

		[Export ("userEmailForCrashManager:")]
		string  GetEmail (BITCrashManager crashManager);

		[Export ("crashManagerWillShowSubmitCrashReportAlert:")]
		void  WillShowCrashReportAlert (BITCrashManager crashManager);

		[Export ("crashManagerWillCancelSendingCrashReport:")]
		void  WillCancelSendingCrashReport (BITCrashManager crashManager);

		[Export ("crashManagerWillSendCrashReportsAlways:")]
		void  WillSendCrashReportAlways (BITCrashManager crashManager);

		[Export ("crashManagerWillSendCrashReport:")]
		void  WillSendCrashReport (BITCrashManager crashManager);

		[Export ("crashManager:didFailWithError:")]
		void DidFailWithError (BITCrashManager crashManager, NSError error);

		[Export ("crashManagerDidFinishSendingCrashReport:")]
		void  DidFinishSendingCrashReport (BITCrashManager crashManager);
	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface BITFeedbackComposeViewControllerDelegate {

		[Export ("feedbackComposeViewControllerDidFinish:")]
		void  FinishedCompose (BITFeedbackComposeViewController composeViewController);
	}

	[BaseType (typeof (UIActivity))]
	public partial interface BITFeedbackActivity : BITFeedbackComposeViewControllerDelegate {

		[Export ("customActivityImage", ArgumentSemantic.Retain)]
		UIImage CustomActivityImage { get; set; }

		[Export ("customActivityTitle", ArgumentSemantic.Retain)]
		string CustomActivityTitle { get; set; }
	}

	[BaseType (typeof (UIViewController))]
	public partial interface BITFeedbackComposeViewController  {

		[Export ("delegate", ArgumentSemantic.Assign)]
		BITFeedbackComposeViewControllerDelegate Delegate { get; set; }

		[Export ("prepareWithItems:")]
		void PrepareWithItems (string [] items);
	}


	[BaseType (typeof (UITableViewController))]
	public partial interface BITHockeyBaseViewController {

		[Export ("modalAnimated")]
		bool ModalAnimated { get; set; }

		[Export ("initWithModalStyle:")]
		IntPtr Constructor (bool modal);
	}


	[BaseType (typeof (BITHockeyBaseManager))]
	public partial interface BITFeedbackManager  {

		[Export ("requireUserName")]
		BITFeedbackUserDataElement RequireUserName { get; set; }

		[Export ("requireUserEmail")]
		BITFeedbackUserDataElement RequireUserEmail { get; set; }

		[Export ("showAlertOnIncomingMessages")]
		bool ShowAlertOnIncomingMessages { get; set; }

		[Export ("showFeedbackListView")]
		void ShowFeedbackListView ();

		[Export ("feedbackListViewController:")]
		BITFeedbackListViewController FeedbackListViewController (bool modal);

		[Export ("showFeedbackComposeView")]
		void ShowFeedbackComposeView ();

		[Export ("feedbackComposeViewController")]
		BITFeedbackComposeViewController FeedbackComposeViewController { get; }
	}

	[BaseType (typeof(BITHockeyBaseViewController))]
	public partial interface BITFeedbackListViewController
	{

	}

	[BaseType (typeof (NSObject))]
	public partial interface BITHockeyManager {

		[Static, Export ("sharedHockeyManager")]
		BITHockeyManager SharedHockeyManager { get; }

		[Export ("configureWithIdentifier:delegate:")]
		void Configure (string appIdentifier,[NullAllowed] BITHockeyManagerDelegate del);

		[Export ("configureWithBetaIdentifier:liveIdentifier:delegate:")]
		void Configure (string betaIdentifier, string liveIdentifier,[NullAllowed] BITHockeyManagerDelegate del);

		[Export ("startManager")]
		void StartManager ();

		[Export ("serverURL", ArgumentSemantic.Retain)]
		string ServerURL { get; set; }

		[Export ("crashManager", ArgumentSemantic.Retain)]
		BITCrashManager CrashManager { get; }

		[Export ("disableCrashManager")]
		bool DisableCrashManager { [Bind ("isCrashManagerDisabled")] get; set; }

		[Export ("updateManager", ArgumentSemantic.Retain)]
		BITUpdateManager UpdateManager { get; }

		[Export ("disableUpdateManager")]
		bool DisableUpdateManager { [Bind ("isUpdateManagerDisabled")] get; set; }

		[Export ("feedbackManager", ArgumentSemantic.Retain)]
		BITFeedbackManager FeedbackManager { get; }

		[Export ("disableFeedbackManager")]
		bool DisableFeedbackManager { [Bind ("isFeedbackManagerDisabled")] get; set; }

		[Export ("appStoreEnvironment")]
		bool AppStoreEnvironment { [Bind ("isAppStoreEnvironment")] get; }

		[Export ("debugLogEnabled")]
		bool DebugLogEnabled { [Bind ("isDebugLogEnabled")] get; set; }
	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface BITHockeyManagerDelegate {

		[Export ("shouldUseLiveIdentifierForHockeyManager:")]
		bool  ShouldUseLiveIdentifier (BITHockeyManager hockeyManager);

		[Export ("viewControllerForHockeyManager:componentManager:")]
		UIViewController ComponentManager (BITHockeyManager hockeyManager, BITHockeyBaseManager componentManager);

		[Export ("userIDForHockeyManager:componentManager:")]
		string UserId (BITHockeyManager hockeyManager, BITHockeyBaseManager componentManager);

		[Export ("userNameForHockeyManager:componentManager:")]
		string UserName (BITHockeyManager hockeyManager, BITHockeyBaseManager componentManager);

		[Export ("userEmailForHockeyManager:componentManager:")]
		string Email (BITHockeyManager hockeyManager, BITHockeyBaseManager componentManager);
	}

	[BaseType (typeof (BITHockeyBaseManager))]
	public partial interface BITUpdateManager  {

		[Export ("delegate", ArgumentSemantic.Assign)]
		NSObject Delegate { get; set; }

		[Export ("updateSetting")]
		BITUpdateSetting UpdateSetting { get; set; }

		[Export ("checkForUpdateOnLaunch")]
		bool CheckForUpdateOnLaunch { [Bind ("isCheckForUpdateOnLaunch")] get; set; }

		[Export ("checkForUpdate")]
		void CheckForUpdate ();

		[Export ("alwaysShowUpdateReminder")]
		bool AlwaysShowUpdateReminder { get; set; }

		[Export ("showDirectInstallOption")]
		bool ShowDirectInstallOption { [Bind ("isShowingDirectInstallOption")] get; set; }

		[Export ("requireAuthorization")]
		bool RequireAuthorization { [Bind ("isRequireAuthorization")] get; set; }

		[Export ("authenticationSecret", ArgumentSemantic.Retain)]
		string AuthenticationSecret { get; set; }

		[Export ("expiryDate", ArgumentSemantic.Retain)]
		NSDate ExpiryDate { get; set; }

		[Export ("showUpdateView")]
		void ShowUpdateView ();

		[Export ("hockeyViewController:")]
		BITUpdateViewController HockeyViewController (bool modal);
	}
	[BaseType(typeof(BITHockeyBaseViewController))]
	public partial interface BITUpdateViewController
	{

	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface BITUpdateManagerDelegate {

		[Export ("customDeviceIdentifierForUpdateManager:")]
		string  CustomDeviceIdentifier (BITUpdateManager updateManager);

		[Export ("shouldDisplayExpiryAlertForUpdateManager:")]
		bool  ShouldDisplayExiryAlert (BITUpdateManager updateManager);

		[Export ("didDisplayExpiryAlertForUpdateManager:")]
		void  DidDisplayExiryAlert (BITUpdateManager updateManager);

		[Export ("updateManagerShouldSendUsageData:")]
		bool  ShouldSendUsage (BITUpdateManager updateManager);

		[Export ("viewControllerForUpdateManager:")]
		UIViewController ViewController (BITUpdateManager updateManager);
	}
}
