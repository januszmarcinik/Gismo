﻿using System.Collections.Generic;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.Domain.Application.DataSource
{
    public class DataItem
    {
        public DataItem()
        {
            this.Values = new List<string>();
        }

        public int PrimaryKeyId { get; set; }
        public string ImagePath { get; set; }

        public List<string> Values { get; set; }
        public string ListText { get; set; }
        public ActionResult ListAction { get; set; }
        public ActionResult EditAction { get; set; }
        public ActionResult DeleteAction { get; set; }
        public ActionResult GetImageAction { get; set; }
    }
}