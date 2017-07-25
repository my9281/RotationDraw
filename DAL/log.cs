using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:log
	/// </summary>
	public partial class log
	{
		public log()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("LogID", "log"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int LogID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from log");
			strSql.Append(" where LogID=@LogID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@LogID", MySqlDbType.Int32)
			};
			parameters[0].Value = LogID;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into log(");
			strSql.Append("PlaceID,TableID,UserID,SelecterCard,NextPackage,TimeLine)");
			strSql.Append(" values (");
			strSql.Append("@PlaceID,@TableID,@UserID,@SelecterCard,@NextPackage,@TimeLine)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PlaceID", MySqlDbType.VarChar,80),
					new MySqlParameter("@TableID", MySqlDbType.Int32,11),
					new MySqlParameter("@UserID", MySqlDbType.VarChar,80),
					new MySqlParameter("@SelecterCard", MySqlDbType.Int32,11),
					new MySqlParameter("@NextPackage", MySqlDbType.Int32,11),
					new MySqlParameter("@TimeLine", MySqlDbType.Int64,11)};
			parameters[0].Value = model.PlaceID;
			parameters[1].Value = model.TableID;
			parameters[2].Value = model.UserID;
			parameters[3].Value = model.SelecterCard;
			parameters[4].Value = model.NextPackage;
			parameters[5].Value = model.TimeLine;

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
		public bool Update(Maticsoft.Model.log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update log set ");
			strSql.Append("PlaceID=@PlaceID,");
			strSql.Append("TableID=@TableID,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("SelecterCard=@SelecterCard,");
			strSql.Append("NextPackage=@NextPackage,");
			strSql.Append("TimeLine=@TimeLine");
			strSql.Append(" where LogID=@LogID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PlaceID", MySqlDbType.VarChar,80),
					new MySqlParameter("@TableID", MySqlDbType.Int32,11),
					new MySqlParameter("@UserID", MySqlDbType.VarChar,80),
					new MySqlParameter("@SelecterCard", MySqlDbType.Int32,11),
					new MySqlParameter("@NextPackage", MySqlDbType.Int32,11),
					new MySqlParameter("@TimeLine", MySqlDbType.Int32,11),
					new MySqlParameter("@LogID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.PlaceID;
			parameters[1].Value = model.TableID;
			parameters[2].Value = model.UserID;
			parameters[3].Value = model.SelecterCard;
			parameters[4].Value = model.NextPackage;
			parameters[5].Value = model.TimeLine;
			parameters[6].Value = model.LogID;

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
		public bool Delete(int LogID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from log ");
			strSql.Append(" where LogID=@LogID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@LogID", MySqlDbType.Int32)
			};
			parameters[0].Value = LogID;

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
		public bool DeleteList(string LogIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from log ");
			strSql.Append(" where LogID in ("+LogIDlist + ")  ");
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
		public Maticsoft.Model.log GetModel(int LogID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select LogID,PlaceID,TableID,UserID,SelecterCard,NextPackage,TimeLine from log ");
			strSql.Append(" where LogID=@LogID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@LogID", MySqlDbType.Int32)
			};
			parameters[0].Value = LogID;

			Maticsoft.Model.log model=new Maticsoft.Model.log();
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
		public Maticsoft.Model.log DataRowToModel(DataRow row)
		{
			Maticsoft.Model.log model=new Maticsoft.Model.log();
			if (row != null)
			{
				if(row["LogID"]!=null && row["LogID"].ToString()!="")
				{
					model.LogID=int.Parse(row["LogID"].ToString());
				}
				if(row["PlaceID"]!=null)
				{
					model.PlaceID=row["PlaceID"].ToString();
				}
				if(row["TableID"]!=null && row["TableID"].ToString()!="")
				{
					model.TableID=int.Parse(row["TableID"].ToString());
				}
				if(row["UserID"]!=null)
				{
					model.UserID=row["UserID"].ToString();
				}
				if(row["SelecterCard"]!=null && row["SelecterCard"].ToString()!="")
				{
					model.SelecterCard=int.Parse(row["SelecterCard"].ToString());
				}
				if(row["NextPackage"]!=null && row["NextPackage"].ToString()!="")
				{
					model.NextPackage=int.Parse(row["NextPackage"].ToString());
				}
				if(row["TimeLine"]!=null && row["TimeLine"].ToString()!="")
				{
					model.TimeLine=long.Parse(row["TimeLine"].ToString());
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
			strSql.Append("select LogID,PlaceID,TableID,UserID,SelecterCard,NextPackage,TimeLine ");
			strSql.Append(" FROM log ");
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
			strSql.Append("select count(1) FROM log ");
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
				strSql.Append("order by T.LogID desc");
			}
			strSql.Append(")AS Row, T.*  from log T ");
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
			parameters[0].Value = "log";
			parameters[1].Value = "LogID";
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

