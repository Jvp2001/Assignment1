using System.Reflection;
using UnityEngine;

/// <remarks>Only works when in <b>debug</b> and in <b>Unity Editor</b>.</remarks>
/// <summary>
/// 
/// A logger that wraps Unity's internal logger.
/// Calls to its methods are stripped in case the LOGGER_SYMBOL is not defined.
/// Stops the need for using preprocessor statements when every I want to output to the console.
/// </summary>
/// <see cref="https://forum.unity.com/threads/strip-release-build-from-all-debug-log-calls.353600/?_ga=2.177561125.185472191.1600770389-724911382.1591691267"/>
namespace Assignment1 {
internal static class Logger {
	/// <summary>
	/// The name of the symbol that has been defined at the top of this file.
	///  
	/// </summary>
	public const string LoggerSymbol = "ENABLE_LOG";


	[System.Diagnostics.Conditional(LoggerSymbol)]
	public static void Log(object message) {
		Debug.Log(message);
	}

	[System.Diagnostics.Conditional(LoggerSymbol)]
	public static void Log(object message, Object context) {
		Debug.Log(message, context);
	}

	[System.Diagnostics.Conditional(LoggerSymbol)]
	public static void LogFormat(string message, params object[] args) {
		Debug.LogFormat(message, args);
	}

	[System.Diagnostics.Conditional(LoggerSymbol)]
	public static void LogFormat(Object context, string message, params object[] args) {
		Debug.LogFormat(context, message, args);
	}

	[System.Diagnostics.Conditional(LoggerSymbol)]
	public static void LogWarning(object message) {
		Debug.LogWarning(message);
	}

	[System.Diagnostics.Conditional(LoggerSymbol)]
	public static void LogWarning(object message, Object context) {
		Debug.LogWarning(message, context);
	}

	[System.Diagnostics.Conditional(LoggerSymbol)]
	public static void LogWarningFormat(string message, params object[] args) {
		Debug.LogWarningFormat(message, args);
	}

	[System.Diagnostics.Conditional(LoggerSymbol)]
	public static void LogWarningFormat(Object context, string message, params object[] args) {
		Debug.LogWarningFormat(context, message, args);
	}

	[System.Diagnostics.Conditional(LoggerSymbol)]
	public static void LogError(object message) {
		Debug.LogError(message);
	}

	[System.Diagnostics.Conditional(LoggerSymbol)]
	public static void LogError(object message, Object context) {
		Debug.LogError(message, context);
	}

	[System.Diagnostics.Conditional(LoggerSymbol)]
	public static void LogErrorFormat(string message, params object[] args) {
		Debug.LogErrorFormat(message, args);
	}

	[System.Diagnostics.Conditional(LoggerSymbol)]
	public static void LogErrorFormat(Object context, string message, params object[] args) {
		Debug.LogErrorFormat(context, message, args);
	}

	[System.Diagnostics.Conditional(LoggerSymbol)]
	public static void LogException(System.Exception exception) {
		Debug.LogException(exception);
	}

	[System.Diagnostics.Conditional(LoggerSymbol)]
	public static void LogException(System.Exception exception, Object context) {
		Debug.LogException(exception, context);
	}
}
}