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
namespace Maticsoft.Web.cards
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int CID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(CID);
				}
			}
		}
			
	private void ShowInfo(int CID)
	{
		Maticsoft.BLL.cards bll=new Maticsoft.BLL.cards();
		Maticsoft.Model.cards model=bll.GetModel(CID);
		this.lblCID.Text=model.CID.ToString();
		this.txtID.Text=model.ID.ToString();
		this.txtName.Text=model.Name;
		this.txtXiYouDu.Text=model.XiYouDu;
		this.txtFeiYong.Text=model.FeiYong;
		this.txtZhongCheng.Text=model.ZhongCheng;
		this.txtWLTL.Text=model.WLTL;
		this.txtType1.Text=model.Type1;
		this.txtType2.Text=model.Type2;
		this.txtXiLie.Text=model.XiLie;
		this.txtXiLieID.Text=model.XiLieID.ToString();
		this.txtNengLi.Text=model.NengLi;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtID.Text))
			{
				strErr+="ID格式错误！\\n";	
			}
			if(this.txtName.Text.Trim().Length==0)
			{
				strErr+="Name不能为空！\\n";	
			}
			if(this.txtXiYouDu.Text.Trim().Length==0)
			{
				strErr+="XiYouDu不能为空！\\n";	
			}
			if(this.txtFeiYong.Text.Trim().Length==0)
			{
				strErr+="FeiYong不能为空！\\n";	
			}
			if(this.txtZhongCheng.Text.Trim().Length==0)
			{
				strErr+="ZhongCheng不能为空！\\n";	
			}
			if(this.txtWLTL.Text.Trim().Length==0)
			{
				strErr+="WLTL不能为空！\\n";	
			}
			if(this.txtType1.Text.Trim().Length==0)
			{
				strErr+="Type1不能为空！\\n";	
			}
			if(this.txtType2.Text.Trim().Length==0)
			{
				strErr+="Type2不能为空！\\n";	
			}
			if(this.txtXiLie.Text.Trim().Length==0)
			{
				strErr+="XiLie不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtXiLieID.Text))
			{
				strErr+="XiLieID格式错误！\\n";	
			}
			if(this.txtNengLi.Text.Trim().Length==0)
			{
				strErr+="NengLi不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int CID=int.Parse(this.lblCID.Text);
			int ID=int.Parse(this.txtID.Text);
			string Name=this.txtName.Text;
			string XiYouDu=this.txtXiYouDu.Text;
			string FeiYong=this.txtFeiYong.Text;
			string ZhongCheng=this.txtZhongCheng.Text;
			string WLTL=this.txtWLTL.Text;
			string Type1=this.txtType1.Text;
			string Type2=this.txtType2.Text;
			string XiLie=this.txtXiLie.Text;
			int XiLieID=int.Parse(this.txtXiLieID.Text);
			string NengLi=this.txtNengLi.Text;


			Maticsoft.Model.cards model=new Maticsoft.Model.cards();
			model.CID=CID;
			model.ID=ID;
			model.Name=Name;
			model.XiYouDu=XiYouDu;
			model.FeiYong=FeiYong;
			model.ZhongCheng=ZhongCheng;
			model.WLTL=WLTL;
			model.Type1=Type1;
			model.Type2=Type2;
			model.XiLie=XiLie;
			model.XiLieID=XiLieID;
			model.NengLi=NengLi;

			Maticsoft.BLL.cards bll=new Maticsoft.BLL.cards();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
