/*
 * Created by SharpDevelop.
 * User: S
 * Date: 16/08/2023
 * Time: 20:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;

namespace Space
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.DB.Macros.AddInId("0572CE69-B17D-4676-A15B-9DE9204524F9")]
	public partial class ThisApplication
	{
		public void Start()
		{
			try
			{
					// Get the active document
	            Document doc = this.ActiveUIDocument.Document;
	
	            // Get all views in the document
	            FilteredElementCollector viewCollector = new FilteredElementCollector(doc);
	            ICollection<ElementId> viewIds = viewCollector.OfClass(typeof(View)).ToElementIds();
	
	            // Loop through each view
	            foreach (ElementId viewId in viewIds)
	            {
	                View view = doc.GetElement(viewId) as View;
	
	                // Get all space elements in the document
	                FilteredElementCollector spaceCollector = new FilteredElementCollector(doc);
	                ICollection<ElementId> spaceIds = spaceCollector.OfCategory(BuiltInCategory.OST_MEPSpaces).ToElementIds();
	
	                // Loop through each space element
	                foreach (ElementId spaceId in spaceIds)
	                {
//	                	string nameSpaceId = spaceId.ToString();
//	                	TaskDialog.Show("Info", nameSpaceId);
	                    SpatialElement spaceElement = doc.GetElement(spaceId) as SpatialElement;
	                }
	            }
				TaskDialog.Show("Info", "Macro the end");
			}
			catch
			{
				TaskDialog.Show("Error", "Exeption");
			}
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