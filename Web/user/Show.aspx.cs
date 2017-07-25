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
namespace Maticsoft.Web.user
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
					string uid= strid;
					ShowInfo(uid);
				}
			}
		}
		
	private void ShowInfo(string uid)
	{
		Maticsoft.BLL.user bll=new Maticsoft.BLL.user();
		Maticsoft.Model.user model=bll.GetModel(uid);
		this.lbluid.Text=model.uid;
		this.lblusername.Text=model.username;
		this.lblpassword.Text=model.password;
		this.lbllastactiontime.Text=model.lastactiontime.ToString();

	}


    }
}
