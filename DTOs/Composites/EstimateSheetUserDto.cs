﻿using pba_api.Models.EstimateSheetModel;
using pba_api.Models.UserModel;

namespace pba_api.DTOs.Composites
{
    public class EstimateSheetUserDto
    {
        public int EstimateSheetId { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }
    }
}
