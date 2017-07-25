using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:cards
	/// </summary>
	public partial class cards
	{
		public cards()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("CID", "cards"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from cards");
			strSql.Append(" where CID=@CID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@CID", MySqlDbType.Int32)
			};
			parameters[0].Value = CID;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.cards model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into cards(");
			strSql.Append("ID,Name,XiYouDu,FeiYong,ZhongCheng,WLTL,Type1,Type2,XiLie,XiLieID,NengLi)");
			strSql.Append(" values (");
			strSql.Append("@ID,@Name,@XiYouDu,@FeiYong,@ZhongCheng,@WLTL,@Type1,@Type2,@XiLie,@XiLieID,@NengLi)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32,11),
					new MySqlParameter("@Name", MySqlDbType.VarChar,50),
					new MySqlParameter("@XiYouDu", MySqlDbType.VarChar,5),
					new MySqlParameter("@FeiYong", MySqlDbType.VarChar,10),
					new MySqlParameter("@ZhongCheng", MySqlDbType.VarChar,10),
					new MySqlParameter("@WLTL", MySqlDbType.VarChar,10),
					new MySqlParameter("@Type1", MySqlDbType.VarChar,10),
					new MySqlParameter("@Type2", MySqlDbType.VarChar,10),
					new MySqlParameter("@XiLie", MySqlDbType.VarChar,5),
					new MySqlParameter("@XiLieID", MySqlDbType.Int32,11),
					new MySqlParameter("@NengLi", MySqlDbType.VarChar,200)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.XiYouDu;
			parameters[3].Value = model.FeiYong;
			parameters[4].Value = model.ZhongCheng;
			parameters[5].Value = model.WLTL;
			parameters[6].Value = model.Type1;
			parameters[7].Value = model.Type2;
			parameters[8].Value = model.XiLie;
			parameters[9].Value = model.XiLieID;
			parameters[10].Value = model.NengLi;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.cards model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update cards set ");
			strSql.Append("ID=@ID,");
			strSql.Append("Name=@Name,");
			strSql.Append("XiYouDu=@XiYouDu,");
			strSql.Append("FeiYong=@FeiYong,");
			strSql.Append("ZhongCheng=@ZhongCheng,");
			strSql.Append("WLTL=@WLTL,");
			strSql.Append("Type1=@Type1,");
			strSql.Append("Type2=@Type2,");
			strSql.Append("XiLie=@XiLie,");
			strSql.Append("XiLieID=@XiLieID,");
			strSql.Append("NengLi=@NengLi");
			strSql.Append(" where CID=@CID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32,11),
					new MySqlParameter("@Name", MySqlDbType.VarChar,50),
					new MySqlParameter("@XiYouDu", MySqlDbType.VarChar,5),
					new MySqlParameter("@FeiYong", MySqlDbType.VarChar,10),
					new MySqlParameter("@ZhongCheng", MySqlDbType.VarChar,10),
					new MySqlParameter("@WLTL", MySqlDbType.VarChar,10),
					new MySqlParameter("@Type1", MySqlDbType.VarChar,10),
					new MySqlParameter("@Type2", MySqlDbType.VarChar,10),
					new MySqlParameter("@XiLie", MySqlDbType.VarChar,5),
					new MySqlParameter("@XiLieID", MySqlDbType.Int32,11),
					new MySqlParameter("@NengLi", MySqlDbType.VarChar,200),
					new MySqlParameter("@CID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.XiYouDu;
			parameters[3].Value = model.FeiYong;
			parameters[4].Value = model.ZhongCheng;
			parameters[5].Value = model.WLTL;
			parameters[6].Value = model.Type1;
			parameters[7].Value = model.Type2;
			parameters[8].Value = model.XiLie;
			parameters[9].Value = model.XiLieID;
			parameters[10].Value = model.NengLi;
			parameters[11].Value = model.CID;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int CID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from cards ");
			strSql.Append(" where CID=@CID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@CID", MySqlDbType.Int32)
			};
			parameters[0].Value = CID;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string CIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from cards ");
			strSql.Append(" where CID in ("+CIDlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.cards GetModel(int CID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CID,ID,Name,XiYouDu,FeiYong,ZhongCheng,WLTL,Type1,Type2,XiLie,XiLieID,NengLi from cards ");
			strSql.Append(" where CID=@CID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@CID", MySqlDbType.Int32)
			};
			parameters[0].Value = CID;

			Maticsoft.Model.cards model=new Maticsoft.Model.cards();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.cards DataRowToModel(DataRow row)
		{
			Maticsoft.Model.cards model=new Maticsoft.Model.cards();
			if (row != null)
			{
				if(row["CID"]!=null && row["CID"].ToString()!="")
				{
					model.CID=int.Parse(row["CID"].ToString());
				}
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["XiYouDu"]!=null)
				{
					model.XiYouDu=row["XiYouDu"].ToString();
				}
				if(row["FeiYong"]!=null)
				{
					model.FeiYong=row["FeiYong"].ToString();
				}
				if(row["ZhongCheng"]!=null)
				{
					model.ZhongCheng=row["ZhongCheng"].ToString();
				}
				if(row["WLTL"]!=null)
				{
					model.WLTL=row["WLTL"].ToString();
				}
				if(row["Type1"]!=null)
				{
					model.Type1=row["Type1"].ToString();
				}
				if(row["Type2"]!=null)
				{
					model.Type2=row["Type2"].ToString();
				}
				if(row["XiLie"]!=null)
				{
					model.XiLie=row["XiLie"].ToString();
				}
				if(row["XiLieID"]!=null && row["XiLieID"].ToString()!="")
				{
					model.XiLieID=int.Parse(row["XiLieID"].ToString());
				}
				if(row["NengLi"]!=null)
				{
					model.NengLi=row["NengLi"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CID,ID,Name,XiYouDu,FeiYong,ZhongCheng,WLTL,Type1,Type2,XiLie,XiLieID,NengLi ");
			strSql.Append(" FROM cards ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM cards ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.CID desc");
			}
			strSql.Append(")AS Row, T.*  from cards T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "cards";
			parameters[1].Value = "CID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

