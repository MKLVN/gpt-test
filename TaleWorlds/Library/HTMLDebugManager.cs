using System;

namespace TaleWorlds.Library;

public class HTMLDebugManager : IDebugManager
{
	private static Logger _mainLogger;

	private bool _testModeEnabled;

	public static bool LogOnlyErrors
	{
		get
		{
			return _mainLogger.LogOnlyErrors;
		}
		set
		{
			_mainLogger.LogOnlyErrors = value;
		}
	}

	public HTMLDebugManager(int numFiles = 1, int totalFileSize = -1)
	{
		_mainLogger = new Logger("__global", writeErrorsToDifferentFile: true, logOnlyErrors: false, doNotUseProcessId: false, numFiles, totalFileSize);
	}

	void IDebugManager.SetCrashReportCustomString(string customString)
	{
	}

	void IDebugManager.SetCrashReportCustomStack(string customStack)
	{
	}

	void IDebugManager.ShowMessageBox(string lpText, string lpCaption, uint uType)
	{
	}

	void IDebugManager.ShowError(string message)
	{
		_mainLogger.Print(message, HTMLDebugCategory.Error, printOnGlobal: false);
	}

	void IDebugManager.ShowWarning(string message)
	{
		_mainLogger.Print(message, HTMLDebugCategory.Warning, printOnGlobal: false);
	}

	void IDebugManager.Assert(bool condition, string message, string callerFile, string callerMethod, int callerLine)
	{
		Assert(condition, message, callerFile, callerMethod, callerLine);
	}

	void IDebugManager.SilentAssert(bool condition, string message, bool getDump, string callerFile, string callerMethod, int callerLine)
	{
		SilentAssert(condition, message, getDump, callerFile, callerMethod, callerLine);
	}

	void IDebugManager.Print(string message, int logLevel, Debug.DebugColor color, ulong debugFilter)
	{
		_mainLogger.Print(message, HTMLDebugCategory.General, printOnGlobal: false);
	}

	void IDebugManager.PrintError(string error, string stackTrace, ulong debugFilter)
	{
		_mainLogger.Print(error, HTMLDebugCategory.Error, printOnGlobal: false);
	}

	void IDebugManager.PrintWarning(string warning, ulong debugFilter)
	{
		_mainLogger.Print(warning, HTMLDebugCategory.Warning, printOnGlobal: false);
	}

	void IDebugManager.DisplayDebugMessage(string message)
	{
	}

	void IDebugManager.WatchVariable(string name, object value)
	{
	}

	void IDebugManager.WriteDebugLineOnScreen(string message)
	{
	}

	void IDebugManager.RenderDebugLine(Vec3 position, Vec3 direction, uint color, bool depthCheck, float time)
	{
	}

	void IDebugManager.RenderDebugSphere(Vec3 position, float radius, uint color, bool depthCheck, float time)
	{
	}

	void IDebugManager.RenderDebugFrame(MatrixFrame frame, float lineLength, float time)
	{
	}

	void IDebugManager.RenderDebugText(float screenX, float screenY, string text, uint color, float time)
	{
	}

	void IDebugManager.RenderDebugText3D(Vec3 position, string text, uint color, int screenPosOffsetX, int screenPosOffsetY, float time)
	{
	}

	void IDebugManager.RenderDebugRectWithColor(float left, float bottom, float right, float top, uint color)
	{
	}

	Vec3 IDebugManager.GetDebugVector()
	{
		return Vec3.Zero;
	}

	void IDebugManager.SetTestModeEnabled(bool testModeEnabled)
	{
		_testModeEnabled = testModeEnabled;
	}

	void IDebugManager.AbortGame()
	{
		Environment.Exit(-5);
	}

	void IDebugManager.DoDelayedexit(int returnCode)
	{
	}

	protected void PrintMessage(string message, HTMLDebugCategory debugCategory, bool printOnGlobal)
	{
		_mainLogger.Print(message, debugCategory, printOnGlobal);
	}

	protected virtual void Assert(bool condition, string message, string callerFile, string callerMethod, int callerLine)
	{
		if (!condition)
		{
			_mainLogger.Print(message, HTMLDebugCategory.Error, printOnGlobal: false);
		}
	}

	protected virtual void SilentAssert(bool condition, string message, bool getDump, string callerFile, string callerMethod, int callerLine)
	{
		Assert(condition, message, callerFile, callerMethod, callerLine);
	}

	void IDebugManager.ReportMemoryBookmark(string message)
	{
	}
}
