using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryApp.WinClient.CustomeControls
{
    public class GridControl<TModel> where TModel:class
    {
        DataGridView grid;
        BindingSource bindingSource;


        public GridControl(Control container)
        {
            grid = new DataGridView();
            container.Controls.Add(grid);

            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            grid.Dock = DockStyle.Fill;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToResizeColumns = false;
            grid.AutoGenerateColumns = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.RowsDefaultCellStyle.BackColor = Color.LightGray;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
            grid.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        public GridControl<TModel> AddTextBoxColumn<TProperty>(Expression<Func<TModel,TProperty>> selector, string title)
        {
            var propertyName = new ExpressionHandler().GetPropertyName(selector);
            grid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = title,
                DataPropertyName=propertyName

            });

            return this;
        }

        public GridControl<TModel> PopulateDataGridView(IEnumerable<TModel> data)
        {

            bindingSource = new BindingSource();
            bindingSource.DataSource = data;
            grid.DataSource = bindingSource;
            bindingSource.ResetBindings(true);

            return this;
        }

        public void RemoveCurrentItem()
        {
            bindingSource.RemoveCurrent();
            bindingSource.ResetBindings(true);
        }

        public void ResetBindings()
        {
            bindingSource?.ResetBindings(true);
        }

        public void AddItem(TModel entity)
        {
            bindingSource.Add(entity);
            bindingSource.ResetBindings(true);
        }
        
        public TModel GetCurrentItem
        {
            get{ return bindingSource.Current as TModel; }
        }

    }
}
