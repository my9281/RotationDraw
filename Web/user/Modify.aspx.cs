using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace Maticsoft.Web.user
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					string uid= Request.Params["id"];
					ShowInfo(uid);
				}
			}
		}
			
	private void ShowInfo(string uid)
	{
		Maticsoft.BLL.user bll=new Maticsoft.BLL.user();
		Maticsoft.Model.user model=bll.GetModel(uid);
		this.lbluid.Text=model.uid;
		this.txtusername.Text=model.username;
		this.txtpassword.Text=model.password;
		this.txtlastactiontime.Text=model.lastactiontime.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtusername.Text.Trim().Length==0)
			{
				strErr+="username不能为空！\\n";	
			}
			if(this.txtpassword.Text.Trim().Length==0)
			{
				strErr+="password不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtlastactiontime.Text))
			{
				strErr+="lastactiontime格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string uid=this.lbluid.Text;
			string username=this.txtusername.Text;
			string password=this.txtpassword.Text;
			DateTime lastactiontime=DateTime.Parse(this.txtlastactiontime.Text);


			Maticsoft.Model.user model=new Maticsoft.Model.user();
			model.uid=uid;
			model.username=username;
			model.password=password;
			model.lastactiontime=lastactiontime;

			Maticsoft.BLL.user bll=new Maticsoft.BLL.user();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
