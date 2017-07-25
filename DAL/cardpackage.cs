using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:cardpackage
	/// </summary>
	public partial class cardpackage
	{
		public cardpackage()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.cardpackage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into cardpackage(");
			strSql.Append("PID,CID,pickerID,packageID,SelectTime,TableID)");
			strSql.Append(" values (");
			strSql.Append("@PID,@CID,@pickerID,@packageID,@SelectTime,@TableID)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PID", MySqlDbType.VarChar,50),
					new MySqlParameter("@CID", MySqlDbType.Int32,11),
					new MySqlParameter("@pickerID", MySqlDbType.VarChar,50),
					new MySqlParameter("@packageID", MySqlDbType.Int32,11),
					new MySqlParameter("@SelectTime", MySqlDbType.Int32,11),
					new MySqlParameter("@TableID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.PID;
			parameters[1].Value = model.CID;
			parameters[2].Value = model.pickerID;
			parameters[3].Value = model.packageID;
			parameters[4].Value = model.SelectTime;
			parameters[5].Value = model.TableID;

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
		public bool Update(Maticsoft.Model.cardpackage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update cardpackage set ");
			strSql.Append("PID=@PID,");
			strSql.Append("CID=@CID,");
			strSql.Append("pickerID=@pickerID,");
			strSql.Append("packageID=@packageID,");
			strSql.Append("SelectTime=@SelectTime,");
			strSql.Append("TableID=@TableID");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PID", MySqlDbType.VarChar,50),
					new MySqlParameter("@CID", MySqlDbType.Int32,11),
					new MySqlParameter("@pickerID", MySqlDbType.VarChar,50),
					new MySqlParameter("@packageID", MySqlDbType.Int32,11),
					new MySqlParameter("@SelectTime", MySqlDbType.Int32,11),
					new MySqlParameter("@TableID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.PID;
			parameters[1].Value = model.CID;
			parameters[2].Value = model.pickerID;
			parameters[3].Value = model.packageID;
			parameters[4].Value = model.SelectTime;
			parameters[5].Value = model.TableID;

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
			strSql.Append("delete from cardpackage ");
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
		public Maticsoft.Model.cardpackage GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PID,CID,pickerID,packageID,SelectTime,TableID from cardpackage ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
			};

			Maticsoft.Model.cardpackage model=new Maticsoft.Model.cardpackage();
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
		public Maticsoft.Model.cardpackage DataRowToModel(DataRow row)
		{
			Maticsoft.Model.cardpackage model=new Maticsoft.Model.cardpackage();
			if (row != null)
			{
				if(row["PID"]!=null)
				{
					model.PID=row["PID"].ToString();
				}
				if(row["CID"]!=null && row["CID"].ToString()!="")
				{
					model.CID=int.Parse(row["CID"].ToString());
				}
				if(row["pickerID"]!=null)
				{
					model.pickerID=row["pickerID"].ToString();
				}
				if(row["packageID"]!=null && row["packageID"].ToString()!="")
				{
					model.packageID=int.Parse(row["packageID"].ToString());
				}
				if(row["SelectTime"]!=null && row["SelectTime"].ToString()!="")
				{
					model.SelectTime=int.Parse(row["SelectTime"].ToString());
				}
				if(row["TableID"]!=null && row["TableID"].ToString()!="")
				{
					model.TableID=int.Parse(row["TableID"].ToString());
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
			strSql.Append("select PID,CID,pickerID,packageID,SelectTime,TableID ");
			strSql.Append(" FROM cardpackage ");
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
			strSql.Append("select count(1) FROM cardpackage ");
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
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from cardpackage T ");
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
			parameters[0].Value = "cardpackage";
			parameters[1].Value = "";
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

