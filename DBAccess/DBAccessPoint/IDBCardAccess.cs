using Models;

namespace DBAccess.DBAccessPoint
{
	public interface IDBCardAccess
	{
		string CnnVal();
		Task<List<T>> DBGetConnectionHandler<T>(string sqlString);
		Task<List<T>> DBGetConnectionHandlerByType<T>(string sqlString, CardType param);
		Task<int> DBPostConnectionHandler(string sqlString, object param);
		Task<T> GetConnectionHandlerById<T>(string sqlString, int Id);
	}
}