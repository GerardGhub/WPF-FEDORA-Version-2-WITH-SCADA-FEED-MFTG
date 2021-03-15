using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFFDR
{
    public class import_po_summary
    {
        public int po_sum_id { get; set; }
        public string pr_number { get; set; }
        public string pr_date { get; set; }
        public string po_number { get; set; }
        public string po_date { get; set; }
        public string item_code { get; set; }
        public string item_description { get; set; }
        public string qty_ordered { get; set; }
        public string qty_delivered { get; set; }
        public string qty_billed { get; set; }
        public string qty_uom { get; set; }
        public string unit_price { get; set; }
        public string vendor_name { get; set; }
        public string import_date { get; set; }

    }


    public class formula_uploader
    {
        public int recipe_id { get; set; }
        public string rp_type { get; set; }
        public string feed_code { get; set; }
        public string rp_feed_type { get; set; }
        public string item_code { get; set; }
        public string rp_description { get; set; }
        public string rp_category { get; set; }
        public string rp_group { get; set; }
        public string quantity { get; set; }
        //public int intquantity { get; set; }


    }
    public class raw_materials_uploader
    {
        public int item_id {get; set;}
        public string item_code { get; set; }
        public string item_description { get; set; }
        public string Category { get; set; }
        public string GROUP { get; set; }
        public string item_group { get; set; }

    }
    public class upload_supplier
    {
        public int supplier_id { get; set; }
        public string supplier { get; set; }

    }


}
