namespace Jabbot.Core
{
	public interface ILogger
	{
		void WriteMessage(string p0);
		void Write(string format, params object[] args);
	}
}