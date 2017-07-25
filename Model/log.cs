using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// log:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class log
	{
		public log()
		{}
		#region Model
		private int _logid;
		private string _placeid;
		private int _tableid;
		private string _userid;
		private int? _selectercard;
		private int _nextpackage;
        private long _timeline;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int LogID
		{
			set{ _logid=value;}
			get{return _logid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PlaceID
		{
			set{ _placeid=value;}
			get{return _placeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int TableID
		{
			set{ _tableid=value;}
			get{return _tableid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SelecterCard
		{
			set{ _selectercard=value;}
			get{return _selectercard;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int NextPackage
		{
			set{ _nextpackage=value;}
			get{return _nextpackage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long TimeLine
		{
			set{ _timeline=value;}
			get{return _timeline;}
		}
		#endregion Model

	}
}

