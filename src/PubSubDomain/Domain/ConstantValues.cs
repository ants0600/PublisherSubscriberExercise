namespace PubSubDomain.Domain
{
	public static class ConstantValues
	{
		/// <summary>
		/// 0: type, 1: message, 2: stack trace.
		/// </summary>
		public const string ErrorMessageFormat = @"
EXCEPTION TYPE: [{0}].
EXCEPTION MESSAGE: [{1}].
EXCEPTION STACK TRACE:
{2}
";

		public const string LogName = "Application";

		public const string MachineName = ".";

		public const string Source = "testEventLogEvent";
	}
}
