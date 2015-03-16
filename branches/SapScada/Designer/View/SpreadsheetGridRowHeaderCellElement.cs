using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Telerik.WinControls.UI;
using System.Drawing;

namespace Designer.View
{
    public class SpreadsheetGridRowHeaderCellElement : GridRowHeaderCellElement
    {
        public SpreadsheetGridRowHeaderCellElement(GridViewColumn column, GridRowElement row) : base(column, row) 
        { 
        }
        public override void Initialize(GridViewColumn column, GridRowElement row) 
        { 
            base.Initialize(column, row); 
        }
        protected override void InitializeFields()
        {
            base.InitializeFields();
            base.DrawFill = true;
            base.GradientStyle = Telerik.WinControls.GradientStyles.Linear;
            base.NumberOfColors = 4;
            base.BackColor = Color.FromArgb(145, 209, 0);
            base.BackColor2 = Color.FromArgb(145, 209, 0);
            base.BackColor3 = Color.FromArgb(145, 209, 0);
            base.BackColor4 = Color.FromArgb(145, 209, 0);
            base.DrawBorder = true;
            base.BorderGradientStyle = Telerik.WinControls.GradientStyles.Solid;
            base.BorderBoxStyle = Telerik.WinControls.BorderBoxStyle.OuterInnerBorders;
            base.BorderColor = Color.FromArgb(209, 225, 245);
            base.BorderInnerColor = Color.White; 
        }
        public override void SetContent()
        {
            int rowNumber = this.ViewTemplate.Rows.IndexOf(this.RowInfo) + 1;
            this.Text = rowNumber.ToString();
        }
    }
}
