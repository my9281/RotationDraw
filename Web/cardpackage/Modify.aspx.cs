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
namespace Maticsoft.Web.cardpackage
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo();
			}
		}
			
	private void ShowInfo()
	{
		Maticsoft.BLL.cardpackage bll=new Maticsoft.BLL.cardpackage();
		Maticsoft.Model.cardpackage model=bll.GetModel();
		this.txtPID.Text=model.PID;
		this.txtCID.Text=model.CID.ToString();
		this.txtpickerID.Text=model.pickerID;
		this.txtpackageID.Text=model.packageID.ToString();
		this.txtSelectTime.Text=model.SelectTime.ToString();
		this.txtTableID.Text=model.TableID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtPID.Text.Trim().Length==0)
			{
				strErr+="PID不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtCID.Text))
			{
				strErr+="CID格式错误！\\n";	
			}
			if(this.txtpickerID.Text.Trim().Length==0)
			{
				strErr+="pickerID不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtpackageID.Text))
			{
				strErr+="packageID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtSelectTime.Text))
			{
				strErr+="SelectTime格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtTableID.Text))
			{
				strErr+="TableID格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string PID=this.txtPID.Text;
			int CID=int.Parse(this.txtCID.Text);
			string pickerID=this.txtpickerID.Text;
			int packageID=int.Parse(this.txtpackageID.Text);
			int SelectTime=int.Parse(this.txtSelectTime.Text);
			int TableID=int.Parse(this.txtTableID.Text);


			Maticsoft.Model.cardpackage model=new Maticsoft.Model.cardpackage();
			model.PID=PID;
			model.CID=CID;
			model.pickerID=pickerID;
			model.packageID=packageID;
			model.SelectTime=SelectTime;
			model.TableID=TableID;

			Maticsoft.BLL.cardpackage bll=new Maticsoft.BLL.cardpackage();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
