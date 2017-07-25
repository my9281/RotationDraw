using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:user
	/// </summary>
	public partial class user
	{
		public user()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string uid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from user");
			strSql.Append(" where uid=@uid ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@uid", MySqlDbType.VarChar,50)			};
			parameters[0].Value = uid;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into user(");
			strSql.Append("uid,username,password,lastactiontime)");
			strSql.Append(" values (");
			strSql.Append("@uid,@username,@password,@lastactiontime)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@uid", MySqlDbType.VarChar,50),
					new MySqlParameter("@username", MySqlDbType.VarChar,50),
					new MySqlParameter("@password", MySqlDbType.VarChar,50),
					new MySqlParameter("@lastactiontime", MySqlDbType.Date)};
			parameters[0].Value = model.uid;
			parameters[1].Value = model.username;
			parameters[2].Value = model.password;
			parameters[3].Value = model.lastactiontime;

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
		public bool Update(Maticsoft.Model.user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update user set ");
			strSql.Append("username=@username,");
			strSql.Append("password=@password,");
			strSql.Append("lastactiontime=@lastactiontime");
			strSql.Append(" where uid=@uid ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@username", MySqlDbType.VarChar,50),
					new MySqlParameter("@password", MySqlDbType.VarChar,50),
					new MySqlParameter("@lastactiontime", MySqlDbType.Date),
					new MySqlParameter("@uid", MySqlDbType.VarChar,50)};
			parameters[0].Value = model.username;
			parameters[1].Value = model.password;
			parameters[2].Value = model.lastactiontime;
			parameters[3].Value = model.uid;

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
		public bool Delete(string uid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from user ");
			strSql.Append(" where uid=@uid ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@uid", MySqlDbType.VarChar,50)			};
			parameters[0].Value = uid;

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
		public bool DeleteList(string uidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from user ");
			strSql.Append(" where uid in ("+uidlist + ")  ");
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
		public Maticsoft.Model.user GetModel(string uid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select uid,username,password,lastactiontime from user ");
			strSql.Append(" where uid=@uid ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@uid", MySqlDbType.VarChar,50)			};
			parameters[0].Value = uid;

			Maticsoft.Model.user model=new Maticsoft.Model.user();
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
		public Maticsoft.Model.user DataRowToModel(DataRow row)
		{
			Maticsoft.Model.user model=new Maticsoft.Model.user();
			if (row != null)
			{
				if(row["uid"]!=null)
				{
					model.uid=row["uid"].ToString();
				}
				if(row["username"]!=null)
				{
					model.username=row["username"].ToString();
				}
				if(row["password"]!=null)
				{
					model.password=row["password"].ToString();
				}
				if(row["lastactiontime"]!=null && row["lastactiontime"].ToString()!="")
				{
					model.lastactiontime=DateTime.Parse(row["lastactiontime"].ToString());
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
			strSql.Append("select uid,username,password,lastactiontime ");
			strSql.Append(" FROM user ");
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
			strSql.Append("select count(1) FROM user ");
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
				strSql.Append("order by T.uid desc");
			}
			strSql.Append(")AS Row, T.*  from user T ");
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
			parameters[0].Value = "user";
			parameters[1].Value = "uid";
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

