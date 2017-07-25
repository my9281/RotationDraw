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
namespace Maticsoft.Web.cardpackage
{
    public partial class Show : Page
    {        
        		public string strid=""; 
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
		this.lblPID.Text=model.PID;
		this.lblCID.Text=model.CID.ToString();
		this.lblpickerID.Text=model.pickerID;
		this.lblpackageID.Text=model.packageID.ToString();
		this.lblSelectTime.Text=model.SelectTime.ToString();
		this.lblTableID.Text=model.TableID.ToString();

	}


    }
}
