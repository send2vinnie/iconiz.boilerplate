﻿var DatatableHtmlTableDemo={init:function(){$(".m-datatable").mDatatable({search:{input:$("#generalSearch")},layout:{scroll:!0,height:400},columns:[{field:"Deposit Paid",type:"number",locked:{left:"xl"}},{field:"Order Date",type:"date",format:"YYYY-MM-DD",locked:{left:"xl"}}]})}};jQuery(document).ready(function(){DatatableHtmlTableDemo.init()});