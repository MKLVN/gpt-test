using System.Linq;
using SandBox.AI;
using SandBox.CampaignBehaviors;
using SandBox.GameComponents;
using SandBox.Issues;
using SandBox.Objects;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ObjectSystem;
using TaleWorlds.SaveSystem;
using TaleWorlds.SaveSystem.Load;

namespace SandBox;

public class SandBoxSubModule : MBSubModuleBase
{
	private bool _initialized;

	private bool _latestSaveLoaded;

	protected override void OnSubModuleLoad()
	{
		base.OnSubModuleLoad();
		Module.CurrentModule.SetEditorMissionTester(new SandBoxEditorMissionTester());
	}

	protected override void InitializeGameStarter(Game game, IGameStarter gameStarterObject)
	{
		if (game.GameType is Campaign)
		{
			if (gameStarterObject.Models.FirstOrDefault((GameModel model) => model is DefaultMapWeatherModel) is DefaultMapWeatherModel defaultMapWeatherModel)
			{
				byte[] array = new byte[2097152];
				Utilities.GetSnowAmountData(array);
				defaultMapWeatherModel.InitializeSnowAndRainAmountData(array);
			}
			gameStarterObject.AddModel(new SandboxAgentStatCalculateModel());
			gameStarterObject.AddModel(new SandboxAgentApplyDamageModel());
			gameStarterObject.AddModel(new SandboxMissionDifficultyModel());
			gameStarterObject.AddModel(new SandboxApplyWeatherEffectsModel());
			gameStarterObject.AddModel(new SandboxAutoBlockModel());
			gameStarterObject.AddModel(new SandboxAgentDecideKilledOrUnconsciousModel());
			gameStarterObject.AddModel(new SandboxBattleBannerBearersModel());
			gameStarterObject.AddModel(new DefaultFormationArrangementModel());
			gameStarterObject.AddModel(new SandboxBattleMoraleModel());
			gameStarterObject.AddModel(new SandboxBattleInitializationModel());
			gameStarterObject.AddModel(new SandboxBattleSpawnModel());
			gameStarterObject.AddModel(new DefaultDamageParticleModel());
			gameStarterObject.AddModel(new DefaultItemPickupModel());
			if (gameStarterObject is CampaignGameStarter campaignGameStarter)
			{
				campaignGameStarter.AddBehavior(new HideoutConversationsCampaignBehavior());
				campaignGameStarter.AddBehavior(new AlleyCampaignBehavior());
				campaignGameStarter.AddBehavior(new CommonTownsfolkCampaignBehavior());
				campaignGameStarter.AddBehavior(new CompanionRolesCampaignBehavior());
				campaignGameStarter.AddBehavior(new DefaultNotificationsCampaignBehavior());
				campaignGameStarter.AddBehavior(new ClanMemberRolesCampaignBehavior());
				campaignGameStarter.AddBehavior(new GuardsCampaignBehavior());
				campaignGameStarter.AddBehavior(new SettlementMusiciansCampaignBehavior());
				campaignGameStarter.AddBehavior(new BoardGameCampaignBehavior());
				campaignGameStarter.AddBehavior(new WorkshopsCharactersCampaignBehavior());
				campaignGameStarter.AddBehavior(new TradersCampaignBehavior());
				campaignGameStarter.AddBehavior(new ArenaMasterCampaignBehavior());
				campaignGameStarter.AddBehavior(new CommonVillagersCampaignBehavior());
				campaignGameStarter.AddBehavior(new HeirSelectionCampaignBehavior());
				campaignGameStarter.AddBehavior(new DefaultCutscenesCampaignBehavior());
				campaignGameStarter.AddBehavior(new RivalGangMovingInIssueBehavior());
				campaignGameStarter.AddBehavior(new RuralNotableInnAndOutIssueBehavior());
				campaignGameStarter.AddBehavior(new FamilyFeudIssueBehavior());
				campaignGameStarter.AddBehavior(new NotableWantsDaughterFoundIssueBehavior());
				campaignGameStarter.AddBehavior(new TheSpyPartyIssueQuestBehavior());
				campaignGameStarter.AddBehavior(new ProdigalSonIssueBehavior());
				campaignGameStarter.AddBehavior(new BarberCampaignBehavior());
				campaignGameStarter.AddBehavior(new SnareTheWealthyIssueBehavior());
				campaignGameStarter.AddBehavior(new RetirementCampaignBehavior());
				campaignGameStarter.AddBehavior(new StatisticsCampaignBehavior());
				campaignGameStarter.AddBehavior(new DumpIntegrityCampaignBehavior());
				campaignGameStarter.AddBehavior(new CaravanConversationsCampaignBehavior());
			}
		}
	}

