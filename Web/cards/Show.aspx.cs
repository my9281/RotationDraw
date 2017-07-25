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
namespace Maticsoft.Web.cards
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int CID=(Convert.ToInt32(strid));
					ShowInfo(CID);
				}
			}
		}
		
	private void ShowInfo(int CID)
	{
		Maticsoft.BLL.cards bll=new Maticsoft.BLL.cards();
		Maticsoft.Model.cards model=bll.GetModel(CID);
		this.lblCID.Text=model.CID.ToString();
		this.lblID.Text=model.ID.ToString();
		this.lblName.Text=model.Name;
		this.lblXiYouDu.Text=model.XiYouDu;
		this.lblFeiYong.Text=model.FeiYong;
		this.lblZhongCheng.Text=model.ZhongCheng;
		this.lblWLTL.Text=model.WLTL;
		this.lblType1.Text=model.Type1;
		this.lblType2.Text=model.Type2;
		this.lblXiLie.Text=model.XiLie;
		this.lblXiLieID.Text=model.XiLieID.ToString();
		this.lblNengLi.Text=model.NengLi;

	}


    }
}
