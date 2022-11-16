﻿using pba_api.Models.CustomerModel;
using pba_api.Models.SheetStatusModel;
using pba_api.Models.UserModel;

namespace pba_api.Models.EstimateSheetModel
{
    public class EstimateSheet
    {
        /// <summary>
        /// The id of the <see cref="EstimateSheet"/>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the <see cref="EstimateSheet"/>
        /// </summary>
        public string SheetName { get; set; }

        /// <summary>
        /// Id of the Jira Board, where the <see cref="EstimateSheet"/> sends and gets task
        /// </summary>
        public int JiraBoardId { get; set; }

        /// <summary>
        /// Link to Workbook
        /// </summary>
        public string WorkbookLink { get; set; }

        /// <summary>
        /// Link to Jira Board
        /// </summary>
        public string JiraLink { get; set; }

        /// <summary>
        /// Link to Wireframes
        /// </summary>
        public string WireframeLink { get; set; }

        #region NavigationProperties
        public int UserId { get; set; }
        public User User { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int SheetStatusId { get; set; }
        public SheetStatus SheetStatus { get; set; }
        #endregion
    }
}