	public override void OnCampaignStart(Game game, object starterObject)
	{
		if (game.GameType is Campaign campaign)
		{
			SandBoxManager sandBoxManager = campaign.SandBoxManager;
			sandBoxManager.SandBoxMissionManager = new SandBoxMissionManager();
			sandBoxManager.AgentBehaviorManager = new AgentBehaviorManager();
			sandBoxManager.ModuleManager = new ModuleManager();
			sandBoxManager.SandBoxSaveManager = new SandBoxSaveManager();
		}
	}

	private void OnRegisterTypes()
	{
		MBObjectManager.Instance.RegisterType<InstrumentData>("MusicInstrument", "MusicInstruments", 54u);
		MBObjectManager.Instance.RegisterType<SettlementMusicData>("MusicTrack", "MusicTracks", 55u);
		new DefaultMusicInstrumentData();
		MBObjectManager.Instance.LoadXML("MusicInstruments");
		MBObjectManager.Instance.LoadXML("MusicTracks");
	}

	public override void OnGameInitializationFinished(Game game)
	{
		if (game.GameType is Campaign campaign)
		{
			campaign.CampaignMissionManager = new CampaignMissionManager();
			campaign.MapSceneCreator = new MapSceneCreator();
			campaign.EncyclopediaManager.CreateEncyclopediaPages();
			OnRegisterTypes();
		}
	}

	public override void RegisterSubModuleObjects(bool isSavedCampaign)
	{
		Campaign.Current.SandBoxManager.InitializeSandboxXMLs(isSavedCampaign);
	}

	public override void AfterRegisterSubModuleObjects(bool isSavedCampaign)
	{
		Campaign.Current.SandBoxManager.InitializeCharactersAfterLoad(isSavedCampaign);
	}

	public override void OnInitialState()
	{
		base.OnInitialState();
		if (!Module.CurrentModule.StartupInfo.IsContinueGame || _latestSaveLoaded)
		{
			return;
		}
		_latestSaveLoaded = true;
		SaveGameFileInfo[] saveFiles = MBSaveLoad.GetSaveFiles();
		if (!saveFiles.IsEmpty())
		{
			SandBoxSaveHelper.TryLoadSave(saveFiles.MaxBy((SaveGameFileInfo s) => s.MetaData.GetCreationTime()), StartGame);
		}
	}

	private void StartGame(LoadResult loadResult)
	{
		MBGameManager.StartNewGame(new SandBoxGameManager(loadResult));
		MouseManager.ShowCursor(show: false);
	}

	public override void OnGameLoaded(Game game, object initializerObject)
	{
		if (game.GameType is Campaign campaign)
		{
			SandBoxManager sandBoxManager = campaign.SandBoxManager;
			sandBoxManager.SandBoxMissionManager = new SandBoxMissionManager();
			sandBoxManager.AgentBehaviorManager = new AgentBehaviorManager();
			sandBoxManager.ModuleManager = new ModuleManager();
			sandBoxManager.SandBoxSaveManager = new SandBoxSaveManager();
		}
	}

	protected override void OnBeforeInitialModuleScreenSetAsRoot()
	{
		base.OnBeforeInitialModuleScreenSetAsRoot();
		if (!_initialized)
		{
			MBSaveLoad.Initialize(Module.CurrentModule.GlobalTextManager);
			_initialized = true;
		}
	}

	public override void OnConfigChanged()
	{
		if (Campaign.Current != null)
		{
			CampaignEventDispatcher.Instance.OnConfigChanged();
		}
	}
}
