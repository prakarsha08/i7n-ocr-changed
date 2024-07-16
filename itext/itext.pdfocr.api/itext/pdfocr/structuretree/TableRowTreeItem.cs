/*
This file is part of the iText (R) project.
Copyright (c) 1998-2024 Apryse Group NV
Authors: Apryse Software.

This program is offered under a commercial and under the AGPL license.
For commercial licensing, contact us at https://itextpdf.com/sales.  For AGPL licensing, see below.

AGPL licensing:
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
using iText.Kernel.Pdf.Tagging;
using iText.Kernel.Pdf.Tagutils;

namespace iText.Pdfocr.Structuretree {
    /// <summary>A convenience class to associate certain text items with the table row structure item.</summary>
    public class TableRowTreeItem : LogicalStructureTreeItem {
        /// <summary>
        /// Instantiate a new
        /// <see cref="TableRowTreeItem"/>
        /// instance.
        /// </summary>
        public TableRowTreeItem()
            : base(new DefaultAccessibilityProperties(StandardRoles.TR)) {
        }

        /// <summary>Add a new table cell structure tree item to the table row.</summary>
        /// <param name="cellItem">table cell structure tree item to be added.</param>
        /// <returns>
        /// this
        /// <see cref="TableRowTreeItem"/>
        /// instance.
        /// </returns>
        public virtual iText.Pdfocr.Structuretree.TableRowTreeItem AddCell(TableCellTreeItem cellItem) {
            AddChild(cellItem);
            return this;
        }
    }
}