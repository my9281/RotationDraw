using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tablepackage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tablepackage
	{
		public tablepackage()
		{}
		#region Model
		private int _tableid;
		private int _packageid;
		private int _picktime;
		private string _firstuserid;
		/// <summary>
		/// 
		/// </summary>
		public int tableID
		{
			set{ _tableid=value;}
			get{return _tableid;}
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
		public int Picktime
		{
			set{ _picktime=value;}
			get{return _picktime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string firstuserid
		{
			set{ _firstuserid=value;}
			get{return _firstuserid;}
		}
		#endregion Model

	}
}

