using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WhenItsDone.DTOs.DishViewsDTOs;

namespace WhenItsDone.WebFormsClient
{
    public partial class Browse : System.Web.UI.Page
    {
        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<DishBrowseViewDTO> BrowseDishesListViewGetData()
        {
            return null;
        }

        protected void BrowseDishesListViewSelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}