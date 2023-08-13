using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.DB.Macros.AddInId("92D014DC-CE6C-4720-B637-2204527B6C25")]
    public partial class ThisApplication
    {
        private void Module_Startup(object sender, EventArgs e)
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
                    SpatialElement spaceElement = doc.GetElement(spaceId) as SpatialElement;

                    // Get the location point of the space element
                    LocationPoint location = spaceElement.Location as LocationPoint;
                    XYZ markerPosition = location.Point;

                    using (Transaction trans = new Transaction(doc, "Place Space Marker"))
                    {
                        trans.Start();
                        IndependentTag.Create(
                            doc,
                            view.Id,
                            new Reference(spaceElement),
                            false,
                            TagOrientation.Horizontal,
                            markerPosition
                        );
                        trans.Commit();
                    }
                }
            }
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
