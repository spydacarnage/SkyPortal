//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Web.Mvc;

//namespace SkyInsurance.SkyPortal.Classes
//{
//    /// <summary>
//    /// Stores a collection of ISelectListable items
//    /// </summary>
//    /// <typeparam name="T">The type that the collection stores</typeparam>
//    public class SelectableCollection<T> : Collection<T> where T : BaseEntity, ISelectListable
//    {
//        public bool IsOrdered { get; set; } = true;

//        public ISelectListable this[string displayName]
//        {
//            get
//            {
//                return this.SingleOrDefault(s => s.SelectListDisplay.ToUpper() == displayName.ToUpper());
//            }
//        }

//        /// <summary>
//        /// Returns a select list from the collection
//        /// </summary>
//        /// <param name="whereClause">An optional predicate to select only some entries in the collection</param>
//        /// <returns>A SelectList for use in the DropDownList HtmlHelper</returns>
//        public virtual SelectList ToSelectList(Expression<Func<T, bool>> whereClause = null)
//        {
//            var list = new List<SelectListItem>();
//            IQueryable<T> outputList = this.AsQueryable();
//            if (whereClause != null)
//            {
//                outputList = outputList.Where(whereClause);
//            }
//            if (IsOrdered)
//            {
//                outputList = outputList.OrderBy(c => c.SelectListDisplay);
//            }

//            foreach (T item in outputList)
//            {
//                list.Add(new SelectListItem { Value = item.ID.ToString(), Text = item.SelectListDisplay });
//            }

//            return new SelectList(list, "Value", "Text");

//        }

//        /// <summary>
//        /// Returns a list of checkboxes from the collection
//        /// </summary>
//        /// <param name="selected">Optional list of items that are preselected</param>
//        /// <param name="whereClause">An optional predicate to select only some entries in the collection</param>
//        /// <returns>A list of CheckListItems for displaying as checkboxes</returns>
//        public virtual CheckList ToCheckList(SelectableCollection<T> selected = null, Expression<Func<T, bool>> whereClause = null)
//        {
//            var list = new CheckList();
//            IQueryable<T> outputList = this.AsQueryable();
//            if (whereClause != null)
//            {
//                outputList = outputList.Where(whereClause);
//            }
//            if (IsOrdered)
//            {
//                outputList = outputList.OrderBy(c => c.SelectListDisplay);
//            }

//            foreach (T item in outputList)
//            {
//                var checkItem = new CheckListItem(item.ID, item.SelectListDisplay);
//                if (selected?.Contains(item) == true)
//                {
//                    checkItem.Selected = true;
//                }
//                list.Add(checkItem);
//            }

//            return list;
//        }

//        public new SelectableCollection<T> Clone()
//        {
//            var result = new SelectableCollection<T>();
//            result.AddRange(this);
//            return result;
//        }
//    }
//}
