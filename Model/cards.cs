using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// cards:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class cards
	{
		public cards()
		{}
		#region Model
		private int _cid;
		private int? _id;
		private string _name;
		private string _xiyoudu;
		private string _feiyong;
		private string _zhongcheng;
		private string _wltl;
		private string _type1;
		private string _type2;
		private string _xilie;
		private int? _xilieid;
		private string _nengli;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int CID
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string XiYouDu
		{
			set{ _xiyoudu=value;}
			get{return _xiyoudu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FeiYong
		{
			set{ _feiyong=value;}
			get{return _feiyong;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ZhongCheng
		{
			set{ _zhongcheng=value;}
			get{return _zhongcheng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WLTL
		{
			set{ _wltl=value;}
			get{return _wltl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Type1
		{
			set{ _type1=value;}
			get{return _type1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Type2
		{
			set{ _type2=value;}
			get{return _type2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string XiLie
		{
			set{ _xilie=value;}
			get{return _xilie;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? XiLieID
		{
			set{ _xilieid=value;}
			get{return _xilieid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NengLi
		{
			set{ _nengli=value;}
			get{return _nengli;}
		}
		#endregion Model

	}
}

