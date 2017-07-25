using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tablepackage
	/// </summary>
	public partial class tablepackage
	{
		public tablepackage()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.tablepackage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tablepackage(");
			strSql.Append("tableID,packageID,Picktime,firstuserid)");
			strSql.Append(" values (");
			strSql.Append("@tableID,@packageID,@Picktime,@firstuserid)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@tableID", MySqlDbType.Int32,11),
					new MySqlParameter("@packageID", MySqlDbType.Int32,11),
					new MySqlParameter("@Picktime", MySqlDbType.Int32,11),
					new MySqlParameter("@firstuserid", MySqlDbType.VarChar,50)};
			parameters[0].Value = model.tableID;
			parameters[1].Value = model.packageID;
			parameters[2].Value = model.Picktime;
			parameters[3].Value = model.firstuserid;

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
		public bool Update(Maticsoft.Model.tablepackage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tablepackage set ");
			strSql.Append("tableID=@tableID,");
			strSql.Append("packageID=@packageID,");
			strSql.Append("Picktime=@Picktime,");
			strSql.Append("firstuserid=@firstuserid");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@tableID", MySqlDbType.Int32,11),
					new MySqlParameter("@packageID", MySqlDbType.Int32,11),
					new MySqlParameter("@Picktime", MySqlDbType.Int32,11),
					new MySqlParameter("@firstuserid", MySqlDbType.VarChar,50)};
			parameters[0].Value = model.tableID;
			parameters[1].Value = model.packageID;
			parameters[2].Value = model.Picktime;
			parameters[3].Value = model.firstuserid;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tablepackage ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.tablepackage GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select tableID,packageID,Picktime,firstuserid from tablepackage ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
			};

			Maticsoft.Model.tablepackage model=new Maticsoft.Model.tablepackage();
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
		public Maticsoft.Model.tablepackage DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tablepackage model=new Maticsoft.Model.tablepackage();
			if (row != null)
			{
				if(row["tableID"]!=null && row["tableID"].ToString()!="")
				{
					model.tableID=int.Parse(row["tableID"].ToString());
				}
				if(row["packageID"]!=null && row["packageID"].ToString()!="")
				{
					model.packageID=int.Parse(row["packageID"].ToString());
				}
				if(row["Picktime"]!=null && row["Picktime"].ToString()!="")
				{
					model.Picktime=int.Parse(row["Picktime"].ToString());
				}
				if(row["firstuserid"]!=null)
				{
					model.firstuserid=row["firstuserid"].ToString();
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
			strSql.Append("select tableID,packageID,Picktime,firstuserid ");
			strSql.Append(" FROM tablepackage ");
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
			strSql.Append("select count(1) FROM tablepackage ");
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
			strSql.Append(")AS Row, T.*  from tablepackage T ");
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
			parameters[0].Value = "tablepackage";
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

