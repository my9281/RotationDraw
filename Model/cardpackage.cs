using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// cardpackage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class cardpackage
	{
		public cardpackage()
		{}
		#region Model
		private string _pid;
		private int _cid;
		private string _pickerid;
		private int _packageid;
		private int? _selecttime;
		private int? _tableid;
		/// <summary>
		/// 
		/// </summary>
		public string PID
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CID
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pickerID
		{
			set{ _pickerid=value;}
			get{return _pickerid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int packageID
		{
			set{ _packageid=value;}
			get{return _packageid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SelectTime
		{
			set{ _selecttime=value;}
			get{return _selecttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TableID
		{
			set{ _tableid=value;}
			get{return _tableid;}
		}
		#endregion Model

	}
}

