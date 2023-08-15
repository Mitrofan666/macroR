/*
 * Created by SharpDevelop.
 * User: user
 * Date: 15.08.2023
 * Time: 13:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;

namespace view
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.DB.Macros.AddInId("13B48858-9FA0-4EB5-AB51-A7F8F9B3464E")]
	public partial class ThisApplication
	{
		public void Start()
		{
			Document doc = this.ActiveUIDocument.Document;
			List<View> allViews = new List<View>();
			
			List<ViewPlan> viewPlans = new FilteredElementCollector(doc, doc.ActiveView.Id)  //ActiveView выполняется
				.OfClass(typeof(ViewPlan))
				.Cast<ViewPlan>()  // .Where(Grid => !Grid.Name.Contains("/"))
				.ToList();
			foreach(View V in viewPlans)
			{
				string print = V.Name;
				TaskDialog.Show("Info", print);
			}

//			using(Transaction t = new Transaction(doc))
//			{
//				t.Start("Screen views");
//				t.Commit;
//			}
		}
		private void Module_Startup(object sender, EventArgs e)
		{

		}

		private void Module_Shutdown(object sender, EventArgs e)
		{

		}

		#region Revit Macros generated code
		private void InternalStartup()
		{
			this.Startup += new System.EventHandler(Module_Startup);
			this.Shutdown += new System.EventHandler(Module_Shutdown);
		}
		#endregion
	}
}