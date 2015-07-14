using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Customer.Models
{   
	public  class v_rpt1Repository : EFRepository<v_rpt1>, Iv_rpt1Repository
	{

	}

	public  interface Iv_rpt1Repository : IRepository<v_rpt1>
	{

	}
}