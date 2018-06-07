using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using Napa.Graphics;
using Napa.Scripting;

/// <summary>
///    <para>
///       This script will color triangular FEM elements red so that they are 
///       easy to find and fix the mesh in those locations.
///    </para>
///    <para>
///       After installing the script, you will have a new command
///       SHOW_TRIANGULAR_ELEMENTS, which will activate this script. 
///       The command is available when you are in the modeling view.
///    </para>
/// </summary>
/// <remarks>
///    This is a placeholder for testing the script distribution mechanism.
/// </remarks>
/// 

public class ShowTringularElements : ScriptBase {

    public override void Run() {
        Graphics.Erase();        
        var style = new StyleAttributes() { FaceColor = Colors.Red };
        foreach (var element in FEM.Manager.CurrentModel.Elements) {
            if (element.Nodes.Count == 3) {
                Graphics.OverrideStyle("FEM@E:" + element.Number, style);
            }
        }
        Graphics.UpdateView();
    }
}
    
