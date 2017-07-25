using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// user:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class user
	{
		public user()
		{}
		#region Model
		private string _uid;
		private string _username;
		private string _password;
		private DateTime _lastactiontime;
		/// <summary>
		/// 
		/// </summary>
		public string uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime lastactiontime
		{
			set{ _lastactiontime=value;}
			get{return _lastactiontime;}
		}
		#endregion Model

	}
}

