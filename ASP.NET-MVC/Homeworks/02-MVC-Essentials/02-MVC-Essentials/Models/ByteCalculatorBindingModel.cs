using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

using _02_MVC_Essentials.Enums;

namespace _02_MVC_Essentials.Models
{
    public class ByteCalculatorBindingModel
    {
        [Range(0, long.MaxValue)]
        public long Quantity { get; set; }

        [DisplayName("Type")]
        public ByteMultiple Multiple { get; set; }

        [DisplayName("Kilo")]
        public int KiloByteSize { get; set; } = 1024;

        public static IList<SelectListItem> ListItems => Enum.GetNames(typeof(ByteMultiple)).Select(x => new SelectListItem() { Text = x, Value = x }).ToList();
    }
}